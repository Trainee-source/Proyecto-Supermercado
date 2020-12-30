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
    public class daoMarcas
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
        private int VerificarNombre(String nombreMarca)
        {
            int Filas = 0;
            string convierto = string.Empty;
            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("VerificarMarca", cxm);
            SqlDataReader dr = null;
            cmd.Connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            String nombre = UppercaseFirst(nombreMarca.ToLower());

            try
            {

                cmd.Parameters.AddWithValue("@Nombre", nombre);
                dr = cmd.ExecuteReader();
                dr.Read();

                convierto = dr["IdMarca_m"].ToString();

            }
            catch (Exception e)
            {
                Filas = 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            if (convierto.Equals(""))
            {
                Filas = 0;
            }
            else
                Filas = 1;

            return Filas;
        }
        public int AgregarMarca(entMarca obj)
        {
            int Filas = 0;
            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("AgregarMarca", cxm);
            cmd.Connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            String nombre = UppercaseFirst(obj.nombreMarca.ToLower());

            if (VerificarNombre(nombre) == 0)
            {
                try
                {
                    cmd.Parameters.AddWithValue("@Cod_marca", obj.codigoMarca);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
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
            }
            else
                Filas = 0;

            return Filas;
        }

       public void BuscarMarca(entMarca obj, string idMarca)
        {

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            bool activado = false;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();

                cmd = new SqlCommand("select * from Marcas where IdMarca_m ='" + idMarca+"'", cnx);

                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                obj.codigoMarca = dr["IdMarca_m"].ToString();
                obj.nombreMarca = dr["NombreMarca_m"].ToString();
                obj.activo = dr.GetBoolean(dr.GetOrdinal("Estado_m"));
            }

            catch (Exception e)
            {

            }

            finally
            {
                cmd.Connection.Close();
            }
        }

        public List<entMarca> ListarTodo()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<entMarca> lista = null;

            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ListarTodasMarcas", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entMarca>();

                while (dr.Read())
                {
                    entMarca c = new entMarca();
                    c.nombreMarca = dr["NombreMarca_m"].ToString();
                    c.codigoMarca = dr["IdMarca_m"].ToString();
                    c.activo = dr.GetBoolean(dr.GetOrdinal("Estado_m"));
                    lista.Add(c);
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
        public List<entMarca> ListarMarcas()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<entMarca> lista = null;

            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ListarMarcas", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entMarca>();

                while (dr.Read())
                {
                    entMarca c = new entMarca();
                    c.nombreMarca = dr["NombreMarca_m"].ToString();
                    c.codigoMarca = dr["IdMarca_m"].ToString();
                    lista.Add(c);
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

        public int CambiarMarca(entMarca obj, int state)
        {
            int Filas = 0;
            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("ModificarMarca", cxm);
            cmd.Connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            String nombre = UppercaseFirst(obj.nombreMarca.ToLower());

            if (VerificarNombre(nombre) == 0 || state == 0)
            {

                try
                {
                    cmd.Parameters.AddWithValue("@codigo", obj.codigoMarca);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombreMarca);
                    cmd.Parameters.AddWithValue("@estado", state);

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
            else
            {
                Filas = 0;
                return Filas;
            }
        }
    }
}
