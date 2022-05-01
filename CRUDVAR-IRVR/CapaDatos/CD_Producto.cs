using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System. Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class CD_Producto
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            tabla.Load(Leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string nombre,string desc,double precio,int cantidad,int estado)
        {
            //Procedimiento para insertar datos

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);
            

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            { }
        }
        public void Borrar(int idproducto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idprod", idproducto);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();


        }
        public void actualizar(string nombre, string desc, double precio, int cantidad, int estado, int idproducto)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "actualizarproducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);

        }
    }
}







