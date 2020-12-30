using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class entUsuario
    {
        public String Usuariodni { get; set; }
        public String UsuarioNombre { get; set; }
        public String UsuarioApellidos { get; set; }
        public String UsuarioContraseña { set; get; }
        public String UsuarioMail { set; get; }
        public Int32 UsuarioAdmin { set; get; }

    }
}
