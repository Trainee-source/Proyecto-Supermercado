using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace ENTIDADES
{
    public class entProducto
    {
        public int Productoid { set; get; }
        public String Productonombre { set; get; }
        public String Productodescripcion { set; get; }
        public decimal ProductoprecioUnitario { set; get; }
        public int Productostock { get; set; }
        public String ProductoidMarca { get; set; }
        public String ProductoidCategoria { set; get; }
        public String ProductoimgUrl { get; set; }

    }
}
