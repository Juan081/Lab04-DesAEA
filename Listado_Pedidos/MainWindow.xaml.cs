using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
namespace Listado_Clientes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string connectionString = "Data Source=LAB1504-25\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=diego;Password=hola123";
        public MainWindow()
        {
            InitializeComponent();
            String NombreCompañia = new String("Gourmet Lanchonetes"); // Cambia esta fecha según tus necesidades
            String Direccion = new String("Av. Brasil, 442"); // Cambia esta fecha según tus necesidades

            Clientes clientes = ListarClientes(NombreCompañia, Direccion);

            // Asigna la lista de detalles de cliente a tu DataGrid
            McDataGrid.ItemsSource = clientes.Detalles;
        }
        private static Clientes ListarClientes(String NombreCompañia, String Direccion)
        {
            Clientes clientes = new Clientes();
            clientes.NombreCompañia = "nombrecompañia";
            clientes.Direccion = "direccion";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "usp_ListarDetallesClientes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreCompañia", "nombrecompañia");
                    command.Parameters.AddWithValue("@Direccion", "direccion");
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                DetalleCliente detalle = new DetalleCliente
                                {
                                    idCliente = reader.GetString(reader.GetOrdinal("idcliente")),
                                    NombreCompañia = reader.GetString(reader.GetOrdinal("nombrecompañia")),
                                    NombreContacto = reader.GetString(reader.GetOrdinal("nombrecontacto")),
                                    CargoContacto = reader.GetString(reader.GetOrdinal("cargocontacto")),
                                    Direccion = reader.GetString(reader.GetOrdinal("direccion")),
                                    Ciudad = reader.GetString(reader.GetOrdinal("ciudad")),
                                    Region = reader.GetString(reader.GetOrdinal("region")),
                                    CodPostal = reader.GetString(reader.GetOrdinal("codpostal")),
                                    Pais = reader.GetString(reader.GetOrdinal("pais")),
                                    Telefono = reader.GetString(reader.GetOrdinal("telefono")),
                                    Fax = reader.GetString(reader.GetOrdinal("fax"))
                                };
                                clientes.Detalles.Add(detalle);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return clientes;
        }
    }
}