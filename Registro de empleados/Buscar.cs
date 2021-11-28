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
using System.IO;
using System.Drawing.Imaging;

namespace Registro_de_empleados
{
    public partial class Buscar: Form
    {
        static readonly string conexionstring = "Server=THE-KING-LION\\SQLEXPRESS; Database=SICPB; integrated security=True; MultipleActiveResultSets=True";
        static readonly SqlConnection conexion = new SqlConnection(conexionstring);

        public Buscar()
        {
            InitializeComponent();
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog agregar = new OpenFileDialog
            {
                Title = "Buscar imagen",
                Filter = "Imagenes |*.jpg",

                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (agregar.ShowDialog() == DialogResult.OK)
            {
                fotoPictureBox.Image = Image.FromFile(agregar.FileName);
            }
        }

        private void buscarToolStripButton_Click(object sender, EventArgs e)
        {
            if(conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("Digite la cédula del empleado", "Buscar");
            string cadenaexiste = "select COUNT(*) from empleados where cedula = '" + input + "'";
            SqlCommand comandoexiste = new SqlCommand(cadenaexiste, conexion);

            int existe = Convert.ToInt32(comandoexiste.ExecuteScalar());

            if (existe == 1)
            {
                string cadena = "select * from empleados where cedula = '" + input + "'";

                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                lector.Read();

                cedulaTextBox.Text = input;
                codigoTextBox.Text = lector["codigo"].ToString();
                nombreTextBox.Text = lector["nombre"].ToString();
                apellidoTextBox.Text = lector["apellido"].ToString();
                telefonoMaskedTextBox.Text = lector["telefono"].ToString();
                direccionTextBox.Text = lector["direccion"].ToString();
                correoTextBox.Text = lector["correo"].ToString();
                comentarioempleadoTextBox.Text = lector["comentarioempleado"].ToString();
                sexoComboBox.Text = lector["sexo"].ToString();
                estadocivilComboBox.Text = lector["estadocivil"].ToString();
                nivelacademicoComboBox.Text = lector["nivelacademico"].ToString();
                cargoComboBox.Text = lector["cargo"].ToString();
                departamentoComboBox.Text = lector["departamento"].ToString();
                estadoComboBox.Text = lector["estado"].ToString();
                nacimientoDateTimePicker.Text = lector["nacimiento"].ToString();
                fechaingresoDateTimePicker.Text = lector["fechaingreso"].ToString();

                cedulaTextBox.Enabled = true;
                codigoTextBox.Enabled = true;
                nombreTextBox.Enabled = true;
                apellidoTextBox.Enabled = true;
                telefonoMaskedTextBox.Enabled = true;
                direccionTextBox.Enabled = true;
                correoTextBox.Enabled = true;
                comentarioempleadoTextBox.Enabled = true;
                sexoComboBox.Enabled = true;
                estadocivilComboBox.Enabled = true;
                nivelacademicoComboBox.Enabled = true;
                cargoComboBox.Enabled = true;
                departamentoComboBox.Enabled = true;
                estadoComboBox.Enabled = true;
                nacimientoDateTimePicker.Enabled = true;
                fechaingresoDateTimePicker.Enabled = true;

                try
                {
                    if (lector.HasRows)
                    {
                        MemoryStream memoria = new MemoryStream((byte[])lector["foto"]);
                        Bitmap mapabit = new Bitmap(memoria);
                        fotoPictureBox.Image = mapabit;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                try
                {
                    cedulaTextBox.Clear();
                    codigoTextBox.Clear();
                    nombreTextBox.Clear();
                    apellidoTextBox.Clear();
                    telefonoMaskedTextBox.Clear();
                    direccionTextBox.Clear();
                    correoTextBox.Clear();
                    comentarioempleadoTextBox.Clear();
                    sexoComboBox.SelectedIndex = 0;
                    estadocivilComboBox.SelectedIndex = 0;
                    nivelacademicoComboBox.SelectedIndex = 0;
                    cargoComboBox.SelectedIndex = 0;
                    departamentoComboBox.SelectedIndex = 0;
                    estadoComboBox.SelectedIndex = 0;
                    nacimientoDateTimePicker.Value = DateTime.Today;
                    fechaingresoDateTimePicker.Value = DateTime.Today;
                    fotoPictureBox.Image = null;
                
                    MessageBox.Show("Esta cédula no esta registrada", "No se encontro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                catch (Exception)
                {
                    return;
                }
            }
            
            conexion.Close();
        }

        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {
            conexion.Open();

            if(cedulaTextBox.Text == string.Empty)
            {
                MessageBox.Show("Busque al empleado", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombre, apellido, fecha, codigoempleado;

            nombre = nombreTextBox.Text;
            apellido = apellidoTextBox.Text;
            fecha = nacimientoDateTimePicker.Value.ToString();

            codigoempleado = nombre.Substring(0, 1);
            codigoempleado += apellido.Substring(0, 1);

            codigoempleado += fecha.Substring(0, 2);
            codigoempleado += fecha.Substring(3, 2);
            codigoempleado += fecha.Substring(6, 4);

            codigoTextBox.Text = codigoempleado;

            MemoryStream memoria = new MemoryStream();

            if(fotoPictureBox != null)
            {
                fotoPictureBox.Image.Save(memoria, ImageFormat.Jpeg);
            }
            else
            {
                return;
            }

            Byte[] arrbyte = memoria.ToArray();


            string cadena = "update empleados set codigo = '" + codigoTextBox.Text + "', nombre = '" + nombreTextBox.Text + "', apellido = '" + apellidoTextBox.Text + "'," +
                            "sexo = '" + sexoComboBox.Text + "', nacimiento = '" + nacimientoDateTimePicker.Text + "', estadocivil = '" + estadocivilComboBox.Text + "'," +
                            "telefono = '" + telefonoMaskedTextBox.Text + "', direccion = '" + direccionTextBox.Text + "', correo = '" + correoTextBox.Text + "', " +
                            "nivelacademico = '" + nivelacademicoComboBox.Text + "', cargo = '" + cargoComboBox.Text + "', departamento = '" + departamentoComboBox.Text + "', " +
                            "fechaingreso = '" + fechaingresoDateTimePicker.Text + "', estado = '" + estadoComboBox.Text + "', comentarioempleado = '" + comentarioempleadoTextBox.Text + "', foto = @imagen where cedula = '" + cedulaTextBox.Text + "'";

            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("imagen", arrbyte);
            comando.ExecuteNonQuery();

            DialogResult resultado = MessageBox.Show("Registro actualizado correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (resultado == DialogResult.OK)
            {
                cedulaTextBox.Enabled = false;
                codigoTextBox.Enabled = false;
                nombreTextBox.Enabled = false;
                apellidoTextBox.Enabled = false;
                telefonoMaskedTextBox.Enabled = false;
                direccionTextBox.Enabled = false;
                correoTextBox.Enabled = false;
                comentarioempleadoTextBox.Enabled = false;
                sexoComboBox.Enabled = false;
                estadocivilComboBox.Enabled = false;
                nivelacademicoComboBox.Enabled = false;
                cargoComboBox.Enabled = false;
                departamentoComboBox.Enabled = false;
                estadoComboBox.Enabled = false;
                nacimientoDateTimePicker.Enabled = false;
                fechaingresoDateTimePicker.Enabled = false;
            }

            conexion.Close();
        }

        private void mostrarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro abre = new Registro();
            abre.Show();
            this.Hide();
        }

        private void mostrarNóminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina abre = new Nomina();
            abre.Show();
            this.Hide();
        }

        private void historialDeNóminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NominaGeneral abre = new NominaGeneral();
            abre.Show();
            this.Hide();
        }
    }
}
