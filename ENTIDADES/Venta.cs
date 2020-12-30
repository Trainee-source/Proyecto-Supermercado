using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class entVenta
    {
        public int codigoVenta { get; set; }
        public string dniUsuario { get; set; }
        public string numeroTarjeta { set; get; }
        public decimal montoTotal { get; set; }
        
    }
}
