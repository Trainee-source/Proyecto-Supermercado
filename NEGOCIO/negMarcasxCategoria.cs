using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAO;

namespace NEGOCIO
{
    public class negMarcasxCategoria
    {
        daoCatxMar catMar = new daoCatxMar();
        public List<entCatxMar> llamarLista()
        {
            return catMar.listarCatxMar();
        }

        public int ingresarMarcaACategoria(entCatxMar obj)
        {
            return catMar.AgregarMarcaACategoria(obj);
        }
    }
}
