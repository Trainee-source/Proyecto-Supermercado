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
    public partial class IngresoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            entUsuario actual = (entUsuario)this.Session["usuario"];
            if (!IsPostBack)
            {
                if (actual != null)
                {
                    lblPagina.Text = "Modifique su Perfil";
                    UsuarioApellidos.Text = actual.UsuarioApellidos;
                    UsuarioNombre.Text = actual.UsuarioNombre;
                    //UsuarioDni.Text = actual.Usuariodni;
                    UsuarioDni.Visible = false;
                    UsuarioEmail.Text = actual.UsuarioMail;
                    UsuarioContraseña.Visible = false;
                    UsuarioContraseña2.Visible = false;
                    lblContraseña1.Visible = false;
                    lblContraseña2.Visible = false;
                    lblDni.Visible = false;

            }
            }
        }

        protected void BotonGuardar_Click(object sender, EventArgs e)
        {
            if(this.Session["usuario"] == null)
            {

            if (UsuarioDni.Text != "" && UsuarioNombre.Text != "" && UsuarioApellidos.Text != "" && UsuarioEmail.Text != "" && UsuarioContraseña.Text != "" && UsuarioContraseña2.Text != "")
            {
                negUsuarios persona = new negUsuarios();
                entUsuario obj = new entUsuario();
                obj.Usuariodni = UsuarioDni.Text;
                obj.UsuarioNombre = UsuarioNombre.Text;
                obj.UsuarioApellidos = UsuarioApellidos.Text;
                obj.UsuarioMail = UsuarioEmail.Text;


                if (UsuarioContraseña.Text == UsuarioContraseña2.Text)
                {
                    obj.UsuarioContraseña = UsuarioContraseña.Text;

                    if (persona.InsertarUsuario(obj) == 1)
                        {
                            Response.Redirect("Login.aspx");
                        }
                        
                    else
                        lblError.Text = "Ha fallado la carga del usuario";
                }
                else
                    lblError.Text = "Las contraseñas no son iguales, por favor verificar";
                



            }
            else
                lblError.Text = "No se han completado todos los campos";
            }
            else
            {
                if(UsuarioNombre.Text != "" && UsuarioApellidos.Text != "" && UsuarioEmail.Text != "")
                {
                    negUsuarios personaModificada = new negUsuarios();
                    entUsuario objModificado = new entUsuario();
                    entUsuario objAuxiliar = (entUsuario) this.Session["usuario"];
                                      

                    objModificado.UsuarioMail =   UsuarioEmail.Text;
                    objModificado.UsuarioNombre = UsuarioNombre.Text;
                    objModificado.UsuarioApellidos = UsuarioApellidos.Text;

                    if (personaModificada.EditarPerfil(objModificado, objAuxiliar.Usuariodni) == -1 )
                    {
                        Session.Remove("usuario");
                        Response.Redirect("Noticia.aspx");
                    }
                }
            }
        }
    }
}