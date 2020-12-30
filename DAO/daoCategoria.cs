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
    public class daoCategoria
    {
        public List<entCategoria> ListarCategorias()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<entCategoria> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ListarCategorias", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entCategoria>();
                while (dr.Read())
                {
                    entCategoria c = new entCategoria();
                    c.nombreCategoria = dr["NombreCategoria_c"].ToString();
                    c.codigoCategoria = dr["IdCategoria_c"].ToString();
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

        public entCategoria BuscarCategoria( string categoria)
            {
                    entCategoria Cat = new entCategoria();
                     SqlCommand cmd = null;
                    SqlDataReader dr = null;
                    try
                    {
                        Conexion cn = new Conexion();
                        SqlConnection cnx = cn.conectar();

                        cmd = new SqlCommand("select * from Categorias where IdCategoria_c = " + categoria, cnx);

                        cnx.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        Cat.nombreCategoria = dr["NombreCategoria_c"].ToString();
                        Cat.codigoCategoria = dr["IdCategoria_c"].ToString();
                        Cat.activo = true;
                    }

                        catch (Exception e)
                        {

                        }

                        finally
                        {
                            cmd.Connection.Close();
                        }

                    return Cat;
            }
    }

    
}
