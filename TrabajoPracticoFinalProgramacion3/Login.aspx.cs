using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ENTIDADES;
using NEGOCIO;

namespace TrabajoPracticoFinalProgramacion3
{
   
    public partial class Login : System.Web.UI.Page
    {
        negUsuarios Usu = new negUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            string from = Request.UrlReferrer.ToString();
            string here = Request.Url.AbsoluteUri.ToString();
            Session.Remove("usuario");

            if (from != here)
                Session["page"] = Request.UrlReferrer.ToString();

        }

        protected void Registrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoUsuario.aspx");
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {

            if (UsuarioEmail.Text != "" && UsuarioContraseña.Text != "")
            {
                entUsuario obj = Usu.Logear(UsuarioEmail.Text,UsuarioContraseña.Text);

                if (obj != null)
                {
                    Session["usuario"] = obj;
                    object refUrl = Session["page"];
                    if (refUrl != null)
                        Response.Redirect("PaginaPrincipal.aspx");
                }
                else
                {
                    lblError.Text = "Email o Contraseña incorrecta";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Faltan completar campos";
                lblError.Visible = true;
            }

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            object refUrl = Session["page"];
            if (refUrl != null)
                Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void btnNuevaContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarContraseña.aspx");
        }
    }
}