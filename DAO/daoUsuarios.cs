using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ENTIDADES; 

namespace DAO
{
    public class daoUsuarios
    {
        public int AgregarUsuario(entUsuario obj)
        {
            int Filas = 0;
            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("AgregarUsuario", cxm);
            cmd.Connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@DniUsuario_u", obj.Usuariodni);
                cmd.Parameters.AddWithValue("@Nombre_u", obj.UsuarioNombre);
                cmd.Parameters.AddWithValue("@Apellidos_u", obj.UsuarioApellidos);
                cmd.Parameters.AddWithValue("@Mail_u", obj.UsuarioMail);
                cmd.Parameters.AddWithValue("@Contraseña_u", obj.UsuarioContraseña);

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

        public int CambiarContraseña(entUsuario obj)
        {
            int  estado = 1;

            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("CambiarContraseña", cxm);
            cmd.Connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Dni", obj.Usuariodni);
                cmd.Parameters.AddWithValue("@Mail", obj.UsuarioMail);
                cmd.Parameters.AddWithValue("@Contraseña", obj.UsuarioContraseña);

                estado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                estado = 0;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return estado;
        }



        public entUsuario Login(String usuario, String password)
        {
            entUsuario obj = new entUsuario();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
         
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("VerificarUsuario", cnx);

                cmd.Parameters.AddWithValue("@Email", usuario);
                cmd.Parameters.AddWithValue("@Password", password);

                cmd.CommandType = CommandType.StoredProcedure;

                cnx.Open();
                dr = cmd.ExecuteReader();
                
                dr.Read();

                obj.UsuarioNombre = dr["Nombre_u"].ToString();
                obj.UsuarioApellidos = dr["Apellidos_u"].ToString();
                obj.Usuariodni = dr["DniUsuario_u"].ToString();
                obj.UsuarioAdmin = Convert.ToInt32(dr["UsuarioAdmin_u"]);
                obj.UsuarioMail = usuario;
                Console.WriteLine(obj.UsuarioNombre);
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return obj;
        }

        public DataTable CrearReventa()
        {

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("DetalleVentaId", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("DetalleProductoid", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("DetalleProductoNombre", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("DetalleProductoPrecio", System.Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            dc = new DataColumn("DetalleCantidad", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("DetalleSubTotal", System.Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            dc = new DataColumn("DetalleProductoimgUrl", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            return dt;

        }
        public void TablaReventas(DataTable Carrito, entUsuario obj)
        {

            DataTable traspaso = new DataTable();

            Conexion conexion = new Conexion();
            SqlConnection conn = conexion.conectar();
    
            SqlCommand sqlComm = new SqlCommand("ListarReventa", conn);

            sqlComm.Parameters.AddWithValue("@Dni", obj.Usuariodni);

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Connection.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;

            da.Fill(Carrito);

            sqlComm.Connection.Close();

            
        }

        public List<Int32> ListarVentas(entUsuario obj)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Int32> lista = new List<Int32>();

            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("Select IdVenta_v from Ventas where DniUsuario_v = " + obj.Usuariodni, cnx);

                cnx.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int i = Convert.ToInt32(dr["IdVenta_v"]);
                    lista.Add(i);
                }

            }
            catch (Exception e)
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public void AgregarReventa(DataTable Recompra, DataTable Carrito)
        {
            

            for (int i = 0; i < Recompra.Rows.Count; i ++)
            {

                DataRow dr = Carrito.NewRow();

                dr["ProductoId"] = Recompra.Rows[i]["DetalleProductoid"];
                dr["ProductoNombre"] = Recompra.Rows[i]["DetalleProductoNombre"];
                dr["ProductoPrecio"] = Recompra.Rows[i]["DetalleProductoPrecio"];
                dr["ProductoCantidad"] = Recompra.Rows[i]["DetalleCantidad"];
                dr["ProductoSubTotal"] = Recompra.Rows[i]["DetalleSubTotal"];
                dr["ProductoImg"] = Recompra.Rows[i]["DetalleProductoimgUrl"];

                Carrito.Rows.Add(dr);

            }

        }

        public int EditarPerfil(entUsuario nuevoUsu, string dni)
        {
            int Filas = 0;
            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("ModificarUsuario", cxm);
            cmd.Connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Nombre_u", nuevoUsu.UsuarioNombre);
                cmd.Parameters.AddWithValue("@Apellidos_u", nuevoUsu.UsuarioApellidos);
                cmd.Parameters.AddWithValue("@Mail_u", nuevoUsu.UsuarioMail);
                cmd.Parameters.AddWithValue("@Dni", dni);

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

        
    }
}
