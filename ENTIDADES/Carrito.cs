using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class entCarrito
    {
        public int ProductoId { set; get; }
        public string ProductoNombre { set; get; }
        public decimal ProductoPrecio { set; get; }
        public int ProductoCantidad { set; get; }
        public decimal ProductoSubtotal { set; get; }
        public string ProductoimgUrl { get; set; }

    }
}
