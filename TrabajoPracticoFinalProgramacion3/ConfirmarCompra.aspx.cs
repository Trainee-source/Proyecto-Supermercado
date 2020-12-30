using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ENTIDADES;
using NEGOCIO;

namespace TrabajoPracticoFinalProgramacion3
{
    public partial class ConfirmarCompra : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {   DataTable obh = (DataTable)this.Session["cesta"];
                MultiView1.ActiveViewIndex = 0;
            }
                
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex != -1)
            {
                if (Convert.ToInt32(RadioButtonList1.SelectedValue) == 2)
                {
                    MultiView1.ActiveViewIndex = 1;
                    lblError1.Visible = false;
                    lblErrorDireccion.Visible = false;
                }
                else
                {
                    if (boxDireccion.Text != "")
                    {
                        MultiView1.ActiveViewIndex = 1;
                        lblError1.Visible = false;
                        lblErrorDireccion.Visible = false;
                    }
                    else
                        lblErrorDireccion.Visible = true;
                }
            }
            else
                lblError1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           if (Convert.ToInt32(RadioButtonList2.SelectedValue) == 1 )
            {
                TerminarCompra();
                MultiView1.ActiveViewIndex = 3;
            }
           else
                MultiView1.ActiveViewIndex = 2;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (RadioButtonList3.SelectedIndex != -1)
            {
                if (boxTarjetanro.Text != "" && boxTarjetaSeg.Text != "")
                {
                    lblCampos.Visible = false;
                    TerminarCompra();
                    MultiView1.ActiveViewIndex = 3;
                }
                else
                {
                    lblCampos.Visible = true;
                    if (boxTarjetanro.Text != "")
                    {
                        lblTarjeta.Visible = false;
                    }
                    else
                        lblTarjeta.Visible = true;
                    if (boxTarjetaSeg.Text != "")
                    {
                        lblSeguridad.Visible = false;
                    }
                    else
                        lblSeguridad.Visible = true;
                }
            }
            else
            {
                lblError3.Visible = true;
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (RadioButtonList1.SelectedIndex != -1)
            {
                if (Convert.ToInt32(RadioButtonList1.SelectedValue) == 1)
                {
                    lblDireccion.Visible = true;
                    boxDireccion.Visible = true;
                }
                else
                {
                    lblDireccion.Visible = false;
                    boxDireccion.Visible = false;
                }
            }
        }

        public void TerminarCompra ()
        {
            entTarjeta obj = new entTarjeta();
            entUsuario usu = new entUsuario();
            usu = (entUsuario)this.Session["usuario"];

            obj.TarDireccion = boxDireccion.Text;
            obj.TarNombreTarjeta = RadioButtonList3.SelectedValue;
            obj.TarNumeroTarjeta = boxTarjetanro.Text;
            obj.TarCodigoSeguridad = boxTarjetaSeg.Text;

            negCarrito g = new negCarrito();

            g.ConfirmarCompra((DataTable)this.Session["cesta"], usu, obj);
            Session.Remove("cesta");
            Session.Remove("carrito");
        }
    }
}