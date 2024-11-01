using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace registrodetrabajadores2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\empresas1.mdf;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Open();
            string consulta = "SELECT* FROM Usuario where Usuario = '"+textBox1.Text+"' and clave ='"+textBox2.Text+"'";
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.HasRows== true)
            {
                Frm_usuario frmbienvenido = new Frm_usuario();
                this.Hide();
                frmbienvenido.Show();
            }

            else
            {
                MessageBox.Show("Usuario o contaseña incorrectos");

            }
            Conexion.Close();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
