using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace TrabajoPracticoFinalProgramacion3
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImagenesRot.ImageUrl = "~/ImagenesWeb/Banner.png";
            Imagen2.ImageUrl = "~/ImagenesWeb/banner2.png";
        }
    }
}