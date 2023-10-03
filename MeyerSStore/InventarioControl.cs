using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MeyerSStore
{
    public partial class InventarioControl : UserControl
    {
        private Form1 form;

        public InventarioControl(Form1 form1)
        {
            InitializeComponent();
            form = form1;
        }

        public void GetAllProductos()
        {
            string sqlQuery = "SELECT codigo, producto, precio, unidades FROM productos;";
            MySqlDataReader reader = form.ObtenerDataReader(sqlQuery);

            if (dataGridViewProductos.InvokeRequired)
            {
                // Si estamos en un hilo diferente al de la UI, invocamos la operación en el hilo de la UI.
                dataGridViewProductos.Invoke(new MethodInvoker(() =>
                {
                    dataGridViewProductos.Rows.Clear();
                    while (reader.Read())
                    {
                        dataGridViewProductos.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3));
                    }
                }));
            }
            else
            {
                dataGridViewProductos.Rows.Clear();
                while (reader.Read())
                {
                    dataGridViewProductos.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3));
                }
            }

            reader.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string nombreProducto = textBoxBuscar.Text;
            string sqlQuery = $"SELECT codigo, producto, precio, unidades FROM productos WHERE producto LIKE '%{nombreProducto}%';";
            MySqlDataReader reader = form.ObtenerDataReader(sqlQuery);

            dataGridViewProductos.Rows.Clear();
            while (reader.Read())
            {
                dataGridViewProductos.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3));
            }

            reader.Close();
        }

        private void buttonResetear_Click(object sender, EventArgs e)
        {
            textBoxBuscar.Text = "";
            GetAllProductos();
        }

        private void ActualizarBD(string nuevoValor, int rowIndex, int columnIndex)
        {
            string codigo = dataGridViewProductos.Rows[rowIndex].Cells["codigo"].Value.ToString();
            string columna = dataGridViewProductos.Columns[columnIndex].Name;

            string sqlQuery = $"UPDATE productos SET {columna}='{nuevoValor}' WHERE codigo='{codigo}'";

            form.EjecutarSQLQuery(sqlQuery);
        }

        private void dataGridViewProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nuevoValor = dataGridViewProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            ActualizarBD(nuevoValor, e.RowIndex, e.ColumnIndex);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewProductos.SelectedRows[0].Index;
                string codigo = dataGridViewProductos.Rows[rowIndex].Cells["codigo"].Value.ToString();
                dataGridViewProductos.Rows.RemoveAt(rowIndex);

                string sqlQuery = $"DELETE FROM productos WHERE codigo='{codigo}'";

                form.EjecutarSQLQuery(sqlQuery, "Se ha eliminado el producto");
            }
        }

        private void dataGridViewProductos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = dataGridViewProductos.HitTest(e.X, e.Y).RowIndex;

                if (rowIndex >= 0)
                {
                    // Se hizo clic derecho en una fila válida
                    dataGridViewProductos.ClearSelection();
                    dataGridViewProductos.Rows[rowIndex].Selected = true;
                    contextMenuStrip1.Show(dataGridViewProductos, e.Location);
                }
            }
        }
    }
}
