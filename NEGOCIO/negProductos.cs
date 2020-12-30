using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ENTIDADES;
using DAO;

namespace NEGOCIO
{
    public class negProductos
    {
        daoProductos daoProd = new daoProductos();
        public int InsertarProducto(entProducto obj)
        {
            daoProductos prod = new daoProductos();

            return prod.AgregarProducto(obj);
        }

        public static DataTable getTabla()
        {
            return daoProductos.tablaProductosClientes();
        }
        
        public int ModificarProductos(entProducto prod, int estate)
        {
            

            return daoProd.ModificarProducto(prod, estate);
        }

        public int BuscarProducto (int id)
        {
            return daoProd.BuscarStock(id);
        }
    }
}
