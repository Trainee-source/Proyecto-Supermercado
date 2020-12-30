using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ENTIDADES;

namespace DAO
{
    public class daoProductos
    {
        private string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        public int AgregarProducto(entProducto obj)
        {
            int Filas = 0;
            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("AgregarProducto", cxm);
            cmd.Connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            obj.Productonombre = UppercaseFirst(obj.Productonombre.ToLower());

            try
            {
                cmd.Parameters.AddWithValue("@NombreProducto", obj.Productonombre);
                cmd.Parameters.AddWithValue("@Stock", obj.Productostock);
                cmd.Parameters.AddWithValue("@PrecioUnitario", obj.ProductoprecioUnitario);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Productodescripcion);
                cmd.Parameters.AddWithValue("@idMarca", obj.ProductoidMarca);
                cmd.Parameters.AddWithValue("@idCategoria", obj.ProductoidCategoria);
                cmd.Parameters.AddWithValue("@ImgUrl", obj.ProductoimgUrl);

                Filas = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Filas = 0;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return Filas;
        }

        public static DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            Conexion cn = new Conexion();
            DataSet ds = new DataSet();
            SqlConnection Conexion = cn.conectar();
            SqlDataAdapter adp = new SqlDataAdapter(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public static DataTable tablaProductosClientes()
        {
            DataTable tabla = ObtenerTabla("Productos", "select IdProducto_p, NombreProducto_p, Stock_p, PrecioUnitario_p, Descripcion_p, IdMarca_p, IdCategoria_p,Imagen_p from Productos where Estado_p = 1 and Stock_p > 0");
            return tabla;
        }

        public static DataTable tablaProductosAdmin()
        {
            DataTable tabla = ObtenerTabla("Productos", "select IdProducto_p, NombreProducto_p, Stock_p, PrecioUnitario_p, Descripcion_p, IdMarca_p, IdCategoria_p,Imagen_p from Productos");
            return tabla;
        }

        public int ModificarProducto(entProducto obj, int estate)
        {

            int Filas = 0;
            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("ModificarProducto", cxm);
            cmd.Connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@nombre_p", obj.Productonombre);
                cmd.Parameters.AddWithValue("@desc_p", obj.Productodescripcion);
                cmd.Parameters.AddWithValue("@stock_p", obj.Productostock);
                cmd.Parameters.AddWithValue("@precio_p", obj.ProductoprecioUnitario);
                cmd.Parameters.AddWithValue("@cat_p", obj.ProductoidCategoria);
                cmd.Parameters.AddWithValue("@marca_p", obj.ProductoidMarca);
                cmd.Parameters.AddWithValue("@estate_p", estate);
                cmd.Parameters.AddWithValue("@id_p", obj.Productoid);
                cmd.Parameters.AddWithValue("@image", obj.ProductoimgUrl);

                Filas = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Filas = 0;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return Filas;
        }

        public int BuscarStock (int i)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int Stock = 0;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();

                cmd = new SqlCommand("select Stock_p from Productos where IdProducto_p ='" + i + "'", cnx);

                cnx.Open();

                Stock = (Int32)cmd.ExecuteScalar();
            }

            catch (Exception e)
            {

            }

            finally
            {
                cmd.Connection.Close();
            }

            return Stock;
        }
    }
}
