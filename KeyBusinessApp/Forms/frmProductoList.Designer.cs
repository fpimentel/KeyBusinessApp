namespace KeyBusinessApp.Forms
{
    partial class frmProductoList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductoList));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgProducto = new System.Windows.Forms.DataGridView();
            this.chkActivosInactivos = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbBuscarPor = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.cIdSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIdClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIdMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIdModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCodClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGanaMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGananMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantInventMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantInveMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(491, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catálogo de Productos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(361, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscar por:";
            // 
            // dgProducto
            // 
            this.dgProducto.AllowUserToAddRows = false;
            this.dgProducto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cEdit,
            this.cIdSucursal,
            this.cIdProducto,
            this.cDescProducto,
            this.cIdClase,
            this.cDescClase,
            this.cIdMarca,
            this.cDescMarca,
            this.cIdModelo,
            this.cDescModelo,
            this.cCodClase,
            this.cGanaMin,
            this.cGananMax,
            this.cCantInventMin,
            this.cCantInveMax,
            this.cEstado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProducto.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgProducto.EnableHeadersVisualStyles = false;
            this.dgProducto.Location = new System.Drawing.Point(12, 185);
            this.dgProducto.Name = "dgProducto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgProducto.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgProducto.Size = new System.Drawing.Size(1193, 395);
            this.dgProducto.TabIndex = 5;
            this.dgProducto.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgMarcas_CellMouseClick);
            // 
            // chkActivosInactivos
            // 
            this.chkActivosInactivos.AutoSize = true;
            this.chkActivosInactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivosInactivos.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkActivosInactivos.Location = new System.Drawing.Point(12, 162);
            this.chkActivosInactivos.Name = "chkActivosInactivos";
            this.chkActivosInactivos.Size = new System.Drawing.Size(121, 17);
            this.chkActivosInactivos.TabIndex = 6;
            this.chkActivosInactivos.Text = "Buscar Inactivos";
            this.chkActivosInactivos.UseVisualStyleBackColor = true;
            this.chkActivosInactivos.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "new.ico");
            this.imageList1.Images.SetKeyName(1, "Buscar.ico");
            this.imageList1.Images.SetKeyName(2, "New2.ico");
            this.imageList1.Images.SetKeyName(3, "Cancelar.ico");
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle6.NullValue")));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::KeyBusinessApp.Properties.Resources.Icon_193;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageIndex = 1;
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(796, 103);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 37);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.ImageIndex = 2;
            this.btnNuevo.ImageList = this.imageList1;
            this.btnNuevo.Location = new System.Drawing.Point(1079, 12);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(58, 40);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageIndex = 3;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(1136, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(59, 40);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbBuscarPor
            // 
            this.cbBuscarPor.FormattingEnabled = true;
            this.cbBuscarPor.Location = new System.Drawing.Point(439, 112);
            this.cbBuscarPor.Name = "cbBuscarPor";
            this.cbBuscarPor.Size = new System.Drawing.Size(151, 21);
            this.cbBuscarPor.TabIndex = 9;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(597, 112);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(193, 20);
            this.txtBuscar.TabIndex = 10;
            // 
            // cEdit
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.cEdit.DefaultCellStyle = dataGridViewCellStyle2;
            this.cEdit.HeaderText = "";
            this.cEdit.Image = global::KeyBusinessApp.Properties.Resources.Icon_193;
            this.cEdit.Name = "cEdit";
            this.cEdit.ReadOnly = true;
            this.cEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cEdit.Width = 60;
            // 
            // cIdSucursal
            // 
            this.cIdSucursal.DataPropertyName = "N_ID_SUCURSAL";
            this.cIdSucursal.HeaderText = "ID Sucursal";
            this.cIdSucursal.Name = "cIdSucursal";
            // 
            // cIdProducto
            // 
            this.cIdProducto.DataPropertyName = "N_ID_PRODUCTO";
            this.cIdProducto.HeaderText = "ID";
            this.cIdProducto.Name = "cIdProducto";
            this.cIdProducto.Width = 30;
            // 
            // cDescProducto
            // 
            this.cDescProducto.DataPropertyName = "descPro";
            this.cDescProducto.HeaderText = "Descripción Producto";
            this.cDescProducto.Name = "cDescProducto";
            this.cDescProducto.Visible = false;
            this.cDescProducto.Width = 170;
            // 
            // cIdClase
            // 
            this.cIdClase.DataPropertyName = "N_ID_CLASE";
            this.cIdClase.HeaderText = "ID Clase";
            this.cIdClase.Name = "cIdClase";
            this.cIdClase.Visible = false;
            // 
            // cDescClase
            // 
            this.cDescClase.DataPropertyName = "descClase";
            this.cDescClase.HeaderText = "Descripción Clase";
            this.cDescClase.Name = "cDescClase";
            this.cDescClase.Width = 150;
            // 
            // cIdMarca
            // 
            this.cIdMarca.DataPropertyName = "N_ID_MARCA";
            this.cIdMarca.HeaderText = "ID Marca";
            this.cIdMarca.Name = "cIdMarca";
            this.cIdMarca.Visible = false;
            // 
            // cDescMarca
            // 
            this.cDescMarca.DataPropertyName = "C_DESCRIPCION_MARCA";
            this.cDescMarca.HeaderText = "Descripción Marca";
            this.cDescMarca.Name = "cDescMarca";
            this.cDescMarca.Width = 150;
            // 
            // cIdModelo
            // 
            this.cIdModelo.DataPropertyName = "N_ID_MODELO";
            this.cIdModelo.HeaderText = "ID Modelo";
            this.cIdModelo.Name = "cIdModelo";
            this.cIdModelo.Visible = false;
            // 
            // cDescModelo
            // 
            this.cDescModelo.DataPropertyName = "descMod";
            this.cDescModelo.HeaderText = "Descripción Modelo";
            this.cDescModelo.Name = "cDescModelo";
            this.cDescModelo.Width = 150;
            // 
            // cCodClase
            // 
            this.cCodClase.DataPropertyName = "C_COD_REFERENCIA";
            this.cCodClase.HeaderText = "Código Referencia";
            this.cCodClase.Name = "cCodClase";
            this.cCodClase.Width = 150;
            // 
            // cGanaMin
            // 
            this.cGanaMin.DataPropertyName = "N_PORCENTAJE_MIN";
            this.cGanaMin.HeaderText = "Ganancia Min";
            this.cGanaMin.Name = "cGanaMin";
            this.cGanaMin.Width = 110;
            // 
            // cGananMax
            // 
            this.cGananMax.DataPropertyName = "N_PORCENTAJE_MAX";
            this.cGananMax.HeaderText = "Ganancia Max";
            this.cGananMax.Name = "cGananMax";
            this.cGananMax.Width = 115;
            // 
            // cCantInventMin
            // 
            this.cCantInventMin.DataPropertyName = "N_CANT_MIN_INVENT";
            this.cCantInventMin.HeaderText = "Min Invent";
            this.cCantInventMin.Name = "cCantInventMin";
            // 
            // cCantInveMax
            // 
            this.cCantInveMax.DataPropertyName = "N_CANT_MAX_INVENT";
            this.cCantInveMax.HeaderText = "Max Invent";
            this.cCantInveMax.Name = "cCantInveMax";
            // 
            // cEstado
            // 
            this.cEstado.DataPropertyName = "C_ESTADO";
            this.cEstado.HeaderText = "Estado";
            this.cEstado.Name = "cEstado";
            this.cEstado.ReadOnly = true;
            this.cEstado.Width = 50;
            // 
            // frmProductoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1217, 611);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.cbBuscarPor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.chkActivosInactivos);
            this.Controls.Add(this.dgProducto);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductoList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de Productos";
            this.Load += new System.EventHandler(this.frmMarcaList_Load);
            this.Activated += new System.EventHandler(this.frmClaseList_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgProducto;
        private System.Windows.Forms.CheckBox chkActivosInactivos;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbBuscarPor;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridViewImageColumn cEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIdSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIdClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIdMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIdModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGanaMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGananMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantInventMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantInveMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstado;
    }
}