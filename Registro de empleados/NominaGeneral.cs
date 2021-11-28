using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Registro_de_empleados
{
    public partial class NominaGeneral : Form
    {
        static readonly string conexionstring = "Server=THE-KING-LION\\SQLEXPRESS; Database=SICPB; integrated security=True; MultipleActiveResultSets=True";
        static readonly SqlConnection conexion = new SqlConnection(conexionstring);

        static DateTime hoy = DateTime.Now;
        static DateTime primerDia = new DateTime(hoy.Year, hoy.Month, 1);
        static DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);

        public NominaGeneral()
        {
            InitializeComponent();

            nominaLabel.Text += ultimoDia.ToString("d");
        }

        private void NominaGeneral_Load(object sender, EventArgs e)
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

            string año, corresponde, codigonomina, codigoempleado, cadena, nombre, apellido, cargo, departamento, estado;
            double sueldobruto, ars, afp, isr, horasextras, descuento, aumento, sueldoneto;
            int mes, contador = 0;

            cadena = "select n.*, e.nombre, e.apellido, e.cargo, e.departamento, e.estado from nominageneral n, empleados e where n.codigoempleado = e.codigo;";

            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                codigonomina = lector["codigonomina"].ToString();
                codigoempleado = lector["codigoempleado"].ToString();
                sueldobruto = Convert.ToDouble(lector["sueldobruto"].ToString());
                ars = Convert.ToDouble(lector["ars"].ToString());
                afp = Convert.ToDouble(lector["afp"].ToString());
                isr = Convert.ToDouble(lector["isr"].ToString());
                horasextras = Convert.ToInt32(lector["horasextras"].ToString());
                aumento = Convert.ToDouble(lector["aumento"].ToString());
                descuento = Convert.ToDouble(lector["descuento"].ToString());
                sueldoneto = Convert.ToDouble(lector["sueldoneto"].ToString());
                nombre = lector["nombre"].ToString();
                apellido = lector["apellido"].ToString();
                cargo = lector["cargo"].ToString();
                departamento = lector["departamento"].ToString();
                estado = lector["estado"].ToString();

                año = codigonomina.Substring(0, 4);
                mes = Convert.ToInt32(codigonomina.Substring(4, 2));

                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(mes);
                corresponde = nombreMes + " " + año;
                nombre = nombre + " " + apellido; 

                nominaDataGridView.Rows.Add(1);
                nominaDataGridView.Rows[contador].Cells[0].Value = corresponde;
                nominaDataGridView.Rows[contador].Cells[1].Value = codigonomina;
                nominaDataGridView.Rows[contador].Cells[2].Value = codigoempleado;
                nominaDataGridView.Rows[contador].Cells[3].Value = nombre;
                nominaDataGridView.Rows[contador].Cells[4].Value = cargo;
                nominaDataGridView.Rows[contador].Cells[5].Value = departamento;
                nominaDataGridView.Rows[contador].Cells[6].Value = estado;
                nominaDataGridView.Rows[contador].Cells[7].Value = sueldobruto;
                nominaDataGridView.Rows[contador].Cells[8].Value = ars;
                nominaDataGridView.Rows[contador].Cells[9].Value = afp;
                nominaDataGridView.Rows[contador].Cells[10].Value = isr;
                nominaDataGridView.Rows[contador].Cells[11].Value = horasextras;
                nominaDataGridView.Rows[contador].Cells[12].Value = aumento;
                nominaDataGridView.Rows[contador].Cells[13].Value = descuento;
                nominaDataGridView.Rows[contador].Cells[14].Value = sueldoneto;

                contador++;
            }

            conexion.Close();
        }

        private void mostrarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro abre = new Registro();
            abre.Show();
            this.Hide();
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
    }
}
