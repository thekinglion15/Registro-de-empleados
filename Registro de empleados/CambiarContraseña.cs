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
    public partial class CambiarContraseña : Form
    {
        static readonly string conexionstring = "Server=THE-KING-LION\\SQLEXPRESS; Database=SICPB; integrated security=True; MultipleActiveResultSets=True";
        static readonly SqlConnection conexion = new SqlConnection(conexionstring);

        public CambiarContraseña()
        {
            InitializeComponent();
        }

        private void CambiarContraseña_Load(object sender, EventArgs e)
        {
            conexion.Open();
        }

        private void btn_cambiar_Click(object sender, EventArgs e)
        {
            string cadena = "select passwordadmin from login";

            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader lector = comando.ExecuteReader();

            lector.Read();

            string passadmin = lector["passwordadmin"].ToString();

            if (txt_passadmin.Text.Equals(passadmin))
            {
                if (txt_nueva.Text.Equals(txt_confirm.Text))
                {
                    cadena = "update login set contrasenia = '" + txt_nueva.Text + "'";

                    SqlCommand comando2 = new SqlCommand(cadena, conexion);
                    comando2.ExecuteNonQuery();

                    MessageBox.Show("La contraseña ha sido cambiada", "Contraseña guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    conexion.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña no es la misma", "Contraseña incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txt_passadmin.Clear();
                    txt_nueva.Clear();
                    txt_confirm.Clear();

                    return;
                }
            }
            else
            {
                MessageBox.Show("La contraseña del encargado es incorrecto", "Contraseña incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txt_passadmin.Clear();
                txt_nueva.Clear();
                txt_confirm.Clear();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();

            conexion.Close();
        }
    }
}
