using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listado_Clientes
{
    public class DetalleCliente
    {
        public string idCliente { get; set; }
        public string NombreCompañia { get; set; }
        public string NombreContacto { get; set; }
        public string CargoContacto { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string CodPostal { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
    }

    public class Clientes
    {
        public String NombreCompañia { get; set; }
        public String Direccion { get; set; }
        public List<DetalleCliente> Detalles { get; set; }

        public Clientes()
        {
            Detalles = new List<DetalleCliente>();
        }
    }
}
