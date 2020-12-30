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
    public partial class WebForm1 : System.Web.UI.Page
    {
        negCategorias Categorias = new negCategorias();
        negMarcas MarcasM = new negMarcas();
        negMarcasxCategoria CatMar = new negMarcasxCategoria();
    

        protected void Page_Load(object sender, EventArgs e)
        {
            entProducto ids = (entProducto)Session["producto"];

            if (!IsPostBack)
            {
                entCategoria paraOtra = new entCategoria();
                entMarca non = new entMarca();

                ListItem activo = new ListItem("Activo", "1");
                ListItem desactivado = new ListItem("Desactivado", "0");

                Estado.Items.Add(activo);
                Estado.Items.Add(desactivado);

                List<entCategoria> lista = Categorias.ListarCategorias();
                paraOtra = Categorias.BuscarCategoria(ids.ProductoidCategoria);

                MarcasM.BuscarMarca(non, ids.ProductoidMarca);

                ListItem seleccion = new ListItem(paraOtra.nombreCategoria, paraOtra.codigoCategoria);
                ListItem marca = new ListItem(non.nombreMarca, non.codigoMarca);

                List<entMarca> otraLista = MarcasM.ListarMarcas();
                List<entCatxMar> Comprobante = CatMar.llamarLista();

                ProductoCategoria.Items.Add(seleccion);
                ProductoMarca.Items.Add(marca);

                foreach (entCategoria obj in lista)
                {
                    if (!obj.codigoCategoria.Equals(paraOtra.codigoCategoria))
                    {
                        ListItem item = new ListItem(obj.nombreCategoria, obj.codigoCategoria.ToString());
                        ProductoCategoria.Items.Add(item);
                    }
                }

                foreach (entMarca rob in otraLista)
                {
                    foreach (entCatxMar com in Comprobante)
                    {
                        if (com.Cod_M == rob.codigoMarca && com.Cod_C == paraOtra.codigoCategoria && rob.codigoMarca != non.codigoMarca)
                        {
                            ListItem item = new ListItem(rob.nombreMarca, rob.codigoMarca.ToString());
                            ProductoMarca.Items.Add(item);
                        }
                    }
                }

                ProductoNombre.Text = ids.Productonombre;
                ProductoDescripcion.Text = ids.Productodescripcion;
                ProductoStock.Text = ids.Productostock.ToString();
                ProductoPrecio.Text = ids.ProductoprecioUnitario.ToString();
                
            }
        }

        protected void BotonGuardar_Click(object sender, EventArgs e)
        {
            if (ProductoNombre.Text != "" && ProductoDescripcion.Text != "" && ProductoStock.Text != "" && ProductoPrecio.Text != "")
            {
                entProducto ids = (entProducto)Session["producto"];
                entProducto entProd = new entProducto();
                negProductos negProd = new negProductos();

                string savePath = "~/img/";

                if (FileUpload1.HasFile)
                {
                    string fileName = FileUpload1.FileName;

                    string extension = System.IO.Path.GetExtension(FileUpload1.FileName);

                    lblerror.Text = fileName.ToLower();

                    if ((extension.ToLower() == ".png") || (extension.ToLower() == ".jpg"))
                    {
                        savePath += fileName;

                        FileUpload1.SaveAs(Server.MapPath("~/img/" + fileName));
                        entProd.ProductoimgUrl = savePath;
                    }
                }
                else
                    entProd.ProductoimgUrl = ids.ProductoimgUrl;

                int estate;

                estate = int.Parse(Estado.SelectedValue);

                entProd.Productoid = ids.Productoid;
                entProd.Productonombre = ProductoNombre.Text;
                entProd.Productodescripcion = ProductoDescripcion.Text;
                entProd.Productostock = int.Parse(ProductoStock.Text);
                entProd.ProductoprecioUnitario = decimal.Parse(ProductoPrecio.Text);
                entProd.ProductoidCategoria = ProductoCategoria.SelectedValue;
                entProd.ProductoidMarca = ProductoMarca.SelectedValue;
                

                if (negProd.ModificarProductos(entProd, estate) == -1)
                {
                    Session.Remove("producto");
                    
                    Response.Redirect("Noticia.aspx");
                }
            }
        }

        protected void ProductoCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoMarca.Items.Clear();

            List<entMarca> otraLista = MarcasM.ListarMarcas();
            List<entCatxMar> Comprobante = CatMar.llamarLista();

            ProductoMarca.Items.Add("Seleccione una marca");

            foreach (entMarca rob in otraLista)
            {
                foreach (entCatxMar com in Comprobante)
                {
                    if (com.Cod_M == rob.codigoMarca && com.Cod_C == ProductoCategoria.SelectedValue)
                    {
                        ListItem item = new ListItem(rob.nombreMarca, rob.codigoMarca.ToString());
                        ProductoMarca.Items.Add(item);
                    }
                }
            }
            if (ProductoMarca.Items.Count == 0)
            {
                ProductoMarca.Items.Add("No hay marcas para esta categoria");
            }
        }
    }
}