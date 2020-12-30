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
    
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        negMarcasxCategoria CatMar = new negMarcasxCategoria();
        negMarcas MarcasM = new negMarcas();
        DataView vista = new DataView(negProductos.getTabla());
        negCarrito Carrito = new negCarrito();
        negCategorias cats = new negCategorias();
        DataTable lista = new DataTable();
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            string str = Request.QueryString[@"q"];

            GridListado.RowCommand += new GridViewCommandEventHandler(GridListado_RowCommand);

            GridCarro.RowCommand += new GridViewCommandEventHandler(GridCarro_RowCommand);


            if (this.Session["carrito"] == null)
                this.Session["carrito"] = Carrito.CrearCarrito();

            if (!IsPostBack)
            {
                
                ActualizaCarrito();
                //vista.RowFilter = "NombreProducto_p like '%" + str + "%'";

                GridListado.DataSource = PostBusqueda();
                
                GridListado.DataBind();

                List<entCategoria> lista1 = cats.ListarCategorias();
                ListaCategorias.Items.Add(new ListItem("Seleccione una categoria", "0"));
                entCategoria paraOtra = new entCategoria();

                foreach (entCategoria obj in lista1)
                {
                    ListItem item = new ListItem(obj.nombreCategoria, obj.codigoCategoria.ToString());
                    ListaCategorias.Items.Add(item);
                }
            }
        }

        private void ActualizaCarrito()
        {

            GridCarro.DataSource = (DataTable)this.Session["carrito"];
            GridCarro.DataBind();

        }


        

        protected void GridCarro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int pos = int.Parse(e.CommandArgument.ToString());
                negCarrito gc = new negCarrito();
                gc.EliminaCarrito((DataTable)this.Session["carrito"], pos);
                ActualizaCarrito();
            }
            
        }

        protected void GridCarro_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCarro.PageIndex = e.NewPageIndex;
            GridCarro.DataSource = (DataTable)this.Session["carrito"];
            GridCarro.DataBind();

        }

        protected void GridListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            entUsuario usus = (entUsuario)Session["usuario"];
            int yo = 0;
            if (usus != null)
            {
                if (usus.UsuarioAdmin != 0)
                    yo = 1;
            }

            if (yo == 0)
            {
                if (e.CommandName == "Select")
                {
                    DataTable carro = new DataTable();
                    DataTable comp = new DataTable();
                    comp = (DataTable)Session["carrito"];
                    bool repeticion = false;

                    negCarrito gc = new negCarrito();

                    int pos = int.Parse(e.CommandArgument.ToString());

                    int id = Convert.ToInt32(GridListado.Rows[pos].Cells[1].Text);

                    vista.RowFilter = "IdProducto_p =" + id;
                    carro = vista.ToTable();

                    entCarrito obj = new entCarrito();

                    obj.ProductoId = Convert.ToInt32(carro.Rows[0]["IdProducto_p"]);
                    obj.ProductoNombre = carro.Rows[0]["NombreProducto_p"].ToString();
                    obj.ProductoPrecio = Convert.ToDecimal(carro.Rows[0]["PrecioUnitario_p"]);
                    obj.ProductoCantidad = 1;
                    obj.ProductoimgUrl = carro.Rows[0]["Imagen_p"].ToString();

                    for (int i = 0; i < comp.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(comp.Rows[i]["ProductoId"]) == obj.ProductoId)
                        {
                            obj.ProductoCantidad = Convert.ToInt32(comp.Rows[i]["ProductoCantidad"]) + 1;
                            repeticion = true;
                        }
                    }

                    if (!repeticion)
                    {
                        gc.AgregarCarrito((DataTable)this.Session["carrito"], obj);
                    }
                    else
                    {
                        gc.ModificarCarrito((DataTable)this.Session["carrito"], obj);
                    }

                    ActualizaCarrito();
                }
            }
        }

        protected void cantidad_TextChanged(object sender, EventArgs e)
        {
            DataTable comp = new DataTable();

            negCarrito gc = new negCarrito();

            negProductos daoProd = new negProductos();

            comp = (DataTable)Session["carrito"];

            entCarrito obj = new entCarrito();

            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;

            int index = currentRow.RowIndex;

            obj.ProductoId = Convert.ToInt32(comp.Rows[index]["ProductoId"]);

            obj.ProductoPrecio = Convert.ToDecimal(comp.Rows[index]["ProductoPrecio"]);

            TextBox txt = (TextBox)currentRow.FindControl("cantidad");

            int stock = daoProd.BuscarProducto(obj.ProductoId);

            int cant;

            if (txt.Text != "")
            {
                cant = Convert.ToInt32(txt.Text);
            }
            else
                cant = 0;
            
            if (cant > stock)
            {
                cant = stock - 100;
            }
            

            if (cant > 0)
            {
                obj.ProductoCantidad = cant;

                for (int i = 0; i < comp.Rows.Count; i++)
                {
                    if (Convert.ToInt32(comp.Rows[i]["ProductoId"]) == obj.ProductoId)
                    {
                        gc.ModificarCarrito((DataTable)this.Session["carrito"], obj);
                    }
                }
            }
            else
            {

                gc.EliminaCarrito((DataTable)this.Session["carrito"], index);
                ActualizaCarrito();

            }

            GridCarro.DataSource = (DataTable)this.Session["carrito"];
            GridCarro.DataBind();
            this.Load += new System.EventHandler(this.Page_Load);
        }

        protected void ListaCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaMarcas.Visible = true;

            ListaMarcas.Items.Clear();

            List<entMarca> otraLista = MarcasM.ListarMarcas();
            ListaMarcas.Items.Add(new ListItem("Seleccione una marca", "0"));
            List<entCatxMar> Comprobante = CatMar.llamarLista();

            foreach (entMarca rob in otraLista)
            {
                foreach (entCatxMar com in Comprobante)
                {
                    if (com.Cod_M == rob.codigoMarca && com.Cod_C == ListaCategorias.SelectedValue)
                    {
                        ListItem item = new ListItem(rob.nombreMarca, rob.codigoMarca.ToString());
                        ListaMarcas.Items.Add(item);
                    }
                }
            }
            if (ListaMarcas.Items.Count == 1)
            {
                ListaMarcas.Items.Add(new ListItem("No hay productos para esta categoria", "0"));
            }
        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {

            GridListado.DataSource = CargarVista();
            GridListado.DataBind();

        }

        protected void GridListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (this.Session["filtro"] == null)
            {
                GridListado.PageIndex = e.NewPageIndex;
                GridListado.DataSource = negProductos.getTabla();
                GridListado.DataBind();
            }
            else
            {
                GridListado.PageIndex = e.NewPageIndex;
                GridListado.DataSource = CargarVista();
                GridListado.DataBind();
            }

        }

        protected DataView PostBusqueda()
        {
            string str = Request.QueryString[@"q"];

            string filtro = string.Empty;

            filtro = "NombreProducto_p like '%" + str + "%'";

            if (filtro.Length != 0)
            {
                vista.RowFilter = filtro;
                this.Session["filtro"] = filtro;
            }

            return vista;
        }

        protected DataView CargarVista()
        {
            string str = Request.QueryString[@"q"];

            string filtro = string.Empty;

            filtro = "NombreProducto_p like '%" + str + "%'";

            int min = 0;
            int max = 0;


            if (PrecioMin.Text != "") { min = Convert.ToInt32(PrecioMin.Text); }

            if (PrecioMax.Text != "") { max = Convert.ToInt32(PrecioMax.Text); }



            if (int.Parse(ListaCategorias.SelectedValue) != 0)
            {
                if (int.Parse(ListaMarcas.SelectedValue) != 0)
                {
                    if (filtro.Length == 0)

                        filtro += "IdCategoria_p = " + ListaCategorias.SelectedValue + " AND IdMarca_p = " + ListaMarcas.SelectedValue;

                    else
                        filtro += " and IdCategoria_p = " + ListaCategorias.SelectedValue + " AND IdMarca_p = " + ListaMarcas.SelectedValue;
                }
                else
                {


                    if (filtro.Length != 0)
                    {
                        filtro += " and IdCategoria_p = " + ListaCategorias.SelectedValue;
                    }
                    else
                    {
                        filtro += " IdCategoria_p = " + ListaCategorias.SelectedValue;
                    }
                }
            }

            if (min != 0)
            {
                if (max != 0)
                {
                    if (filtro.Length != 0)
                    {
                        filtro += " AND PrecioUnitario_p < " + max + " AND PrecioUnitario_p > " + min;
                    }
                    else
                        filtro += "PrecioUnitario_p < " + max + " AND PrecioUnitario_p > " + min;
                }
                else
                {
                    if (filtro.Length == 0)
                        filtro += "PrecioUnitario_p > " + min;
                    else
                        filtro += " AND PrecioUnitario_p > " + min;
                }

            }
            else
            {
                if (max != 0 && filtro.Length == 0)
                {
                    filtro += "PrecioUnitario_p < " + max;
                }
                else
                {
                    if (max != 0 && filtro.Length != 0)
                    {
                        filtro += " and PrecioUnitario_p < " + max;
                    }
                }
            }

            

            if (filtro.Length != 0)
            {
                vista.RowFilter = filtro;
                this.Session["filtro"] = filtro;
            }

            return vista;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            entUsuario obj = (entUsuario)Session["usuario"];

            if (obj != null)
            {
                this.Session["cesta"] = Carrito.CrearCarrito();
                this.Session["cesta"] = this.Session["carrito"];
                Response.Redirect("Carrito.aspx");
            }
            else
            {
                if (this.Session["carrito"] != null)
                {
                    this.Session["cesta"] = Carrito.CrearCarrito();
                    this.Session["cesta"] = this.Session["carrito"];
                }
                    
                    Response.Redirect("Login.aspx");
            }
                
            
        }

    }
}
