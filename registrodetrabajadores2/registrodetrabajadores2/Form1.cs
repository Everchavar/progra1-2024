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
    public partial class Form1 : Form
    {
        Conexion objConexion = new Conexion();
        DataSet ds = new DataSet();
        DataTable miTabla = new DataTable();

        public int posicion = 0;
        String accion = "nuevo";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actualizarDs();
        }
        private void actualizarDs()
        {
            ds.Clear();
            ds = objConexion.obtenerDatos();
            miTabla = ds.Tables["trabajadores"];
            miTabla.PrimaryKey = new DataColumn[] { miTabla.Columns["Idtrabajadores"] };
            grdDatostrabajadores.DataSource = miTabla;
            mostrarDatostrabajadores();
        }
        private void mostrarDatostrabajadores()
        {
            if (miTabla.Rows.Count > 0)
            {
                txtCodigotrabajadores.Text = miTabla.Rows[posicion].ItemArray[1].ToString();
                txtNombretrabajadores.Text = miTabla.Rows[posicion].ItemArray[2].ToString();
                txtDirecciontrabajadores.Text = miTabla.Rows[posicion].ItemArray[3].ToString();
                txtTelefonotrabajadores.Text = miTabla.Rows[posicion].ItemArray[4].ToString();
                txtDuitrabajadores.Text = miTabla.Rows[posicion].ItemArray[5].ToString();

                lblRegistrostrabajadores.Text = (posicion + 1) + " de " + miTabla.Rows.Count;
            }
        }

        private void btnSiguientetrabajadores_Click(object sender, EventArgs e)
        {
            if (posicion < miTabla.Rows.Count - 1)
            {
                posicion++;
                mostrarDatostrabajadores();
            }
            else
            {
                MessageBox.Show("Esta en el ultimo registro", "Navegacion de alumnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnteriortrabajadores_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrarDatostrabajadores();
            }
            else
            {
                MessageBox.Show("Esta en el primer registro", "Navegacion de alumnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnPrimerotrabajadores_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatostrabajadores();
        }

        private void btnUltimotrabajadores_Click(object sender, EventArgs e)
        {
            posicion = miTabla.Rows.Count - 1;
            mostrarDatostrabajadores();
        }
        private void estadoControles(Boolean estado)
        {
            grbDatostrabajadores.Enabled = estado;
            grbNavegaciontrabajadores.Enabled = !estado;
            btnEliminartrabajadores.Enabled = !estado;
        }

        private void btnNuevotrabajadores_Click(object sender, EventArgs e)
        {
            if (btnNuevotrabajadores.Text == "Nuevo")
            {
                btnNuevotrabajadores.Text = "Guardar";
                btnModificartrabajadores.Text = "Cancelar";
                accion = "nuevo";
                estadoControles(true);
                limpiarCajas();
            }
            else
            {//Guardar
                String[] trabajadores = {
                    accion, miTabla.Rows[posicion].ItemArray[0].ToString(),
                    txtCodigotrabajadores.Text, txtNombretrabajadores.Text, txtDirecciontrabajadores.Text, txtTelefonotrabajadores.Text, txtDuitrabajadores.Text
                };
                String respuesta = objConexion.administrartrabajadores(trabajadores);
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error en el registro de trabajadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnNuevotrabajadores.Text = "Nuevo";
                    btnModificartrabajadores.Text = "Modificar";
                    estadoControles(false);
                    actualizarDs();
                }

            }
        }
        void limpiarCajas()
        {
            txtCodigotrabajadores.Text = "";
            txtNombretrabajadores.Text = "";
            txtDirecciontrabajadores.Text = "";
            txtTelefonotrabajadores.Text = "";
            txtDuitrabajadores.Text = "";
        }

        private void btnModificartrabajadores_Click(object sender, EventArgs e)
        {
            if (btnModificartrabajadores.Text == "Modificar")
            {
                btnNuevotrabajadores.Text = "Guardar";
                btnModificartrabajadores.Text = "Cancelar";
                accion = "modificar";
                estadoControles(true);

            }
            else
            {//Cancelar
                mostrarDatostrabajadores();
                btnNuevotrabajadores.Text = "Nuevo";
                btnModificartrabajadores.Text = "Modificar";
                estadoControles(false);
            }
        }

        private void btnEliminartrabajadores_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar a " + txtNombretrabajadores.Text.Trim() + "?", "Eliminar alumnos", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String[] trabajadores = {
                    "eliminar", miTabla.Rows[posicion].ItemArray[0].ToString()
                };
                String respuesta = objConexion.administrartrabajadores(trabajadores);
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error en el registro de trabadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    posicion = 0;
                    actualizarDs();
                    mostrarDatostrabajadores();
                }
            }
        }
        private void filtrarDatos(String filtro)
        {
            DataView dv = miTabla.DefaultView;
            dv.RowFilter = "codigo like '%" + filtro + "%' OR nombre like '%" + filtro + "%'";
            grdDatostrabajadores.DataSource = dv;
        }

        private void txtBuscartrabajadores_TextChanged(object sender, EventArgs e)
        {
            filtrarDatos(txtBuscartrabajadores.Text);
            seleccionartrabajadores();
           
        }
        private void seleccionartrabajadores()
        {
            posicion = miTabla.Rows.IndexOf(miTabla.Rows.Find(grdDatostrabajadores.CurrentRow.Cells["Idtrabajadores"].Value.ToString()));
            mostrarDatostrabajadores();
        }

        private void grdDatostrabajadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionartrabajadores();
        }

        private void lblRegistrostrabajadores_Click(object sender, EventArgs e)
        {

        }
    }
}