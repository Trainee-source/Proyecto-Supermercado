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
    public class daoCatxMar
    {

        public int AgregarMarcaACategoria(entCatxMar obj)
        {
            int Filas = 0;
            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("AgregarMarcaxCategoria", cxm);
            cmd.Connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Cod_marca", obj.Cod_M);
                cmd.Parameters.AddWithValue("@Cod_categoria", obj.Cod_C);

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

        public List<entCatxMar> listarCatxMar ()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<entCatxMar> lista = null;

            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ListarCatxMar", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entCatxMar>();

                while (dr.Read())
                {
                    entCatxMar c = new entCatxMar();
                    c.Cod_M = dr["IdMarca_mc"].ToString();
                    c.Cod_C = dr["IdCategoria_mc"].ToString();
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

    }
}
