using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    class Conexion
    {
        String SqlRuta = "Data Source = DESKTOP-QRQI94V\\SQLEXPRESS; Initial Catalog=Nisi_Database; Integrated Security=True";

        public SqlConnection conectar()
        {
            SqlConnection cmd = new SqlConnection();
            cmd.ConnectionString = SqlRuta;
            return cmd;
        }

    }
}
