namespace SistemaIndumaq.Resources.Vistas
{
    partial class FormVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabVentas = new System.Windows.Forms.TabControl();
            this.tabCatalogo = new System.Windows.Forms.TabPage();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.tabEditar = new System.Windows.Forms.TabPage();
            this.lblStockNumber = new System.Windows.Forms.Label();
            this.btnBorrarProd = new System.Windows.Forms.Button();
            this.dgvProductoVentas = new System.Windows.Forms.DataGridView();
            this.btnAgregarProd = new System.Windows.Forms.Button();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.panelProd = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblVentas = new System.Windows.Forms.Label();
            this.tabDetalle = new System.Windows.Forms.TabPage();
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.lblClienteV = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvProductoVentasV = new System.Windows.Forms.DataGridView();
            this.lblIdVentaValue = new System.Windows.Forms.Label();
            this.lblClienteVValue = new System.Windows.Forms.Label();
            this.lblFechaVValue = new System.Windows.Forms.Label();
            this.lblTotalVValue = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.tabVentas.SuspendLayout();
            this.tabCatalogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.tabEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductoVentas)).BeginInit();
            this.panelProd.SuspendLayout();
            this.tabDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductoVentasV)).BeginInit();
            this.SuspendLayout();
            // 
            // tabVentas
            // 
            this.tabVentas.Controls.Add(this.tabCatalogo);
            this.tabVentas.Controls.Add(this.tabEditar);
            this.tabVentas.Controls.Add(this.tabDetalle);
            this.tabVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVentas.Location = new System.Drawing.Point(0, 40);
            this.tabVentas.Name = "tabVentas";
            this.tabVentas.SelectedIndex = 0;
            this.tabVentas.Size = new System.Drawing.Size(598, 410);
            this.tabVentas.TabIndex = 5;
            // 
            // tabCatalogo
            // 
            this.tabCatalogo.Controls.Add(this.btnBorrar);
            this.tabCatalogo.Controls.Add(this.btnEditar);
            this.tabCatalogo.Controls.Add(this.btnAgregar);
            this.tabCatalogo.Controls.Add(this.dgvVentas);
            this.tabCatalogo.Controls.Add(this.btnBuscar);
            this.tabCatalogo.Controls.Add(this.txtBuscar);
            this.tabCatalogo.Controls.Add(this.lblBuscar);
            this.tabCatalogo.Location = new System.Drawing.Point(4, 22);
            this.tabCatalogo.Name = "tabCatalogo";
            this.tabCatalogo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCatalogo.Size = new System.Drawing.Size(590, 384);
            this.tabCatalogo.TabIndex = 0;
            this.tabCatalogo.Text = "Catálogo";
            this.tabCatalogo.UseVisualStyleBackColor = true;
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnBorrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.Location = new System.Drawing.Point(515, 133);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(66, 23);
            this.btnBorrar.TabIndex = 6;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(515, 104);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(66, 23);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "Ver";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(515, 75);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(66, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvVentas
            // 
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVentas.ColumnHeadersHeight = 30;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVentas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVentas.EnableHeadersVisualStyles = false;
            this.dgvVentas.Location = new System.Drawing.Point(6, 62);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVentas.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.dgvVentas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(503, 314);
            this.dgvVentas.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(515, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(66, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(3, 35);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(503, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(3, 15);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(87, 16);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar Venta";
            // 
            // tabEditar
            // 
            this.tabEditar.Controls.Add(this.lblStockNumber);
            this.tabEditar.Controls.Add(this.btnBorrarProd);
            this.tabEditar.Controls.Add(this.dgvProductoVentas);
            this.tabEditar.Controls.Add(this.btnAgregarProd);
            this.tabEditar.Controls.Add(this.cbCliente);
            this.tabEditar.Controls.Add(this.lblProducto);
            this.tabEditar.Controls.Add(this.cbProducto);
            this.tabEditar.Controls.Add(this.btnCancelar);
            this.tabEditar.Controls.Add(this.btnGuardar);
            this.tabEditar.Controls.Add(this.lblStock);
            this.tabEditar.Controls.Add(this.txtCantidad);
            this.tabEditar.Controls.Add(this.lblCantidad);
            this.tabEditar.Controls.Add(this.lblCliente);
            this.tabEditar.Controls.Add(this.txtId);
            this.tabEditar.Controls.Add(this.lblId);
            this.tabEditar.Location = new System.Drawing.Point(4, 22);
            this.tabEditar.Name = "tabEditar";
            this.tabEditar.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditar.Size = new System.Drawing.Size(590, 384);
            this.tabEditar.TabIndex = 1;
            this.tabEditar.Text = "Editar";
            this.tabEditar.UseVisualStyleBackColor = true;
            // 
            // lblStockNumber
            // 
            this.lblStockNumber.AutoSize = true;
            this.lblStockNumber.Location = new System.Drawing.Point(207, 101);
            this.lblStockNumber.Name = "lblStockNumber";
            this.lblStockNumber.Size = new System.Drawing.Size(0, 13);
            this.lblStockNumber.TabIndex = 18;
            // 
            // btnBorrarProd
            // 
            this.btnBorrarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnBorrarProd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnBorrarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarProd.ForeColor = System.Drawing.Color.White;
            this.btnBorrarProd.Location = new System.Drawing.Point(518, 117);
            this.btnBorrarProd.Name = "btnBorrarProd";
            this.btnBorrarProd.Size = new System.Drawing.Size(66, 23);
            this.btnBorrarProd.TabIndex = 17;
            this.btnBorrarProd.Text = "Borrar";
            this.btnBorrarProd.UseVisualStyleBackColor = false;
            this.btnBorrarProd.Click += new System.EventHandler(this.btnBorrarProd_Click);
            // 
            // dgvProductoVentas
            // 
            this.dgvProductoVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductoVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductoVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductoVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductoVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProductoVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductoVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProductoVentas.ColumnHeadersHeight = 30;
            this.dgvProductoVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductoVentas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProductoVentas.EnableHeadersVisualStyles = false;
            this.dgvProductoVentas.Location = new System.Drawing.Point(11, 117);
            this.dgvProductoVentas.Name = "dgvProductoVentas";
            this.dgvProductoVentas.ReadOnly = true;
            this.dgvProductoVentas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductoVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvProductoVentas.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.dgvProductoVentas.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProductoVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductoVentas.Size = new System.Drawing.Size(503, 232);
            this.dgvProductoVentas.TabIndex = 16;
            // 
            // btnAgregarProd
            // 
            this.btnAgregarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnAgregarProd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnAgregarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProd.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProd.Location = new System.Drawing.Point(397, 75);
            this.btnAgregarProd.Name = "btnAgregarProd";
            this.btnAgregarProd.Size = new System.Drawing.Size(66, 23);
            this.btnAgregarProd.TabIndex = 15;
            this.btnAgregarProd.Text = "Agregar";
            this.btnAgregarProd.UseVisualStyleBackColor = true;
            this.btnAgregarProd.Click += new System.EventHandler(this.btnAgregarProd_Click);
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(11, 77);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbCliente.Size = new System.Drawing.Size(149, 21);
            this.cbCliente.TabIndex = 14;
            this.cbCliente.Text = "- Seleccione -";
            this.cbCliente.SelectionChangeCommitted += new System.EventHandler(this.cbCliente_SelectionChangeCommitted);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(163, 61);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(50, 13);
            this.lblProducto.TabIndex = 13;
            this.lblProducto.Text = "Producto";
            // 
            // cbProducto
            // 
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Location = new System.Drawing.Point(166, 77);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbProducto.Size = new System.Drawing.Size(149, 21);
            this.cbProducto.TabIndex = 12;
            this.cbProducto.Text = "- Seleccione -";
            this.cbProducto.SelectionChangeCommitted += new System.EventHandler(this.cbProducto_SelectionChangeCommitted);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(166, 355);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(149, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(11, 355);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(149, 23);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(163, 101);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(38, 13);
            this.lblStock.TabIndex = 8;
            this.lblStock.Text = "Stock:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(321, 78);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(70, 20);
            this.txtCantidad.TabIndex = 7;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(318, 62);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 6;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(8, 61);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(11, 36);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(70, 20);
            this.txtId.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(8, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(54, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID Ventas";
            // 
            // panelProd
            // 
            this.panelProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.panelProd.Controls.Add(this.btnClose);
            this.panelProd.Controls.Add(this.lblVentas);
            this.panelProd.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProd.Location = new System.Drawing.Point(0, 0);
            this.panelProd.Name = "panelProd";
            this.panelProd.Size = new System.Drawing.Size(598, 40);
            this.panelProd.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(567, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblVentas
            // 
            this.lblVentas.AutoSize = true;
            this.lblVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentas.ForeColor = System.Drawing.Color.White;
            this.lblVentas.Location = new System.Drawing.Point(12, 13);
            this.lblVentas.Name = "lblVentas";
            this.lblVentas.Size = new System.Drawing.Size(68, 16);
            this.lblVentas.TabIndex = 2;
            this.lblVentas.Text = "VENTAS";
            // 
            // tabDetalle
            // 
            this.tabDetalle.Controls.Add(this.btnVolver);
            this.tabDetalle.Controls.Add(this.lblTotalVValue);
            this.tabDetalle.Controls.Add(this.lblFechaVValue);
            this.tabDetalle.Controls.Add(this.lblClienteVValue);
            this.tabDetalle.Controls.Add(this.lblIdVentaValue);
            this.tabDetalle.Controls.Add(this.dgvProductoVentasV);
            this.tabDetalle.Controls.Add(this.lblTotal);
            this.tabDetalle.Controls.Add(this.lblFecha);
            this.tabDetalle.Controls.Add(this.lblClienteV);
            this.tabDetalle.Controls.Add(this.lblIdVenta);
            this.tabDetalle.Location = new System.Drawing.Point(4, 22);
            this.tabDetalle.Name = "tabDetalle";
            this.tabDetalle.Size = new System.Drawing.Size(590, 384);
            this.tabDetalle.TabIndex = 2;
            this.tabDetalle.Text = "Detalle";
            this.tabDetalle.UseVisualStyleBackColor = true;
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.Location = new System.Drawing.Point(8, 18);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(52, 13);
            this.lblIdVenta.TabIndex = 0;
            this.lblIdVenta.Text = "ID Venta:";
            // 
            // lblClienteV
            // 
            this.lblClienteV.AutoSize = true;
            this.lblClienteV.Location = new System.Drawing.Point(8, 34);
            this.lblClienteV.Name = "lblClienteV";
            this.lblClienteV.Size = new System.Drawing.Size(42, 13);
            this.lblClienteV.TabIndex = 1;
            this.lblClienteV.Text = "Cliente:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(8, 50);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(8, 66);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total:";
            // 
            // dgvProductoVentasV
            // 
            this.dgvProductoVentasV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductoVentasV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductoVentasV.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductoVentasV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductoVentasV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProductoVentasV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductoVentasV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvProductoVentasV.ColumnHeadersHeight = 30;
            this.dgvProductoVentasV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductoVentasV.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvProductoVentasV.EnableHeadersVisualStyles = false;
            this.dgvProductoVentasV.Location = new System.Drawing.Point(11, 86);
            this.dgvProductoVentasV.Name = "dgvProductoVentasV";
            this.dgvProductoVentasV.ReadOnly = true;
            this.dgvProductoVentasV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductoVentasV.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvProductoVentasV.RowHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.dgvProductoVentasV.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvProductoVentasV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductoVentasV.Size = new System.Drawing.Size(503, 232);
            this.dgvProductoVentasV.TabIndex = 17;
            // 
            // lblIdVentaValue
            // 
            this.lblIdVentaValue.AutoSize = true;
            this.lblIdVentaValue.Location = new System.Drawing.Point(66, 18);
            this.lblIdVentaValue.Name = "lblIdVentaValue";
            this.lblIdVentaValue.Size = new System.Drawing.Size(35, 13);
            this.lblIdVentaValue.TabIndex = 18;
            this.lblIdVentaValue.Text = "label1";
            // 
            // lblClienteVValue
            // 
            this.lblClienteVValue.AutoSize = true;
            this.lblClienteVValue.Location = new System.Drawing.Point(66, 34);
            this.lblClienteVValue.Name = "lblClienteVValue";
            this.lblClienteVValue.Size = new System.Drawing.Size(35, 13);
            this.lblClienteVValue.TabIndex = 19;
            this.lblClienteVValue.Text = "label1";
            // 
            // lblFechaVValue
            // 
            this.lblFechaVValue.AutoSize = true;
            this.lblFechaVValue.Location = new System.Drawing.Point(66, 50);
            this.lblFechaVValue.Name = "lblFechaVValue";
            this.lblFechaVValue.Size = new System.Drawing.Size(35, 13);
            this.lblFechaVValue.TabIndex = 20;
            this.lblFechaVValue.Text = "label1";
            // 
            // lblTotalVValue
            // 
            this.lblTotalVValue.AutoSize = true;
            this.lblTotalVValue.Location = new System.Drawing.Point(66, 66);
            this.lblTotalVValue.Name = "lblTotalVValue";
            this.lblTotalVValue.Size = new System.Drawing.Size(35, 13);
            this.lblTotalVValue.TabIndex = 21;
            this.lblTotalVValue.Text = "label1";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(87)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(11, 324);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(149, 23);
            this.btnVolver.TabIndex = 22;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 450);
            this.Controls.Add(this.tabVentas);
            this.Controls.Add(this.panelProd);
            this.Name = "FormVentas";
            this.Text = "FormVentas";
            this.tabVentas.ResumeLayout(false);
            this.tabCatalogo.ResumeLayout(false);
            this.tabCatalogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.tabEditar.ResumeLayout(false);
            this.tabEditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductoVentas)).EndInit();
            this.panelProd.ResumeLayout(false);
            this.panelProd.PerformLayout();
            this.tabDetalle.ResumeLayout(false);
            this.tabDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductoVentasV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabVentas;
        private System.Windows.Forms.TabPage tabCatalogo;
        public System.Windows.Forms.Button btnBorrar;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TabPage tabEditar;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Panel panelProd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.ComboBox cbCliente;
        public System.Windows.Forms.Button btnBorrarProd;
        private System.Windows.Forms.DataGridView dgvProductoVentas;
        public System.Windows.Forms.Button btnAgregarProd;
        private System.Windows.Forms.Label lblStockNumber;
        private System.Windows.Forms.TabPage tabDetalle;
        private System.Windows.Forms.Label lblClienteV;
        private System.Windows.Forms.Label lblIdVenta;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTotalVValue;
        private System.Windows.Forms.Label lblFechaVValue;
        private System.Windows.Forms.Label lblClienteVValue;
        private System.Windows.Forms.Label lblIdVentaValue;
        private System.Windows.Forms.DataGridView dgvProductoVentasV;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnVolver;
    }
}