using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;
using ZXing;

namespace MeyerSStore
{
    public partial class VenderControl : UserControl
    {
        private VideoCaptureDevice videoCaptureDevice;
        private Form1 form;
        private ConfigurarControl configuracion;
        private EsperaControl espera;

        public VenderControl(Form1 form1, ConfigurarControl configurarControl, EsperaControl esperaControl)
        {
            InitializeComponent();
            form = form1;
            configuracion = configurarControl;
            espera = esperaControl;
        }

        // Activa la cámara para escanear códigos de barras
        public void ActivarCamara()
        {
            if (configuracion != null)
            {
                configuracion.GetSelectedVideoCaptureDevice();
                videoCaptureDevice = new VideoCaptureDevice(configuracion.GetSelectedVideoCaptureDevice());
                LeerCamara();
            }
            else
            {
                MessageBox.Show("La configuración es nula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Inicia la lectura de la cámara
        private void LeerCamara()
        {
            labelEstado.Text = "Escaneando";
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        // Manejador de eventos para cada nuevo fotograma de la cámara
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            ZXing.Windows.Compatibility.BarcodeReader reader = new ZXing.Windows.Compatibility.BarcodeReader();
            var result = reader.Decode(bitmap);

            if (result != null)
            {
                // Actualiza el estado
                labelEstado.BeginInvoke(new MethodInvoker(() =>
                {
                    labelEstado.Text = "Analizando";
                }));

                string codigo = result.Text;

                if (form.ExisteCodigo(codigo))
                {
                    labelEstado.Invoke(new MethodInvoker(() =>
                    {
                        labelEstado.Text = "Buscando";
                    }));

                    string sqlQuery = $"SELECT codigo, producto, precio FROM productos WHERE codigo='{codigo}';";
                    MySqlDataReader readerProducto = form.ObtenerDataReader(sqlQuery);

                    bool productoExistente = false;
                    foreach (DataGridViewRow row in dataGridViewVenta.Rows)
                    {
                        if (row.Cells["codigo"].Value != null && row.Cells["codigo"].Value.ToString() == codigo)
                        {
                            productoExistente = true;
                            break;
                        }
                    }

                    if (!productoExistente)
                    {
                        dataGridViewVenta.Invoke(new MethodInvoker(() =>
                        {
                            while (readerProducto.Read())
                            {
                                dataGridViewVenta.Rows.Add(readerProducto.GetString(0), readerProducto.GetString(1), readerProducto.GetDecimal(2), 1);
                            }
                        }));
                        ActualizarTotal();
                    }

                    labelEstado.Invoke(new MethodInvoker(() =>
                    {
                        labelEstado.Text = "Escaneando";
                    }));

                    readerProducto.Close();
                }
                else
                {
                    MessageBox.Show("El código no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelEstado.Invoke(new MethodInvoker(() =>
                    {
                        labelEstado.Text = "Escaneando";
                    }));
                }
            }
        }

        // Actualiza el total de la venta en la interfaz
        private void ActualizarTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewVenta.Rows)
            {
                decimal precio = Convert.ToDecimal(row.Cells["precio"].Value);
                int unidades = Convert.ToInt32(row.Cells["unidades"].Value);

                total += precio * unidades;
            }

            labelTotal.Invoke(new MethodInvoker(() =>
            {
                labelTotal.Text = total.ToString("C"); // Mostrar el total formateado como moneda
            }));
        }

        // Evento de carga del formulario
        private void VenderControl_Load(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice();
        }

        // Botón para facturar la venta
        private void buttonFacturar_Click(object sender, EventArgs e)
        {
            espera.BringToFront();

            foreach (DataGridViewRow row in dataGridViewVenta.Rows)
            {
                if (row.Cells["unidades"].Value != null && row.Cells["codigo"].Value != null)
                {
                    int unidades = Convert.ToInt32(row.Cells["unidades"].Value);
                    string codigo = row.Cells["codigo"].Value.ToString();

                    // Disminuir la cantidad de productos vendidos en la base de datos
                    string sqlQuery = $"UPDATE productos SET unidades = unidades - {unidades} WHERE codigo = '{codigo}';";
                    form.EjecutarSQLQuery(sqlQuery);
                }
            }

            MessageBox.Show($"Total a pagar {labelTotal.Text}.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataGridViewVenta.Rows.Clear();
            ActualizarTotal();

            espera.SendToBack();
        }

        // Botón para activar la cámara
        private void buttonActivar_Click(object sender, EventArgs e)
        {
            ActivarCamara();
        }

        // Maneja la eliminación de un producto de la venta
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewVenta.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewVenta.SelectedRows[0].Index;
                dataGridViewVenta.Rows.RemoveAt(rowIndex);
                ActualizarTotal();
            }
        }

        // Maneja el evento de clic derecho en la tabla de venta
        private void dataGridViewVenta_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = dataGridViewVenta.HitTest(e.X, e.Y).RowIndex;

                if (rowIndex >= 0)
                {
                    dataGridViewVenta.ClearSelection();
                    dataGridViewVenta.Rows[rowIndex].Selected = true;
                    contextMenuStripVenta.Show(dataGridViewVenta, e.Location);
                }
            }
        }

        // Desactiva la cámara
        public void DesactivarCamara()
        {
            labelEstado.Text = "En pausa";
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
            }
        }

        // Actualiza el total cuando se edita una celda en la tabla de venta
        private void dataGridViewVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarTotal();
        }
    }
}
