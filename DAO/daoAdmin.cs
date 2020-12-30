using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class daoAdmin
    {
        public  DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            Conexion cn = new Conexion();
            DataSet ds = new DataSet();
            SqlConnection Conexion = cn.conectar();
            SqlDataAdapter adp = new SqlDataAdapter(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }
        public  DataTable LlamarVentas ()
        {
            DataTable tabla = ObtenerTabla("Ventas", "select * from Ventas");
            return tabla;
        }

        public  DataTable LlamarMes(int i)
        {
            DataTable tabla = ObtenerTabla("Ventas", "select * from Ventas where MONTH(Fecha_v) = " + i);
            return tabla;
        }

        public DataTable LlamarTodo()
        {
            DataTable tabla = ObtenerTabla("Productos", "select * from Productos where Estado_p = 1");
            return tabla;
        }

        public  DataTable LlamarBajoStock()
        {
            DataTable tabla = ObtenerTabla("Productos", "select * from Productos where Stock_p < 100");
            return tabla;
        }

        public DataTable LlamarProductos()
        {
            DataTable tabla = ObtenerTabla("DetallesDeVenta", "	select top 5 PrecioUnitario_p,NombreProducto_p, Descripcion_p, SUM(Cantidad_dv) as Cantidad from DetallesDeVenta inner join Productos on IdProducto_dv = IdProducto_p group by IdProducto_dv, NombreProducto_p, Descripcion_p, PrecioUnitario_p");
            return tabla;
        }
        
    }
}
