using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeyerSStore
{
    public partial class Form1 : Form
    {
        private UserControl controlActual = null;

        public Form1()
        {
            InitializeComponent();
            InicializarControles();
        }

        private void InicializarControles()
        {
            panelCursor.Height = buttonVender.Height;
            controlActual = vender;

            // Mostrar el UserControl 'vender' al inicio
            vender.BringToFront();
        }

        // Ejecuta una consulta SQL y muestra un mensaje opcional
        public void EjecutarSQLQuery(string sqlQuery, string mensaje = null)
        {
            using (MySqlConnection conexionBD = Conexion.conexion())
            {
                try
                {
                    conexionBD.Open();
                    MySqlCommand comando = new MySqlCommand(sqlQuery, conexionBD);
                    comando.ExecuteNonQuery();

                    if (mensaje != null)
                    {
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Verifica si un código existe en la base de datos
        public bool ExisteCodigo(string codigo)
        {
            string sqlQuery = $"SELECT codigo FROM productos WHERE codigo='{codigo}';";

            using (MySqlConnection conexionBD = Conexion.conexion())
            {
                try
                {
                    conexionBD.Open();
                    MySqlCommand comando = new MySqlCommand(sqlQuery, conexionBD);
                    var result = comando.ExecuteScalar();

                    return result != null; // Devuelve true si el resultado no es nulo, false de lo contrario
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al verificar la existencia del código: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Obtiene un lector de datos para una consulta SQL
        public MySqlDataReader ObtenerDataReader(string sqlQuery)
        {
            MySqlConnection conexionBD = Conexion.conexion();
            try
            {
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sqlQuery, conexionBD);
                return comando.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al obtener el lector de datos: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("Saliendo");
        }

        private void CambiarUserControl(UserControl nuevoControl)
        {
            if (controlActual == vender)
            {
                vender.DesactivarCamara();
            }
            else if (controlActual == agregar)
            {
                agregar.DetenerCamara();
            }

            controlActual = nuevoControl;
            nuevoControl.BringToFront();
        }

        private async void buttonVender_Click(object sender, EventArgs e)
        {
            CambiarUserControl(vender);
            panelCursor.Top = buttonVender.Top;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CambiarUserControl(agregar);
            panelCursor.Top = buttonAgregar.Top;
            agregar.ActivarCamara();
        }

        private async void buttonInventario_Click(object sender, EventArgs e)
        {
            CambiarUserControl(inventario);
            panelCursor.Top = buttonInventario.Top;
            esperaControl.BringToFront();

            await Task.Run(() =>
            {
                inventario.GetAllProductos();
            });

            inventario.BringToFront();
        }

        private void buttonConfigurar_Click(object sender, EventArgs e)
        {
            CambiarUserControl(configurarControl);
            panelCursor.Top = buttonConfigurar.Top;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            panelCursor.Top = buttonSalir.Top;
            agregar.DetenerCamara();
            vender.DesactivarCamara();
            Application.Exit();
        }
    }
}
