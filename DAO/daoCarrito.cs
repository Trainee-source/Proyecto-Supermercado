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
    public class daoCarrito
    {
        public DataTable CrearCarrito()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("IdVenta", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProductoId", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProductoNombre", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProductoPrecio", System.Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProductoCantidad", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProductoSubTotal", System.Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProductoImg", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            return dt;
        }


        public void AgregarCarrito(DataTable Carrito, entCarrito lb)
        {
            DataRow dr = Carrito.NewRow();
            dr["ProductoId"] = lb.ProductoId;
            dr["ProductoNombre"] = lb.ProductoNombre;
            dr["ProductoPrecio"] = lb.ProductoPrecio;
            dr["ProductoCantidad"] = lb.ProductoCantidad;
            dr["ProductoSubTotal"] = lb.ProductoPrecio * lb.ProductoCantidad;
            dr["ProductoImg"] = lb.ProductoimgUrl;
            Carrito.Rows.Add(dr);
        }

        public int MontoCarrito(DataTable Carrito)
        {
            int Monto = 0;
            for (int o = 0; o < Carrito.Rows.Count; o++)
            {
                Monto += Convert.ToInt32(Carrito.Rows[o]["ProductoSubTotal"]);
            }
            return Monto;
        }

        public void ModificarCarrito(DataTable Carrito, entCarrito lb)
        {
            for (int o = 0; o < Carrito.Rows.Count; o++)
            {
                if (Convert.ToInt32(Carrito.Rows[o]["ProductoId"]) == lb.ProductoId)
                {
                    Carrito.Rows[o]["ProductoCantidad"] = lb.ProductoCantidad;
                    Carrito.Rows[o]["ProductoSubTotal"] = lb.ProductoCantidad * lb.ProductoPrecio;
                }
            }
        }

        public  void ModificarRecompra(DataTable Carrito, entCarrito lb)
        {
            for (int o = 0; o < Carrito.Rows.Count; o++)
                {
                    if (Convert.ToInt32(Carrito.Rows[o]["ProductoId"]) == lb.ProductoId)
                    {
                        int Cant = Convert.ToInt32(Carrito.Rows[o]["ProductoCantidad"]) + lb.ProductoCantidad;
                        lb.ProductoCantidad = Cant;
                        Carrito.Rows[o]["ProductoCantidad"] = Cant;
                        Carrito.Rows[o]["ProductoSubTotal"] = lb.ProductoCantidad * lb.ProductoPrecio;
                    }
                }
        }

        public  void EliminaCarrito(DataTable Carrito, int pos)
        {
         
            Carrito.Rows.RemoveAt(pos);
            if (Carrito.Rows.Count == 0)
                Carrito = null;
        }

        public  int ContarVentas()
        {
            int Filas;
            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 IdVenta_v FROM Ventas ORDER BY IdVenta_v DESC", cxm);
            cmd.Connection.Open();

            Filas = (int)cmd.ExecuteScalar();

            return Filas;
        }

        public  int ConfirmarTarjeta (entTarjeta obj, entUsuario usu)
        {
            int Tarjetas;
            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("VerificarTarjeta", cxm);
            cmd.Connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Tarjeta", obj.TarNumeroTarjeta);
            cmd.Parameters.AddWithValue("@Dni", usu.Usuariodni);

            Tarjetas = (Int32)cmd.ExecuteScalar();

            return Tarjetas;
        }

        public  int IngresarTarjeta (entTarjeta obj, entUsuario usu)
        {
            int Filas;

            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();
            SqlCommand cmd = new SqlCommand("AgregarTarjeta", cxm);
            cmd.Connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NroTarjeta", obj.TarNumeroTarjeta);
            cmd.Parameters.AddWithValue("@Dni", usu.Usuariodni);
            cmd.Parameters.AddWithValue("@CodigoSeguridad", obj.TarCodigoSeguridad);
            cmd.Parameters.AddWithValue("@Entidad", obj.TarNombreTarjeta);

            Filas = cmd.ExecuteNonQuery();

            return Filas;
        }

        public  DataTable CrearTabla ()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("IdVenta", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProductoId", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProductoCantidad", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProductoSubTotal", System.Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);

            return dt;
        }

        public void AgregarDetalle(DataTable Carrito, entUsuario obj)
        {
            int Filas = ContarVentas();
            DataTable dt = CrearTabla();
            Conexion che = new Conexion();
            SqlConnection cm = che.conectar();

            SqlCommand vn= new SqlCommand();

            for (int h = 0; h < Carrito.Rows.Count; h++)
            {
                vn = new SqlCommand("AgregarDetalles", cm);
                vn.Connection.Open();
                vn.CommandType = CommandType.StoredProcedure;
                vn.Parameters.AddWithValue("@IdVenta", Filas);
                vn.Parameters.AddWithValue("@ProductoId", Carrito.Rows[h]["ProductoId"]);
                vn.Parameters.AddWithValue("@ProductoCantidad", Carrito.Rows[h]["ProductoCantidad"]);
                vn.Parameters.AddWithValue("@ProductoSubTotal", Carrito.Rows[h]["ProductoSubTotal"]);
                vn.ExecuteNonQuery();
                vn.Connection.Close();
            }
            

        }

        public  void AgregarVenta(DataTable Carrito, entUsuario obj, entTarjeta tar)
        {
            decimal Monto = 0;

            Conexion con = new Conexion();
            SqlConnection cxm = con.conectar();

            SqlCommand cmd = new SqlCommand("AgregarVenta", cxm);
            cmd.Connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;


            if ( !string.IsNullOrEmpty(tar.TarNumeroTarjeta))
            {
                if (ConfirmarTarjeta(tar, obj) == 0 )
                {
                    IngresarTarjeta(tar, obj);
                }
            }

                for (int o = 0; o < Carrito.Rows.Count; o++)
                {
                    Monto += Convert.ToDecimal(Carrito.Rows[o]["ProductoSubTotal"]);
                }
                cmd.Parameters.AddWithValue("@Dni", obj.Usuariodni);
                cmd.Parameters.AddWithValue("@Tarjeta", tar.TarNumeroTarjeta);
                cmd.Parameters.AddWithValue("@Domicilio", tar.TarDireccion);
                cmd.Parameters.AddWithValue("@Monto", Monto);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            
        }
    }
}
