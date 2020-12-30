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
    public partial class Formulario_web14 : System.Web.UI.Page
    {

        negUsuarios Usuarios = new negUsuarios();
        negCarrito Carrito = new negCarrito();

        private void ActualizaCarrito()
        {

            GridView1.DataSource = (DataTable)this.Session["carrito"];
            GridView1.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.RowCommand += new GridViewCommandEventHandler(GridView1_RowCommand);

            if (this.Session["usuario"] == null)
            {
                Response.Redirect("PaginaPrincipal.aspx");
            }

            if (this.Session["recompra"]== null)
            {
                negUsuarios gc = new negUsuarios();
                this.Session["recompra"] = Usuarios.CrearRecompra();
            }

            if (this.Session["carrito"] == null)
                this.Session["carrito"] = Carrito.CrearCarrito();

            if (!this.IsPostBack)
            {
                btnCompras.CssClass = "Clicked";
                btnPerfil.CssClass = "Initial";

                entUsuario teg = (entUsuario)this.Session["usuario"];
                lblNombre.Text = "Nombre: " + teg.UsuarioNombre;
                lblApellido.Text = "Apellidos: " + teg.UsuarioApellidos;
                lblDni.Text = "DNI: " + teg.Usuariodni;
                lblEmail.Text = "Email: " + teg.UsuarioMail;


                Usuarios.LlenarTabla((DataTable)this.Session["recompra"], (entUsuario)this.Session["usuario"]);
                MultiView1.ActiveViewIndex = 1;

                ListItem item1 = new ListItem("Seleccione una venta");
                ListaFechaVenta.Items.Add(item1);

                List<Int32> lista = Usuarios.ListarVentas((entUsuario)this.Session["usuario"]);
                int i = 0;

                foreach (Int32 obj in lista)
                {
                    i++;
                    ListItem item = new ListItem("Venta Nro " + i, obj.ToString());
                    ListaFechaVenta.Items.Add(item);
                    
                }

            }
            
        }
        protected void btnCompras_Click(object sender, EventArgs e)
        {
            btnCompras.CssClass = "Initial";
            btnPerfil.CssClass = "Clicked";
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            btnCompras.CssClass = "Clicked";
            btnPerfil.CssClass = "Initial";
            MultiView1.ActiveViewIndex = 1;
        }

        protected void ListaFechaVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            Usuarios.LlenarTabla(dt, (entUsuario)this.Session["usuario"]);

            DataView vista = new DataView(dt);
            string filtro = string.Empty;
            if (Convert.ToInt32(ListaFechaVenta.SelectedValue) != -1)
            {
                filtro += "IdVenta_dv = " + ListaFechaVenta.SelectedValue;
                vista.RowFilter = filtro;
            }
            
            GridRecompras.DataSource = vista;
            GridRecompras.DataBind();
        }

        protected void BotonRecompra_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ListaFechaVenta.SelectedValue) != -1)
            {
                

                entCarrito obj = new entCarrito();

                DataTable dt = new DataTable();

                negCarrito gc = new negCarrito();

                Usuarios.LlenarTabla(dt, (entUsuario)this.Session["usuario"]);

                DataView vista = new DataView(dt);

                string filtro = string.Empty;

                if (Convert.ToInt32(ListaFechaVenta.SelectedValue) != -1)
                {
                    filtro += "IdVenta_dv = " + ListaFechaVenta.SelectedValue;
                    vista.RowFilter = filtro;
                }

                dt = vista.ToTable();

                DataTable comprobacion = (DataTable)this.Session["carrito"];


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    obj.ProductoCantidad = Convert.ToInt32(dt.Rows[i]["Cantidad_dv"]);
                    obj.ProductoId = Convert.ToInt32(dt.Rows[i]["IdProducto_dv"]);
                    obj.ProductoimgUrl = dt.Rows[i]["Imagen_p"].ToString();
                    obj.ProductoNombre = dt.Rows[i]["NombreProducto_p"].ToString();
                    obj.ProductoPrecio = Convert.ToDecimal(dt.Rows[i]["PrecioUnitario_p"]);
                    obj.ProductoSubtotal = Convert.ToDecimal(dt.Rows[i]["SubTotal_dv"]);
                    bool repeticion = false;

                    if (comprobacion.Rows.Count != 0)
                    {
                        for (int o = 0; o < comprobacion.Rows.Count; o++)
                        {
                            int h = Convert.ToInt32(comprobacion.Rows[o]["ProductoId"]);
                            if (h == obj.ProductoId)
                            {
                                gc.ModificarRecompra((DataTable)this.Session["carrito"], obj);
                                repeticion = true;
                            }
                        }
                        if (repeticion == false)
                        {
                            gc.AgregarCarrito((DataTable)this.Session["carrito"], obj);
                        }
                    }
                    else
                    {
                        gc.AgregarCarrito((DataTable)this.Session["carrito"], obj);
                    }
                }

                GridView1.DataSource = (DataTable)this.Session["carrito"];
                GridView1.DataBind();
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            this.Session["cesta"] = (DataTable)this.Session["carrito"];
            Response.Redirect("Carrito.aspx");
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaProductos.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int pos = int.Parse(e.CommandArgument.ToString());
                negCarrito gc = new negCarrito();
                gc.EliminaCarrito((DataTable)this.Session["carrito"], pos);
                ActualizaCarrito();
            }

        }

        protected void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoUsuario.aspx");
        }
    }
}