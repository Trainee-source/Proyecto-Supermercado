using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
using ENTIDADES;

namespace TrabajoPracticoFinalProgramacion3
{
    public partial class EditarMarcas : System.Web.UI.Page
    {
        negCategorias negocioCats = new negCategorias();
        negMarcas negMarcas = new negMarcas();
        negMarcasxCategoria negMxC = new negMarcasxCategoria();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                entCategoria categorias = new entCategoria();
                ListItem primero = new ListItem("Seleccione una categoria");

                ProductoCategoria.Items.Add(primero);

                List<entCategoria> lista = negocioCats.ListarCategorias();

                foreach(entCategoria obj in lista)
                {
                    ListItem item = new ListItem(obj.nombreCategoria, obj.codigoCategoria);

                    ProductoCategoria.Items.Add(item);
                }


            }
        }

        protected void ProductoCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoMarca.Items.Clear();
            entMarca entMarcas = new entMarca();
            ListItem primero = new ListItem("Seleccione una marca");
            ProductoMarca.Items.Add(primero);

            List<entMarca> lista = negMarcas.ListarTodo();
            List<entCatxMar> validacion = negMxC.llamarLista();

            foreach(entMarca obj in lista)
            {
                foreach (entCatxMar non in validacion)
                {
                    if (non.Cod_C == ProductoCategoria.SelectedValue && obj.codigoMarca == non.Cod_M)
                    {
                        ListItem item = new ListItem(obj.nombreMarca, obj.codigoMarca);
                        ProductoMarca.Items.Add(item);
                    }
                }
            }


        }

        protected void BotonGuardar_Click(object sender, EventArgs e)
        {
            entMarca nuevo = new entMarca();


            nuevo.codigoMarca = ProductoMarca.SelectedValue;
            nuevo.nombreMarca = txtNombre.Text;
            int state = int.Parse(Estado.SelectedValue);

            if (negMarcas.ModificarMarca(nuevo, state) == -1)
            {
                lblerror.Text = "Se ha modificadao una marca exitosamente.";
                txtNombre.Text = "";
                ProductoMarca.SelectedIndex = ProductoMarca.Items.IndexOf(ProductoMarca.Items.FindByText("Seleccione una marca"));
                Estado.Items.Clear();
            }
            else
            {
                if (negMarcas.ModificarMarca(nuevo, state) == 0)
                {
                    lblerror.Text = "El nombre ingresado ya existe.";
                }
            }
                
        }

        protected void ProductoMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Estado.Items.Clear();

            txtNombre.Text = ProductoMarca.SelectedItem.Text;

            entMarca valor = new entMarca();
            string codigo = ProductoMarca.SelectedValue.ToString();

            negMarcas.BuscarMarca(valor, codigo);

            ListItem activo = new ListItem("Activo", "1");
            ListItem desactivado = new ListItem("Desactivado", "0");

            if (valor.activo == true)
            {
                Estado.Items.Add(activo);
                Estado.Items.Add(desactivado);
            }
            else
            {
                Estado.Items.Add(desactivado);
                Estado.Items.Add(activo);
            }
            
        }

        protected void btnFin_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaAdministrador.aspx");
        }
    }
}