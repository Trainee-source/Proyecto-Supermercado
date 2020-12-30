using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class entDetalleVenta
    {
        public int codigoDetalle { set; get; }
        public int codigoVenta { set; get; }
        public int codigoProducto { set; get; }
        public int cantidad { set; get; }
        public decimal precioUnitario { set; get; }

    }
}
