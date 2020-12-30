using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ENTIDADES;
using DAO;

namespace NEGOCIO
{
    public class negAdmin
    {
        daoAdmin Admin = new daoAdmin();
        public  DataTable LlenarProductos()
        {
            return Admin.LlamarProductos();
        }
        public  DataTable LlenarStock()
        {
            return Admin.LlamarBajoStock();
        }
        public  DataTable LlenarVentas()
        {
            return Admin.LlamarVentas();
        }

        public  DataTable LlamarMer( int i)
        {
            return Admin.LlamarMes(i);
        }

        public DataTable LlamarTodo()
        {
            return Admin.LlamarTodo();
        }
    }
}
