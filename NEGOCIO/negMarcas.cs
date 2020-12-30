using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAO;

namespace NEGOCIO
{
    public class negMarcas
    {
        daoMarcas mar = new daoMarcas();
        public List<entMarca> ListarMarcas()
        {
            return mar.ListarMarcas();
        }

        public List<entMarca> ListarTodo()
        {
            return mar.ListarTodo();
        }

        public int AgregarMarca(entMarca obj)
        {
            return mar.AgregarMarca(obj);
        }

        public void BuscarMarca(entMarca obj, string idMarca)
        {
            mar.BuscarMarca(obj, idMarca);
        }

        public int ModificarMarca(entMarca obj, int estado)
        {
            return mar.CambiarMarca(obj, estado);
        }
    }
}
