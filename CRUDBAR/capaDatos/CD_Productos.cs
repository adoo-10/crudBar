using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace capaDatos
{
    public class CD_Productos
    {
        //aca se almacenaran las consultas a la base de datos
        //agregamos los metodos CRUD para ejecutar el procedimiento de almacenado

        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //metodos
        public DataTable mostrar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "LeerProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarConexion();

            return tabla;
        }

        public void Insertar(string nombre, string desc, double precio, int cantidad, int estado)
        {
            //insertar datos
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "InsertarProductos"; //nombre del proceso de almacenado
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Actualizar (string nombre, string desc, double precio, int cantidad, int estado, int idproducto)
        {
            //actualizar datos
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "ActualizarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@idproducto", idproducto);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Borrar (int idproducto)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "EliminarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idprod", idproducto);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
    }
}
