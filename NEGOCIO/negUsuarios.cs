using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using ENTIDADES;

namespace NEGOCIO
{
    public class negUsuarios
    {
        daoUsuarios Usu = new daoUsuarios();
        public  int InsertarUsuario(entUsuario obj)
        {
            return Usu.AgregarUsuario(obj);
        }

        public int CambiarContraseña(entUsuario obj)
        {
            return Usu.CambiarContraseña(obj);
        }

        public  entUsuario Logear(String Email, String Password)
        {
            return Usu.Login(Email, Password);
        }

        public  DataTable CrearRecompra()
        {
            return Usu.CrearReventa();
        }

        public  void LlenarTabla(DataTable Carro, entUsuario obj)
        {
                    Usu.TablaReventas(Carro, obj);
        }

        public  List<Int32> ListarVentas(entUsuario obj)
        {
            return Usu.ListarVentas(obj);
        }

        public int EditarPerfil(entUsuario nuevoUsuario, string dni)
        {
            return Usu.EditarPerfil(nuevoUsuario, dni);
        }


    }
}
