using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace capaDatos
{
    public class CD_Conexion
    {   //creamos la cadena de conexion a la BD
        private SqlConnection Conexion = new SqlConnection("Server=LAPTOP-IGLVIF7S;" + "DataBase=BarDb;" + 
            "Integrated Security= SSPI");

        //metodo para abrir la conexion
        public SqlConnection abrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        //metodo para cerra la conexion
        public SqlConnection cerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
