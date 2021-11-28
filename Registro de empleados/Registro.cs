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
using SpreadsheetLight;

namespace Registro_de_empleados
{
    public partial class Registro : Form
    {
        static readonly string conexionstring = "Server=THE-KING-LION\\SQLEXPRESS; Database=SICPB; integrated security=True; MultipleActiveResultSets=True";
        static readonly SqlConnection conexion = new SqlConnection(conexionstring);

        bool visible = true;
        int contador = 0;

        public void ocultaText()
        {
            contador++;

            if (visible)
            {
                conexion.Open();
                string cadena = "select nombre,apellido from login ";

                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                lector.Read();

                usuarioLabel.Text += "Bienvenido: \n";

                usuarioLabel.Text += lector["nombre"].ToString() + " ";
                usuarioLabel.Text += lector["apellido"].ToString();
                visible = false;
            }
            if (contador >= 10) 
            {
                usuarioLabel.Hide();
                timer2.Stop();
            }

            conexion.Close();
        }

        public static bool ValidarCedula(String cedula)
        {
            int total = 0, noValidador = 0, validacion;
            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
            {
                numeros[i] = Convert.ToInt32(cedula.Substring(i, 1));
                noValidador = numeros[i];
            }

            for (int i = 9; i >= 0; i -= 2)
            {
                int temporal = numeros[i];
                temporal *= 2;

                if (temporal > 9)
                {
                    temporal = temporal % 10 + 1;
                }
                numeros[i] = temporal;
            }

            for (int i = 0; i < 10; i++)
            {
                total += numeros[i];
            }

            validacion = total + noValidador;

            return validacion % 10 == 0;
        }
        
        public void guardaNomina(string codigo, string estado)
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

            string cadenaexiste = "select COUNT(*) from nomina where codigo = '" + codigo + "'";
            SqlCommand comandoexiste = new SqlCommand(cadenaexiste, conexion);
            int existe = Convert.ToInt32(comandoexiste.ExecuteScalar());

            if (estado == "Activo" && existe == 0)
            {
                string cadena = "insert into nomina ([codigo], [sueldobruto], [ars], [afp], [isr], [horasextras], [aumento], [descuento], [sueldoneto]) " +
                                "values ('" + codigo + "', '0', '0', '0', '0', '0', '0', '0', '0')";

                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
            }
            else if (estado == "Activo" && existe == 1)
            {
                return;
            }
            else if (estado != "Activo")
            {
                MessageBox.Show("El empleado no aparecera en nómina\nmientras su estado no sea activo", "Empleado no activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            conexion.Close();
        }

        public Registro()
        {
            InitializeComponent();

            timer2.Start();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sICPBDataSet.login' Puede moverla o quitarla según sea necesario.
            this.loginTableAdapter.Fill(this.sICPBDataSet.login);
            // TODO: esta línea de código carga datos en la tabla 'sICPBDataSet.empleados' Puede moverla o quitarla según sea necesario.
            this.empleadosTableAdapter.Fill(this.sICPBDataSet.empleados);
            // TODO: esta línea de código carga datos en la tabla 'sICPBDataSet.empleados' Puede moverla o quitarla según sea necesario.
            this.empleadosTableAdapter.Fill(this.sICPBDataSet.empleados);
        }

        private void Registro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            sexoComboBox.SelectedIndex = 0;
            estadocivilComboBox.SelectedIndex = 0;
            nivelacademicoComboBox.SelectedIndex = 0;
            cargoComboBox.SelectedIndex = 0;
            departamentoComboBox.SelectedIndex = 0;
            estadoComboBox.SelectedIndex = 0;
            nacimientoDateTimePicker.Value = DateTime.Today;
            fechaingresoDateTimePicker.Value = DateTime.Today;
        }

        private void empleadosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
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

            try
            {
                this.Validate();
                this.empleadosBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.sICPBDataSet);

                guardaNomina(codigoempleado, estadoComboBox.Text);
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private void cedulaTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (cedulaTextBox.Text.Length < 11)
            {
                e.Cancel = true;
                cedulaTextBox.Focus();
                errorProvider1.SetError(cedulaTextBox, "La cédula esta compuesta por 11 digitos");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cedulaTextBox, null);

                if (!ValidarCedula(cedulaTextBox.Text))
                {
                    e.Cancel = true;
                    cedulaTextBox.Focus();
                    errorProvider1.SetError(cedulaTextBox, "La cédula no es válida. \nCódigo verificador invalido.");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(cedulaTextBox, null);
                    return;
                }
            }
        }

        private void buscarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar abre = new Buscar();
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            ocultaText();
        }
    }
}
