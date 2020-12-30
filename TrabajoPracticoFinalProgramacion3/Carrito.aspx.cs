using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;
using NEGOCIO;

namespace TrabajoPracticoFinalProgramacion3
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActualizarCarrito();
            GridCompra.RowCommand += new GridViewCommandEventHandler(GridCompra_RowCommand);
            if (this.Session["cesta"] != null)
            {
                Label1.Text = getPrecio();
            }
            else
            {
                Label1.Text = "El Carrito esta Vacio";
            }
            
        }

        public string getPrecio()
        {
            DataTable compra = new DataTable();
            compra = (DataTable)this.Session["cesta"];
            decimal Costo = 0;
            string Coste = string.Empty;

            for (int i = 0; i < compra.Rows.Count; i++)
            {
                Costo += Convert.ToDecimal(compra.Rows[i]["ProductoSubTotal"]);
            }

            return Coste = "$ " + Costo.ToString();
        }
        private void ActualizarCarrito()
        {
            GridCompra.DataSource = (DataTable)this.Session["cesta"];
            GridCompra.DataBind();
            Label1.Text = getPrecio();
        }

        protected void GridCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int pos = int.Parse(e.CommandArgument.ToString());
                negCarrito gc = new negCarrito();
                gc.EliminaCarrito((DataTable)this.Session["cesta"], pos);
                ActualizarCarrito();
            }

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            negCarrito g = new negCarrito();
            entUsuario usu = new entUsuario();
            usu = (entUsuario)this.Session["usuario"];

            if (this.Session["cesta"] == null)
            {
                Response.Redirect("ListaProductos.aspx");
            }

            if (this.Session["usuario"] != null)
            {
                if (this.Session["cesta"] != null)
                {
                    Response.Redirect("ConfirmarCompra.aspx");
                }
                else
                    Response.Redirect("ListaProductos.aspx");
            }
            else Response.Redirect("Login.aspx");
        }
    }
}