using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {

        private CD_Producto objetoCD = new CD_Producto();

        public DataTable LeerProd()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void insprod(string nombre, string desc, string precio, string cantidad, string estado )
        {

            objetoCD.Insertar(nombre, desc, Convert.ToDouble(precio), Convert.ToInt32(cantidad),
                Convert.ToInt32(estado));
        }

        public void Actprod(string nombre, string desc, string precio, string cantidad, string estado, string idproducto)
        {

            objetoCD.actualizar(nombre, desc, Convert.ToDouble(precio), Convert.ToInt32(cantidad),
                 Convert.ToInt32(estado), Convert.ToInt32(idproducto));
        }

        public void Eliprod(string idproducto)
        {
            objetoCD.Borrar(Convert.ToInt32(idproducto));
        }
    }    
          
    
}

