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

namespace Registro_de_empleados
{
    public partial class Login : Form
    {
        static readonly string conexionstring = "Server=THE-KING-LION\\SQLEXPRESS; Database=SICPB; integrated security=True; MultipleActiveResultSets=True";
        static readonly SqlConnection conexion = new SqlConnection(conexionstring);

        int intentos = 0;

        public Login()
        {
            InitializeComponent();

            conexion.Open();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            conexion.Close();
            Application.Exit();
        }

        private void btn_acceder_Click(object sender, EventArgs e)
        {
            intentos++;

            string usuario, contrasenia;
            string cadena = "select usuario, contrasenia from login";

            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader lector = comando.ExecuteReader();

            lector.Read();

            usuario = lector["usuario"].ToString();
            contrasenia = lector["contrasenia"].ToString();

            if (intentos < 3)
            {
                if (txt_usuario.Text.Equals(usuario))
                {
                    if (txt_pass.Text.Equals(contrasenia))
                    {
                        Registro abre = new Registro();
                        this.Hide();
                        abre.Show();

                        conexion.Close();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña es incorrecto", "contraseña incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txt_pass.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario es incorrecto", "Usuario incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txt_usuario.Clear();
                    txt_pass.Clear();
                }
            }
            else
            {
                MessageBox.Show("Ha superado la cantidad de intentos\nEl programa procedera a cerrarse", "Intentos excedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Application.Exit();

                conexion.Close();
            }
        }

        private void btn_cambiar_Click(object sender, EventArgs e)
        {
            CambiarContraseña abre = new CambiarContraseña();
            abre.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El usuario y la contraseña se le fueron\nproporcionados junto al nombramiento." +
                "\nPara más información, hable con el Encargado del Departamento.", "Recordar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
