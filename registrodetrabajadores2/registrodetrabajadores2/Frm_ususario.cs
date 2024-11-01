using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registrodetrabajadores2
{
    public partial class Frm_usuario : Form
    {
        Conexion objConexion = new Conexion();
        DataSet ds = new DataSet();
        DataTable miTabla = new DataTable();

        public int posicion = 0;
        String accion = "nuevo";
        public Frm_usuario()
        {
            InitializeComponent();
        }



        private void grdDatostrabajadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarusuario();
        }

        private void Frm_usuario_Load(object sender, EventArgs e)
        {
            actualizarDs();
        }

        private void actualizarDs()
        {
            ds.Clear();
            ds = objConexion.obtenerDatos();
            miTabla = ds.Tables["usuario"];
            miTabla.PrimaryKey = new DataColumn[] { miTabla.Columns["IdUsuario"] };
            grdDatosusuario.DataSource = miTabla;
            mostrarDatosusuario();
        }

        private void mostrarDatosusuario()
        {
            if (miTabla.Rows.Count > 0)
            {
                txtusuario.Text = miTabla.Rows[posicion].ItemArray[1].ToString();
                txtclaveusuario.Text = miTabla.Rows[posicion].ItemArray[2].ToString();
                textconfirmarclave.Text = miTabla.Rows[posicion].ItemArray[2].ToString();
                txtnombreusuario.Text = miTabla.Rows[posicion].ItemArray[3].ToString();
                txtDireccionusuario.Text = miTabla.Rows[posicion].ItemArray[4].ToString();
                txtTelefonousuario.Text = miTabla.Rows[posicion].ItemArray[5].ToString();

                lblRegistrosusuario.Text = (posicion + 1) + " de " + miTabla.Rows.Count;
            }




        }

        private void btnSiguienteusuario_Click(object sender, EventArgs e)
        {

        }

        private void btnAnteriorusuario_Click(object sender, EventArgs e)
        {

        }

        private void btnPrimerousuario_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatosusuario();
        }

        private void btnUltimousuario_Click(object sender, EventArgs e)
        {

        }

        private void estadoControles(Boolean estado)
        {
            grbDatosusuario.Enabled = estado;
            grbNavegacionusuario.Enabled = !estado;
            btnEliminarusuario.Enabled = !estado;
        }

        private void btnNuevousuario_Click(object sender, EventArgs e)
        {

        }
        void limpiarCajas()
        {
            txtusuario.Text = "";
            txtclaveusuario.Text = "";
            textconfirmarclave.Text = "";
            txtnombreusuario.Text = "";
            txtDireccionusuario.Text = "";
            txtTelefonousuario.Text = "";
        }

        private void btnModificarusuario_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarusuario_Click(object sender, EventArgs e)
        {

        }
        private void filtrarDatos(String filtro)
        {
            DataView dv = miTabla.DefaultView;
            dv.RowFilter = "usuario LIKE '%" + filtro + "%' " +
                           "OR nombre LIKE '%" + filtro + "%' " +
                           "OR direccion LIKE '%" + filtro + "%' " +
                           "OR telefono LIKE '%" + filtro + "%' " +
                           "OR clave LIKE '%" + filtro + "%'"; 

            grdDatosusuario.DataSource = dv;

        }

        private void txtBuscarusuario_TextChanged(object sender, EventArgs e)
        {
            filtrarDatos(txtBuscarusuario.Text);
            seleccionarusuario();

        }


        private void seleccionarusuario()
        {
            
            if (grdDatosusuario.CurrentRow == null || grdDatosusuario.CurrentRow.Cells["IdUsuario"].Value == null)
            {
                MessageBox.Show(" No hay un usuario con esa inicial en el nombre "   + txtBuscarusuario.Text.Trim() +   " es inválido. ", "Usuario No encontrado ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            string idUsuario = grdDatosusuario.CurrentRow.Cells["IdUsuario"].Value.ToString();
           DataRow filaEncontrada = miTabla.Rows.Find(idUsuario);

            if (filaEncontrada != null)
            {
                posicion = miTabla.Rows.IndexOf(filaEncontrada);
                mostrarDatosusuario(); 
            }
            else
            {
                MessageBox.Show("No se encontró ningún usuario con el ID proporcionado.", "Búsqueda de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevousuario_Click_1(object sender, EventArgs e)
        {
            if (btnNuevousuario.Text == "Nuevo")
            {
                btnNuevousuario.Text = "Guardar";
                btnModificarusuario.Text = "Cancelar";
                accion = "nuevo";
                estadoControles(true);
                limpiarCajas();
            }
            else
            {//Guardar
                if (txtusuario.Text.Length < 6 || txtusuario.Text.Length > 16)
                {
                    MessageBox.Show("El nombre de usuario debe tener entre minimo 6 y maximo 16 caracteres.", "Error al ingresar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Validar que la clave y la confirmación de clave coincidan
                if (txtclaveusuario.Text != textconfirmarclave.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden. Por favor, verifica ambas contraseñas.", "La contraseña no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String[] usuario = {
                    accion, miTabla.Rows[posicion].ItemArray[0].ToString(),
                    txtusuario.Text, txtclaveusuario.Text, txtnombreusuario.Text, txtDireccionusuario.Text, txtTelefonousuario.Text


                };
                String respuesta = objConexion.mantenimiento_usuarios(usuario);
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error en el registro de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else

                {
                    btnNuevousuario.Text = "Nuevo";
                    btnModificarusuario.Text = "Modificar";
                    estadoControles(false);
                    actualizarDs();
                }
            }
        }

        private void btnModificarusuario_Click_1(object sender, EventArgs e)
        {
            if (btnModificarusuario.Text == "Modificar")
            {
                btnNuevousuario.Text = "Guardar";
                btnModificarusuario.Text = "Cancelar";
                accion = "modificar";
                estadoControles(true);

            }
            else
            {//Cancelar
                mostrarDatosusuario();
                btnNuevousuario.Text = "Nuevo";
                btnModificarusuario.Text = "Modificar";
                estadoControles(false);
            }
        }


        private void btnEliminarusuario_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar a " + txtnombreusuario.Text.Trim() + "?", "Eliminar usuario", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String[] usuario = {
                    "eliminar", miTabla.Rows[posicion].ItemArray[0].ToString()
                };
                String respuesta = objConexion.mantenimiento_usuarios(usuario);
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error en el registro de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    posicion = 0;
                    actualizarDs();
                    mostrarDatosusuario();
                }

                
            }
        }

        private void lblRegistrosusuario_Click(object sender, EventArgs e)
        {

        }

        private void btnUltimousuario_Click_1(object sender, EventArgs e)
        {
            posicion = miTabla.Rows.Count - 1;
            mostrarDatosusuario();
        }

        private void btnSiguienteusuario_Click_1(object sender, EventArgs e)
        {
            if (posicion < miTabla.Rows.Count - 1)
            {
                posicion++;
                mostrarDatosusuario();
            }
            else
            {
                MessageBox.Show("Esta en el ultimo registro de usuarios", "Navegacion de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnteriorusuario_Click_1(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrarDatosusuario();
            }
            else
            {
                MessageBox.Show("Esta en el primer registro", "Navegacion de alumnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrimerousuario_Click_1(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatosusuario();
        }

        private void txtBuscarusuario_TextChanged_1(object sender, EventArgs e)
        {
            filtrarDatos(txtBuscarusuario.Text);
            
            seleccionarusuario();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}