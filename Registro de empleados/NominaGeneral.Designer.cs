
namespace Registro_de_empleados
{
    partial class NominaGeneral
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NominaGeneral));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.empleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nóminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarNóminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeNóminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nominaDataGridView = new System.Windows.Forms.DataGridView();
            this.corresponde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigonomina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoempleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreapellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sueldobruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horasextras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sueldoneto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominaLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nominaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empleadoToolStripMenuItem,
            this.nóminaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(941, 24);
            this.menuStrip1.TabIndex = 73;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // empleadoToolStripMenuItem
            // 
            this.empleadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarEmpleadosToolStripMenuItem,
            this.buscarEmpleadoToolStripMenuItem});
            this.empleadoToolStripMenuItem.Name = "empleadoToolStripMenuItem";
            this.empleadoToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.empleadoToolStripMenuItem.Text = "Empleado";
            // 
            // mostrarEmpleadosToolStripMenuItem
            // 
            this.mostrarEmpleadosToolStripMenuItem.Name = "mostrarEmpleadosToolStripMenuItem";
            this.mostrarEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mostrarEmpleadosToolStripMenuItem.Text = "Mostrar empleados";
            this.mostrarEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.mostrarEmpleadosToolStripMenuItem_Click);
            // 
            // buscarEmpleadoToolStripMenuItem
            // 
            this.buscarEmpleadoToolStripMenuItem.Name = "buscarEmpleadoToolStripMenuItem";
            this.buscarEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.buscarEmpleadoToolStripMenuItem.Text = "Buscar empleado";
            this.buscarEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.buscarEmpleadoToolStripMenuItem_Click);
            // 
            // nóminaToolStripMenuItem
            // 
            this.nóminaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarNóminaToolStripMenuItem,
            this.historialDeNóminaToolStripMenuItem});
            this.nóminaToolStripMenuItem.Name = "nóminaToolStripMenuItem";
            this.nóminaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.nóminaToolStripMenuItem.Text = "Nómina";
            // 
            // mostrarNóminaToolStripMenuItem
            // 
            this.mostrarNóminaToolStripMenuItem.Name = "mostrarNóminaToolStripMenuItem";
            this.mostrarNóminaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarNóminaToolStripMenuItem.Text = "Mostrar nómina";
            this.mostrarNóminaToolStripMenuItem.Click += new System.EventHandler(this.mostrarNóminaToolStripMenuItem_Click);
            // 
            // historialDeNóminaToolStripMenuItem
            // 
            this.historialDeNóminaToolStripMenuItem.Name = "historialDeNóminaToolStripMenuItem";
            this.historialDeNóminaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.historialDeNóminaToolStripMenuItem.Text = "Historial de nómina";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Registro_de_empleados.Properties.Resources.WocSoft;
            this.pictureBox1.Location = new System.Drawing.Point(305, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 107;
            this.pictureBox1.TabStop = false;
            // 
            // nominaDataGridView
            // 
            this.nominaDataGridView.AllowUserToAddRows = false;
            this.nominaDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nominaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.nominaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nominaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.corresponde,
            this.codigonomina,
            this.codigoempleado,
            this.nombreapellido,
            this.cargo,
            this.departamento,
            this.estado,
            this.sueldobruto,
            this.ars,
            this.afp,
            this.isr,
            this.horasextras,
            this.aumento,
            this.descuento,
            this.sueldoneto});
            this.nominaDataGridView.Location = new System.Drawing.Point(12, 126);
            this.nominaDataGridView.Name = "nominaDataGridView";
            this.nominaDataGridView.ReadOnly = true;
            this.nominaDataGridView.Size = new System.Drawing.Size(917, 484);
            this.nominaDataGridView.TabIndex = 108;
            // 
            // corresponde
            // 
            this.corresponde.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.corresponde.HeaderText = "Correspondiente a";
            this.corresponde.Name = "corresponde";
            this.corresponde.ReadOnly = true;
            this.corresponde.Width = 132;
            // 
            // codigonomina
            // 
            this.codigonomina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigonomina.HeaderText = "Código Nómina";
            this.codigonomina.Name = "codigonomina";
            this.codigonomina.ReadOnly = true;
            this.codigonomina.Width = 105;
            // 
            // codigoempleado
            // 
            this.codigoempleado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigoempleado.HeaderText = "Código Empleado";
            this.codigoempleado.Name = "codigoempleado";
            this.codigoempleado.ReadOnly = true;
            this.codigoempleado.Width = 114;
            // 
            // nombreapellido
            // 
            this.nombreapellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombreapellido.HeaderText = "Nombre y Apellido";
            this.nombreapellido.Name = "nombreapellido";
            this.nombreapellido.ReadOnly = true;
            this.nombreapellido.Width = 120;
            // 
            // cargo
            // 
            this.cargo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cargo.HeaderText = "Cargo";
            this.cargo.Name = "cargo";
            this.cargo.ReadOnly = true;
            this.cargo.Width = 66;
            // 
            // departamento
            // 
            this.departamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.departamento.HeaderText = "Departamento";
            this.departamento.Name = "departamento";
            this.departamento.ReadOnly = true;
            this.departamento.Width = 108;
            // 
            // estado
            // 
            this.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 67;
            // 
            // sueldobruto
            // 
            this.sueldobruto.HeaderText = "Sueldo Bruto";
            this.sueldobruto.Name = "sueldobruto";
            this.sueldobruto.ReadOnly = true;
            // 
            // ars
            // 
            this.ars.HeaderText = "ARS";
            this.ars.Name = "ars";
            this.ars.ReadOnly = true;
            // 
            // afp
            // 
            this.afp.HeaderText = "AFP";
            this.afp.Name = "afp";
            this.afp.ReadOnly = true;
            // 
            // isr
            // 
            this.isr.HeaderText = "ISR";
            this.isr.Name = "isr";
            this.isr.ReadOnly = true;
            // 
            // horasextras
            // 
            this.horasextras.HeaderText = "Horas Extras";
            this.horasextras.Name = "horasextras";
            this.horasextras.ReadOnly = true;
            // 
            // aumento
            // 
            this.aumento.HeaderText = "Aumento";
            this.aumento.Name = "aumento";
            this.aumento.ReadOnly = true;
            // 
            // descuento
            // 
            this.descuento.HeaderText = "Descuento";
            this.descuento.Name = "descuento";
            this.descuento.ReadOnly = true;
            // 
            // sueldoneto
            // 
            this.sueldoneto.HeaderText = "Sueldo Neto";
            this.sueldoneto.Name = "sueldoneto";
            this.sueldoneto.ReadOnly = true;
            // 
            // nominaLabel
            // 
            this.nominaLabel.AutoSize = true;
            this.nominaLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nominaLabel.Location = new System.Drawing.Point(578, 90);
            this.nominaLabel.Name = "nominaLabel";
            this.nominaLabel.Size = new System.Drawing.Size(271, 19);
            this.nominaLabel.TabIndex = 109;
            this.nominaLabel.Text = "Se agregará la nómina del mes actual el día ";
            // 
            // NominaGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 622);
            this.ControlBox = false;
            this.Controls.Add(this.nominaLabel);
            this.Controls.Add(this.nominaDataGridView);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NominaGeneral";
            this.Text = "Nomina General";
            this.Load += new System.EventHandler(this.NominaGeneral_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nominaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem empleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nóminaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarNóminaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeNóminaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView nominaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn corresponde;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigonomina;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoempleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreapellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn sueldobruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ars;
        private System.Windows.Forms.DataGridViewTextBoxColumn afp;
        private System.Windows.Forms.DataGridViewTextBoxColumn isr;
        private System.Windows.Forms.DataGridViewTextBoxColumn horasextras;
        private System.Windows.Forms.DataGridViewTextBoxColumn aumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn sueldoneto;
        private System.Windows.Forms.Label nominaLabel;
    }
}