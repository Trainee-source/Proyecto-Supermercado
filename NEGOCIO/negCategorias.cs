using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAO;

namespace NEGOCIO
{
    public class negCategorias
    {
        daoCategoria Cat = new daoCategoria();

        public List<entCategoria> ListarCategorias()
        {

            return Cat.ListarCategorias();
        }

        public entCategoria BuscarCategoria(  string cat)
        {
            return Cat.BuscarCategoria( cat);
        }
    }
}
