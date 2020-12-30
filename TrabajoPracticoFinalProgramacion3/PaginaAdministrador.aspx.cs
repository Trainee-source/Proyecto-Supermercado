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
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        negAdmin negocio = new negAdmin();
        DataView vista = new DataView(negProductos.getTabla());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Grilla.ActiveViewIndex = 0;
                btnEditarProductos.CssClass = "Initial";
                btnAgregarProducto.CssClass = "Clicked";
                btnReportes.CssClass = "Clicked";
                btnStock.CssClass = "Clicked";
                btnProductos.CssClass = "Clicked";
                btnMarcas.CssClass = "Clicked";

                GridView1.DataSource = negocio.LlamarTodo();
                GridView1.DataBind();

                GridProductos.DataSource = negocio.LlenarProductos();
                GridProductos.DataBind();

                GridVentas.DataSource = negocio.LlenarVentas();
                GridVentas.DataBind();

                GridStock.DataSource = negocio.LlenarStock();
                GridStock.DataBind();

                CargarFechas();
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoProductos.aspx");
        }

        protected void btnEditarProductos_Click(object sender, EventArgs e)
        {
            Grilla.ActiveViewIndex = 0;
            btnStock.CssClass = "Clicked";
            btnReportes.CssClass = "Clicked";
            btnAgregarProducto.CssClass = "Clicked";
            btnEditarProductos.CssClass = "Initial";
            btnProductos.CssClass = "Clicked";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                int pos = int.Parse(e.CommandArgument.ToString());
                DataTable comp = new DataTable();

                int id = int.Parse(GridView1.Rows[pos].Cells[1].Text);

                vista.RowFilter = "IdProducto_p =" + id;

                comp = vista.ToTable();

                entProducto obj = new entProducto();

                obj.Productoid = Convert.ToInt32(comp.Rows[0]["IdProducto_p"]);
                obj.Productonombre = comp.Rows[0]["NombreProducto_p"].ToString();
                obj.Productodescripcion = comp.Rows[0]["Descripcion_p"].ToString();
                obj.ProductoprecioUnitario = Convert.ToDecimal(comp.Rows[0]["PrecioUnitario_p"]);
                obj.Productostock = Convert.ToInt32(comp.Rows[0]["Stock_p"]);
                obj.ProductoimgUrl = comp.Rows[0]["Imagen_p"].ToString();
                obj.ProductoidMarca = comp.Rows[0]["IdMarca_p"].ToString();
                obj.ProductoidCategoria = comp.Rows[0]["IdCategoria_p"].ToString();
                

                Session["producto"] = obj;
                
                Response.Redirect("EditarProducto.aspx");

            }

        }

        protected void btnReportes_Click(object sender, EventArgs e)
        {
            Grilla.ActiveViewIndex = 1;
            btnStock.CssClass = "Clicked";
            btnReportes.CssClass = "Initial";
            btnAgregarProducto.CssClass = "Clicked";
            btnEditarProductos.CssClass = "Clicked";
            btnProductos.CssClass = "Clicked";
        }

        public void CargarFechas()
        {
            ListaFechas.Items.Add(new ListItem("Seleccione un mes para ver sus ventas", "0"));
            ListaFechas.Items.Add(new ListItem("Enero", "1"));
            ListaFechas.Items.Add(new ListItem("Febrero", "2"));
            ListaFechas.Items.Add(new ListItem("Marzo", "3"));
            ListaFechas.Items.Add(new ListItem("Abril", "4"));
            ListaFechas.Items.Add(new ListItem("Mayo", "5"));
            ListaFechas.Items.Add(new ListItem("Junio", "6"));
            ListaFechas.Items.Add(new ListItem("Julio", "7"));
            ListaFechas.Items.Add(new ListItem("Agosto", "8"));
            ListaFechas.Items.Add(new ListItem("Septiembre", "9"));
            ListaFechas.Items.Add(new ListItem("Octubre", "10"));
            ListaFechas.Items.Add(new ListItem("Noviembre", "11"));
            ListaFechas.Items.Add(new ListItem("Diciembre", "12"));

        }

        protected void ListaFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable net = new DataTable();
            
            int total = 0;

            if (Convert.ToInt32(ListaFechas.SelectedValue) != 0)
            {
                net = negocio.LlamarMer(Convert.ToInt32(ListaFechas.SelectedValue));
                GridVentas.DataSource = net;
                GridVentas.DataBind();
            }
            else
            {
                net = negocio.LlenarVentas();
                GridVentas.DataSource = net;
                GridVentas.DataBind();
            }

            for (int i = 0; i < net.Rows.Count; i ++)
            {
                total += Convert.ToInt32(net.Rows[i]["Monto_v"]);
            }

            lblTotalVentas.Text = "Monto total de Ventas = $ " + total;
            
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Grilla.ActiveViewIndex = 2;
            btnStock.CssClass = "Clicked";
            btnReportes.CssClass = "Clicked";
            btnAgregarProducto.CssClass = "Clicked";
            btnEditarProductos.CssClass = "Clicked";
            btnProductos.CssClass = "Initial";
        }

        protected void btnStock_Click(object sender, EventArgs e)
        {
            Grilla.ActiveViewIndex = 3;
            btnStock.CssClass = "Initial";
            btnReportes.CssClass = "Clicked";
            btnAgregarProducto.CssClass = "Clicked";
            btnEditarProductos.CssClass = "Clicked";
            btnProductos.CssClass = "Clicked";
        }

        protected void btnMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarMarcas.aspx");
        }
    }
}