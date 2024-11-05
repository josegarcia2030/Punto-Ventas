using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_PuntoDeVentas.Views
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : UserControl
    {
        public Usuarios()
        {
            InitializeComponent();
            CargarDatos();
        }
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);
        void CargarDatos()
        {
            conexion.Open();
            string query = "Select IdUsuario, Nombres, Apellidos, Telefono, correo, NombrePrivilegio from Usuarios inner join Privilegios on Usuarios.Privilegio=Privilegios.IdPrivilegio order by IdUsuario ASC";
            SqlCommand comandos = new SqlCommand(query, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comandos);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            GridDatos.ItemsSource = tabla.DefaultView;
            conexion.Close();
        }
        private void Agregar(object sender, RoutedEventArgs e)
        {
            CRUDUsuarios ventana = new CRUDUsuarios();
            FrameUsuarios.Content = ventana;
        }
    }
}
