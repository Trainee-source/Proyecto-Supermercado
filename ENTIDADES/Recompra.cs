using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class entRecompra
        {
            public int DetalleProductoid { set; get; }
            public int DetalleVentaId { set; get; }
            public string DetalleProductoNombre { set; get; }
            public decimal DetalleProductoPrecio { set; get; }
            public int DetalleCantidad { set; get; }
            public decimal DetalleSubTotal { set; get; }
            public string DetalleProductoimgUrl { get; set; }
    }
}
