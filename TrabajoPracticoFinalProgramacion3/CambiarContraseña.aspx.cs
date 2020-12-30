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
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            negUsuarios Usuarios = new negUsuarios();
            int estado = 1;

            if (boxDNI.Text != "" && boxEmail.Text != "" && boxPass.Text != "" && boxPass2.Text != "")
            {
                if (boxPass.Text == boxPass2.Text)
                {
                    entUsuario obj = new entUsuario();
                    obj.Usuariodni = boxDNI.Text;
                    obj.UsuarioMail = boxEmail.Text;
                    obj.UsuarioContraseña = boxPass2.Text;
                    estado = Usuarios.CambiarContraseña(obj);
                    if (estado==1)
                        lblAviso.Text = "Se ha cambiado la contraseña con exito";
                    else
                        lblAviso.Text = "Ha habido un error";

                }
                else
                {
                    lblAviso.Text = "Las Contraseñas no coinciden";
                }
            }
            else
            {
                lblAviso.Text = "Falta completar campos";
            }
            


            Response.Redirect("Login.aspx");
        }
    }
}