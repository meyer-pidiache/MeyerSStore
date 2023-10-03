using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace MeyerSStore
{
    public partial class AgregarControl : UserControl
    {
        private Form1 form;
        private ConfigurarControl configuracion;
        private EsperaControl espera;
        private VideoCaptureDevice videoCaptureDevice;

        public AgregarControl(Form1 form1, ConfigurarControl configurar, EsperaControl esperaControl)
        {
            InitializeComponent();
            form = form1;
            configuracion = configurar;
            espera = esperaControl;
        }

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

        private void LeerCamara()
        {
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            ZXing.Windows.Compatibility.BarcodeReader reader = new ZXing.Windows.Compatibility.BarcodeReader();
            var result = reader.Decode(bitmap);

            if (result != null)
            {
                numericUpDownCodigo.BeginInvoke(new MethodInvoker(delegate ()
                {
                    numericUpDownCodigo.Text = result.Text;
                    DetenerCamara();
                }));
            }

            if (pictureBoxCamaraAgregar.Width > 0 && pictureBoxCamaraAgregar.Height > 0)
            {
                bitmap = configuracion.ResizeImage(bitmap, pictureBoxCamaraAgregar.Width, pictureBoxCamaraAgregar.Height);
            }

            pictureBoxCamaraAgregar.Image = bitmap;
        }

        private void AgregarControl_Load(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private async void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxProducto.Text) ||
                numericUpDownCodigo.Value == 0 ||
                numericUpDownPrecio.Value == 0 ||
                numericUpDownUnidades.Value == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos antes de agregar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            espera.BringToFront();

            await Task.Run(() =>
            {
                string codigo = numericUpDownCodigo.Value.ToString();
                string producto = textBoxProducto.Text;
                string precio = numericUpDownPrecio.Value.ToString();
                string unidades = numericUpDownUnidades.Value.ToString();

                string sqlQuery = $"INSERT INTO productos (codigo, producto, precio, unidades) VALUES ('{codigo}', '{producto}', '{precio}', '{unidades}');";

                form.EjecutarSQLQuery(sqlQuery, "Se ha agregado exitosamente el producto");
            });

            numericUpDownCodigo.Value = 0;
            textBoxProducto.Text = "";
            numericUpDownPrecio.Value = 0;
            numericUpDownUnidades.Value = 0;
            this.BringToFront();

            LeerCamara();
        }

        public async void DetenerCamara()
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                await Task.Run(() =>
                {
                    videoCaptureDevice.SignalToStop();
                });
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            numericUpDownCodigo.Value = 0;
            LeerCamara();
        }
    }
}
