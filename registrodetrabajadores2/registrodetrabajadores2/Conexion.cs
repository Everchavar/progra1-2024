using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace registrodetrabajadores2
{
    internal class Conexion
    {
        SqlConnection miConexion = new SqlConnection();//Conectarme a la BD.
        SqlCommand misComandos = new SqlCommand();//ejecutar SQL en la BD.
        SqlDataAdapter miAdaptador = new SqlDataAdapter();//Intermediario entre mi BD y la aplicacion.
        DataSet ds = new DataSet();//es la representacion grafica de la BD en memoria RAM.


        public Conexion()
        {
            String cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\empresas1.mdf;Integrated Security=True";
            miConexion.ConnectionString = cadenaConexion;
            miConexion.Open();
        }
        public DataSet obtenerDatos()
        {
            ds.Clear();
            misComandos.Connection = miConexion;

            miAdaptador.SelectCommand = misComandos;
            misComandos.CommandText = "SELECT * FROM trabajadores";
            miAdaptador.Fill(ds, "trabajadores");

            misComandos.CommandText = "SELECT * FROM Usuario";
            miAdaptador.Fill(ds, "Usuario");
            return ds;
        }

        public String administrartrabajadores(String[] datos)
        {
            String sql = "";
            if (datos[0] == "nuevo")
            {
                sql = "INSERT INTO trabajadores(codigo, nombre, direccion, telefono, dui) VALUES('" +
                    datos[2] + "','" + datos[3] + "','" + datos[4] + "','" + datos[5] + "','" + datos[6] + "')";
            }
            else if (datos[0] == "modificar")
            {
                sql = "UPDATE trabajadores SET codigo='" + datos[2] + "', nombre='" + datos[3] + "', direccion='" + datos[4] + "', telefono='" +
                    datos[5] + "', dui='" + datos[6] + "' WHERE Idtrabajadores=" + datos[1];
            }
            else if (datos[0] == "eliminar")
            {
                sql = "DELETE FROM trabajadores WHERE Idtrabajadores=" + datos[1];
            }
            return ejecutarSQL(sql);
        }

        public String mantenimiento_usuarios(String[] datos)
        {
            String sql = "";
            if (datos[0] == "nuevo")
            {
                sql = "INSERT INTO usuario(usuario, clave, nombre, direccion, telefono) VALUES('" +
                    datos[2] + "','" + datos[3] + "','" + datos[4] + "','" + datos[5] + "','" + datos[6] + "')";
            }
            else if (datos[0] == "modificar")
            {
                sql = "UPDATE usuario SET usuario='" + datos[2] + "', clave='" + datos[3] + "', nombre='" + datos[4] + "', direccion='" +
                    datos[5] + "', telefono='" + datos[6] + "' WHERE IdUsuario=" + datos[1];
            }
            else if (datos[0] == "eliminar")
            {
                sql = "DELETE FROM usuario WHERE IdUsuario=" + datos[1];
            }
            return ejecutarSQL(sql);
        }
       


        private String ejecutarSQL(String sql)
        {
            try
            {
                misComandos.Connection = miConexion;
                misComandos.CommandText = sql;
                return misComandos.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }

        }
    }
}
