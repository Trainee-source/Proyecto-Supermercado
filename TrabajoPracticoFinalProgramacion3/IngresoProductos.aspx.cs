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
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        negCategorias Categorias = new negCategorias();
        negMarcas MarcasM = new negMarcas();
        negMarcasxCategoria CatMar = new negMarcasxCategoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<entCategoria> lista = Categorias.ListarCategorias();
                ProductoCategoria.Items.Add("Seleccione una categoria");
                entCategoria paraOtra = new entCategoria();

                foreach (entCategoria obj in lista)
                {
                    ListItem item = new ListItem(obj.nombreCategoria, obj.codigoCategoria.ToString());
                    ProductoCategoria.Items.Add(item);
                }

            }
        }

        protected void BotonGuardar_Click(object sender, EventArgs e)
        {
            string savePath = "~/img/";
            negProductos negocioP = new negProductos();

            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;

                string extension = System.IO.Path.GetExtension(FileUpload1.FileName);

                lblerror.Text = fileName.ToLower();

                if ((extension.ToLower() == ".png") || (extension.ToLower() == ".jpg"))
                {
                    savePath += fileName;

                    FileUpload1.SaveAs(Server.MapPath("~/img/" + fileName));
                }
            }
            else
                savePath = "Not Has File";

            if (ProductoNombre.Text != "" && ProductoDescripcion.Text != "" && ProductoPrecio.Text != "" && ProductoStock.Text != "" && ProductoCategoria.SelectedValue!=null && ProductoMarca.SelectedValue != null)
               {
                    entProducto obj = new entProducto();
                    obj.Productonombre = ProductoNombre.Text;
                    obj.ProductoimgUrl = savePath;
                    obj.Productodescripcion = ProductoDescripcion.Text;
                    obj.ProductoidCategoria = ProductoCategoria.SelectedValue;
                    obj.ProductoidMarca = ProductoMarca.SelectedValue;
               try
                    {

                        obj.ProductoprecioUnitario = Convert.ToDecimal(ProductoPrecio.Text);
                        obj.Productostock = Convert.ToInt32(ProductoStock.Text);

                    }
               catch (Exception ex)
                    {
                        lblerror.Text = "Se han ingresado datos incorrectos.";
                    }

                  if (negocioP.InsertarProducto(obj) != 0)
                    {
                        lblerror.Text = "El producto se ha ingresado correctamente.";
                    }

                  else
                    {
                        lblerror.Text = "Fallo el ingreso del producto.";
                    }
                }
                else
                    lblerror.Text = "Faltan completar campos.";
            }

        protected void BotonVisible_Click(object sender, EventArgs e)
        {
                List<entCategoria> lista = Categorias.ListarCategorias();
                ListaCatergoria.Items.Add(new ListItem("Seleccione una categoria", "0"));

                foreach (entCategoria obj in lista)
                {
                    ListItem item = new ListItem(obj.nombreCategoria, obj.codigoCategoria.ToString());
                    ListaCatergoria.Items.Add(item);
                }


            Titulo.Visible = true;
            LabelCat.Visible = true;
            ListaCatergoria.Visible = true;
            LabelMar.Visible = true;
            TextoMarca.Visible = true;
            Agregar.Visible = true;
            hide.Visible = true;


        }
        protected void hide_Click(object sender, EventArgs e)
        {
            Titulo.Visible = false;
            LabelCat.Visible = false;
            ListaCatergoria.Visible = false;
            LabelMar.Visible = false;
            TextoMarca.Visible = false;
            Agregar.Visible = false;
            hide.Visible = false;
            LabelAnuncio.Visible = false;

        }

        protected void ProductoCategoria_SelectedIndexChanged1(object sender, EventArgs e)
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

        protected void Agregar_Click(object sender, EventArgs e)
        {
            entCatxMar obj = new entCatxMar();
            entMarca mar = new entMarca();

            List<entCategoria> lista = Categorias.ListarCategorias();
            List<entMarca> lista1 = MarcasM.ListarMarcas();

            if (Convert.ToInt32(ListaCatergoria.SelectedValue) != 0)
            {
                if (TextoMarca.Text != "")
                {
                    mar.codigoMarca = Convert.ToString(lista1.Count() + 1);
                    mar.nombreMarca = TextoMarca.Text;

                    if (MarcasM.AgregarMarca(mar) == -1)
                    {
                        obj.Cod_C = ListaCatergoria.SelectedValue;
                        obj.Cod_M = mar.codigoMarca;

                        if (CatMar.ingresarMarcaACategoria(obj) == -1)
                        {
                            LabelAnuncio.Visible = true;
                            LabelAnuncio.Text = "Se ha creado la relacion exitosamente";
                        }
                        else
                        {
                            LabelAnuncio.Visible = true;
                            LabelAnuncio.Text = "Error al crear la relacion";
                        }

                    }
                    else
                    {
                            LabelAnuncio.Visible = true;
                            LabelAnuncio.Text = "La Marca ingresada ya se encuentra cargada";
                    }
                        

                }
                else
                {
                    LabelAnuncio.Visible = true;
                    LabelAnuncio.Text = "Falta completar el campo";
                }
            }
            else
            {
                LabelAnuncio.Visible = true;
                LabelAnuncio.Text = "Seleccione una categoria";
            }

            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaAdministrador.aspx");
        }

    }
}