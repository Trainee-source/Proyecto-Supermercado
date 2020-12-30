using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPracticoFinalProgramacion3
{
    public partial class Noticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string from = Request.UrlReferrer.ToString();
            string here = Request.Url.AbsoluteUri.ToString();
            Session.Remove("usuario");

            if (from != here)
                Session["page"] = Request.UrlReferrer.ToString();
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            string from = (string)Session["page"];

            if (from.Equals("http://localhost:4356/IngresoUsuario.aspx"))
            {
                Session.Remove("page");
                Response.Redirect("Login.aspx");
            }
            else
                Response.Redirect("PaginaAdministrador.aspx");
            
        }
    }
}