using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;
using NEGOCIO;

namespace TrabajoPracticoFinalProgramacion3
{
    public partial class Placa : System.Web.UI.MasterPage
    {
        
        public ImageButton SearchButton
        {
            get
            {
                return this.Search;
            }
        }
        public String textoProducto
        {
            get
                {
                    return this.TextBox1.Text;
                }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            entUsuario us = (entUsuario)Session["usuario"];
            negCategorias cat = new negCategorias();
            if (us != null)
            {
                usuarioNombre.Text = us.UsuarioNombre + " " + us.UsuarioApellidos;
                logoutbttn.Visible = true;
                if (us.UsuarioAdmin == 1)
                {
                    BotonCarrito.Visible = false;
                    BotonRecompra.Visible = false;

                }
            }
            
        }

        protected void BotonRegistro_Click(object sender, ImageClickEventArgs e)
        {
            entUsuario us = (entUsuario)Session["usuario"];
            if (us != null)
            {
                if (us.UsuarioAdmin == 1)
                {
                    Response.Redirect("PaginaAdministrador.aspx");
                }
                else
                Response.Redirect("PaginaUsuario.aspx");
            }
            else
            Response.Redirect("Login.aspx");
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void logoutbttn_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Session.Remove("recompra");
            Session.Remove("carrito");
            Session.Remove("cesta");
            usuarioNombre.Text = "";
            logoutbttn.Visible = false;
            Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void Search_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(@"~/ListaProductos.aspx?q=" + Server.UrlEncode(TextBox1.Text));
        }

        protected void BotonCarrito_Click(object sender, ImageClickEventArgs e)
        {
            entUsuario obj = (entUsuario)this.Session["usuario"];

            if (obj != null)

            {

                if (obj.UsuarioAdmin != 1)
                {
                    Response.Redirect("PaginaUsuario.aspx");
                }
                else
                    Response.Redirect("PaginaAdministrador.aspx");
            }
            else
                Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void BotonRecompra_Click(object sender, ImageClickEventArgs e)
        {
            if (this.Session["cesta"] != null)
                Response.Redirect("Carrito.aspx");

            else
                Response.Redirect("ListaProductos.aspx");
        }
    }
}