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
using System.IO;

namespace Registro_de_empleados
{
    public partial class Nomina : Form
    {
        static readonly string conexionstring = "Server=THE-KING-LION\\SQLEXPRESS; Database=SICPB; integrated security=True; MultipleActiveResultSets=True";
        static readonly SqlConnection conexion = new SqlConnection(conexionstring);

        static double sueldobruto = 0, sueldoanual = 0, deducciones = 0, ars = 0, afp = 0, isr = 0, descuento = 0, aumento = 0, sueldoneto = 0;

        static DateTime hoy = DateTime.Now;
        static DateTime primerDia = new DateTime(hoy.Year, hoy.Month, 1);
        static DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);

        public void calculaPrestaciones()
        {
            try
            {
                sueldobruto = Convert.ToDouble(sueldobrutoTextBox1.Text);

                ars = sueldobruto * 0.0304;
                afp = sueldobruto * 0.0287;

                deducciones = sueldobruto - (ars + afp);
                sueldoanual = deducciones * 12;

                if (sueldoanual <= 416220.00)
                {
                    isr = 0;
                }
                else if (sueldoanual >= 416220.01 && sueldoanual <= 624329.00)
                {
                    isr = (sueldoanual - 416220.01);
                    isr *= 0.15;
                    isr /= 12;
                }
                else if (sueldoanual >= 624329.01 && sueldoanual <= 867123.00)
                {
                    isr = (sueldoanual - 624329.01);
                    isr *= 0.2;
                    isr += 31216.00;
                    isr /= 12;
                }
                else if (sueldoanual >= 867123.01)
                {
                    isr = (sueldoanual - 867123.01);
                    isr *= 0.25;
                    isr += 79776;
                    isr /= 12;
                }

                descuento = ars + afp + isr;
                sueldoneto = sueldobruto - descuento;
                aumento = (sueldoneto * 0.01) * Convert.ToInt32(horasextrasNumericUpDown1.Value);
                sueldoneto += aumento;
            }
            catch (Exception)
            {
                return;
            }
        }

        public void guardaNominaGeneral()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

            string codigonomina = ultimoDia.ToString("yyyy") + ultimoDia.ToString("MM");
            string codigo, cadenaGeneral, cadenaNomina;
            double sueldobrutonomina, arsnomina, afpnomina, isrnomina, horasextrasnomina, descuentonomina, aumentonomina, sueldonetonomina;
            SqlCommand comandoNominaGeneral;

            cadenaNomina = "select * from nomina";

            SqlCommand comandoNomina = new SqlCommand(cadenaNomina, conexion);
            SqlDataReader lectorNomina = comandoNomina.ExecuteReader();
            
            while (lectorNomina.Read())
            {
                codigo = lectorNomina["codigo"].ToString();
                sueldobrutonomina = Convert.ToDouble(lectorNomina["sueldobruto"].ToString());
                arsnomina = Convert.ToDouble(lectorNomina["ars"].ToString());
                afpnomina = Convert.ToDouble(lectorNomina["afp"].ToString());
                isrnomina = Convert.ToDouble(lectorNomina["isr"].ToString());
                horasextrasnomina = Convert.ToInt32(lectorNomina["horasextras"].ToString());
                aumentonomina = Convert.ToDouble(lectorNomina["aumento"].ToString());
                descuentonomina = Convert.ToDouble(lectorNomina["descuento"].ToString());
                sueldonetonomina = Convert.ToDouble(lectorNomina["sueldoneto"].ToString());

                cadenaGeneral = "insert into nominageneral ([codigonomina], [codigoempleado], [sueldobruto], [ars], [afp], [isr], [horasextras], [aumento], [descuento], [sueldoneto]) " +
                                "values ('" + codigonomina + "', '" + codigo + "', '" + sueldobrutonomina + "', '" + arsnomina + "', '" + afpnomina + "', '" + isrnomina + "', " +
                                "'" + horasextrasnomina + "', '" + aumentonomina + "', '" + descuentonomina + "', '" + sueldonetonomina + "')";

                comandoNominaGeneral = new SqlCommand(cadenaGeneral, conexion);
                comandoNominaGeneral.ExecuteNonQuery();
            }

            conexion.Close();
        }

        public Nomina()
        {
            InitializeComponent();
        }

        private void Nomina_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sICPBDataSet.nomina' Puede moverla o quitarla según sea necesario.
            this.nominaTableAdapter.Fill(this.sICPBDataSet.nomina);

            if (ultimoDia.ToString("d") == hoy.ToString("d"))
            {
                exportarExcel();
                guardaNominaGeneral();
            }
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

        private void historialDeNóminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NominaGeneral abre = new NominaGeneral();
            abre.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardaNominaGeneral();

            MessageBox.Show("Datos guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nominaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            calculaPrestaciones();
            sueldobrutoTextBox1.Text = Math.Round(sueldobruto, 2, MidpointRounding.ToEven).ToString("N2");
            arsTextBox1.Text = Math.Round(ars, 2, MidpointRounding.ToEven).ToString("N2");
            afpTextBox1.Text = Math.Round(afp, 2, MidpointRounding.ToEven).ToString("N2");
            isrTextBox1.Text = Math.Round(isr, 2, MidpointRounding.ToEven).ToString("N2");
            descuentoTextBox1.Text = Math.Round(descuento, 2, MidpointRounding.ToEven).ToString("N2");
            aumentoTextBox1.Text = Math.Round(aumento, 2, MidpointRounding.ToEven).ToString("N2");
            sueldonetoTextBox1.Text = Math.Round(sueldoneto, 2, MidpointRounding.ToEven).ToString("N2");

            this.Validate();
            this.nominaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sICPBDataSet);
        }

        private void exportarToolStripButton_Click(object sender, EventArgs e)
        {
            exportarExcel();
        }

        private void codigoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

            string cadena = "select cedula, nombre, apellido, cargo, departamento, foto from empleados where codigo = '" + codigoTextBox.Text + "'";

            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader lector = comando.ExecuteReader();

            lector.Read();

            cedulaTextBox1.Text = lector["cedula"].ToString();
            nombreTextBox1.Text = lector["nombre"].ToString();
            apellidoTextBox1.Text = lector["apellido"].ToString();
            cargoTextBox.Text = lector["cargo"].ToString();
            departamentoTextBox.Text = lector["departamento"].ToString();

            try
            {
                if (lector.HasRows)
                {
                    MemoryStream memoria = new MemoryStream((byte[])lector["foto"]);
                    Bitmap mapabit = new Bitmap(memoria);
                    fotoPictureBox1.Image = mapabit;
                }
            }
            catch (Exception)
            {
                fotoPictureBox1.Image = null;
                return;
            }

            conexion.Close();
        }

        public void exportarExcel()
        {
            conexion.Open();

            SLDocument excel = new SLDocument();

            estiloTitulos(excel);

            int celdaContenido = 6, celdaInicial = 6;
            string codigo;
            string mes = new System.Globalization.CultureInfo("es-ES", false).TextInfo.ToTitleCase(ultimoDia.ToString("MMMM").ToLower());
            string cadenaEmpleado, cadenaNomina = "select codigo, sueldobruto, aumento, descuento, sueldoneto from nomina";

            excel.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Nomina " + mes + " " + ultimoDia.Year);

            excel.SetCellValue("B" + celdaContenido, "Codigo");
            excel.SetCellValue("C" + celdaContenido, "Nombre y Apellido");
            excel.SetCellValue("D" + celdaContenido, "Cargo");
            excel.SetCellValue("E" + celdaContenido, "Departamento");
            excel.SetCellValue("F" + celdaContenido, "Sueldo Bruto");
            excel.SetCellValue("G" + celdaContenido, "Otros ingresos");
            excel.SetCellValue("H" + celdaContenido, "Descuentos");
            excel.SetCellValue("I" + celdaContenido, "Sueldo Neto");

            estiloEncabezado(excel);

            SqlCommand comandoEmpleado;
            SqlDataReader lectorEmpleado;

            SqlCommand comandoNomina = new SqlCommand(cadenaNomina, conexion);
            SqlDataReader lectorNomina = comandoNomina.ExecuteReader();

            while (lectorNomina.Read())
            {
                celdaContenido++;
                codigo = lectorNomina["codigo"].ToString();

                cadenaEmpleado = "select nombre, apellido, cargo, departamento from empleados where codigo = '" + codigo + "'";
                comandoEmpleado = new SqlCommand(cadenaEmpleado, conexion);
                lectorEmpleado = comandoEmpleado.ExecuteReader();
                lectorEmpleado.Read();

                excel.SetCellValue("B" + celdaContenido, codigo);
                excel.SetCellValue("C" + celdaContenido, (lectorEmpleado["nombre"].ToString() + " " + lectorEmpleado["apellido"].ToString()));
                excel.SetCellValue("D" + celdaContenido, lectorEmpleado["cargo"].ToString());
                excel.SetCellValue("E" + celdaContenido, lectorEmpleado["departamento"].ToString());
                excel.SetCellValue("F" + celdaContenido, Convert.ToDouble(lectorNomina["sueldobruto"].ToString()));
                excel.SetCellValue("G" + celdaContenido, Convert.ToDouble(lectorNomina["aumento"].ToString()));
                excel.SetCellValue("H" + celdaContenido, Convert.ToDouble(lectorNomina["descuento"].ToString()));
                excel.SetCellValue("I" + celdaContenido, Convert.ToDouble(lectorNomina["sueldoneto"].ToString()));
            }

            estiloContenido(excel, celdaInicial, celdaContenido);
            formulas(excel, celdaInicial, celdaContenido);

            excel.AutoFitColumn("B", "I");

            excel.SaveAs("C:/Users/gabri/Desktop/Nomina " + mes + " " + ultimoDia.Year + ".xlsx");

            conexion.Close();
        }

        public void estiloTitulos(SLDocument documento)
        {
            documento.SetCellValue("B1", "WOCSOFT");
            documento.SetCellValue("B2", "LISTADO PERSONAL EN NOMINA");
            documento.SetCellValue("B3", ("MES DE " + ultimoDia.ToString("MMMM").ToUpper() + " DEL AÑO " + ultimoDia.Year));
            documento.SetCellValue("B4", "VALORES EN RD$");

            SLStyle estilo = documento.CreateStyle();
            estilo.Font.FontName = "Times New Roman";
            estilo.Font.FontSize = 14;
            estilo.Font.Bold = true;
            estilo.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);

            documento.SetCellStyle("B1", "B4", estilo);

            documento.MergeWorksheetCells("B1", "I1");
            documento.MergeWorksheetCells("B2", "I2");
            documento.MergeWorksheetCells("B3", "I3");
            documento.MergeWorksheetCells("B4", "I4");
        }

        public void estiloEncabezado(SLDocument documento)
        {
            SLStyle estilo = documento.CreateStyle();
            estilo.Font.FontName = "Times New Roman";
            estilo.Font.FontSize = 12;
            estilo.Font.Bold = true;
            estilo.Font.FontColor = System.Drawing.Color.Black;
            estilo.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(149, 179, 215), System.Drawing.Color.FromArgb(149, 179, 215));
            estilo.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
            estilo.Border.LeftBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            estilo.Border.RightBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            estilo.Border.TopBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            estilo.Border.BottomBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;

            documento.SetCellStyle("B6", "I6", estilo);
        }

        public void estiloContenido(SLDocument documento, int celdaInicial, int celdaFinal)
        {
            celdaInicial++;
            celdaFinal++;

            SLStyle estilo = documento.CreateStyle();
            estilo.Font.FontName = "Times New Roman";
            estilo.Font.FontSize = 12;
            estilo.Border.LeftBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            estilo.Border.RightBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            estilo.Border.TopBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            estilo.Border.BottomBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;

            documento.SetCellStyle("B" + celdaInicial, "I" + celdaFinal, estilo);
        }

        public void formulas(SLDocument documento, int celdaInicial, int celdaFinal)
        {
            celdaInicial++;
            celdaFinal++;

            int posicion = celdaFinal;
            int termina = --celdaFinal;

            documento.SetCellValue("B" + posicion, "Total empleados");
            documento.SetCellValue("C" + posicion, "=COUNTA(C" + celdaInicial + ":C" + termina + ")");
            documento.SetCellValue("E" + posicion, "Total nómina");
            documento.SetCellValue("F" + posicion, "=SUM(F" + celdaInicial + ":F" + termina + ")");
            documento.SetCellValue("G" + posicion, "=SUM(F" + celdaInicial + ":F" + termina + ")");
            documento.SetCellValue("H" + posicion, "=SUM(F" + celdaInicial + ":F" + termina + ")");
            documento.SetCellValue("I" + posicion, "=SUM(F" + celdaInicial + ":F" + termina + ")");


            SLStyle estilo1 = documento.CreateStyle();
            SLStyle estilo2 = documento.CreateStyle();
            SLStyle estilo3 = documento.CreateStyle();

            estilo1.FormatCode = "#,##0.00";
            estilo2.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left);
            estilo3.Font.FontName = "Times New Roman";
            estilo3.Font.FontSize = 12;
            estilo3.Font.Bold = true;

            documento.SetCellStyle("F" + celdaInicial, "I" + posicion, estilo1);
            documento.SetCellStyle("C" + posicion, estilo2);
            documento.SetCellStyle("B" + posicion, "I" + posicion, estilo3);
        }
    }
}
