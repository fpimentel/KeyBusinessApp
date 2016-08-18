namespace KeyBusinessApp.Forms
{
    partial class frmProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducto));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtClase = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodRef = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGananciaMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGananciaMax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnModelo = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClase = new System.Windows.Forms.Button();
            this.txtInveMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInveMax = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbSucursal = new System.Windows.Forms.ComboBox();
            this.ckLote = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(293, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mantenimiento  Productos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(619, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado:";
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(677, 256);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(122, 21);
            this.cbEstado.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(385, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(488, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(675, 100);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(203, 20);
            this.txtDescripcion.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(591, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Descripción:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "LookUp.jpg");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(141, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Clase:";
            // 
            // txtClase
            // 
            this.txtClase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClase.Enabled = false;
            this.txtClase.Location = new System.Drawing.Point(197, 104);
            this.txtClase.Name = "txtClase";
            this.txtClase.Size = new System.Drawing.Size(203, 20);
            this.txtClase.TabIndex = 1;
            // 
            // txtMarca
            // 
            this.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMarca.Enabled = false;
            this.txtMarca.Location = new System.Drawing.Point(197, 148);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(203, 20);
            this.txtMarca.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(137, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Marca:";
            // 
            // txtModelo
            // 
            this.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelo.Enabled = false;
            this.txtModelo.Location = new System.Drawing.Point(197, 191);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(203, 20);
            this.txtModelo.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(131, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Modelo:";
            // 
            // txtCodRef
            // 
            this.txtCodRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodRef.Location = new System.Drawing.Point(675, 148);
            this.txtCodRef.Name = "txtCodRef";
            this.txtCodRef.Size = new System.Drawing.Size(203, 20);
            this.txtCodRef.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(553, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Código Referencia:";
            // 
            // txtGananciaMin
            // 
            this.txtGananciaMin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGananciaMin.Location = new System.Drawing.Point(675, 191);
            this.txtGananciaMin.Name = "txtGananciaMin";
            this.txtGananciaMin.Size = new System.Drawing.Size(55, 20);
            this.txtGananciaMin.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkGreen;
            this.label9.Location = new System.Drawing.Point(499, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Porcentaje ganancia detalle:";
            // 
            // txtGananciaMax
            // 
            this.txtGananciaMax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGananciaMax.Location = new System.Drawing.Point(677, 223);
            this.txtGananciaMax.Name = "txtGananciaMax";
            this.txtGananciaMax.Size = new System.Drawing.Size(55, 20);
            this.txtGananciaMax.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkGreen;
            this.label10.Location = new System.Drawing.Point(474, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Porcentaje ganancia al por mayor";
            // 
            // btnModelo
            // 
            this.btnModelo.ImageKey = "LookUp.jpg";
            this.btnModelo.ImageList = this.imageList1;
            this.btnModelo.Location = new System.Drawing.Point(415, 181);
            this.btnModelo.Name = "btnModelo";
            this.btnModelo.Size = new System.Drawing.Size(45, 39);
            this.btnModelo.TabIndex = 3;
            this.btnModelo.UseVisualStyleBackColor = true;
            this.btnModelo.Click += new System.EventHandler(this.btnModelo_Click);
            // 
            // button3
            // 
            this.button3.ImageKey = "LookUp.jpg";
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(415, 138);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 39);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btnClase
            // 
            this.btnClase.ImageKey = "LookUp.jpg";
            this.btnClase.ImageList = this.imageList1;
            this.btnClase.Location = new System.Drawing.Point(415, 94);
            this.btnClase.Name = "btnClase";
            this.btnClase.Size = new System.Drawing.Size(45, 39);
            this.btnClase.TabIndex = 1;
            this.btnClase.UseVisualStyleBackColor = true;
            this.btnClase.Click += new System.EventHandler(this.btnClase_Click);
            // 
            // txtInveMin
            // 
            this.txtInveMin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInveMin.Location = new System.Drawing.Point(196, 219);
            this.txtInveMin.Name = "txtInveMin";
            this.txtInveMin.Size = new System.Drawing.Size(43, 20);
            this.txtInveMin.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(7, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cantidad mínima en inventario:";
            // 
            // txtInveMax
            // 
            this.txtInveMax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInveMax.Location = new System.Drawing.Point(196, 256);
            this.txtInveMax.Name = "txtInveMax";
            this.txtInveMax.Size = new System.Drawing.Size(43, 20);
            this.txtInveMax.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkGreen;
            this.label11.Location = new System.Drawing.Point(6, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(184, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Cantidad máxima en inventario:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkGreen;
            this.label12.Location = new System.Drawing.Point(123, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Sucursal:";
            // 
            // cbSucursal
            // 
            this.cbSucursal.FormattingEnabled = true;
            this.cbSucursal.Location = new System.Drawing.Point(196, 72);
            this.cbSucursal.Name = "cbSucursal";
            this.cbSucursal.Size = new System.Drawing.Size(204, 21);
            this.cbSucursal.TabIndex = 28;
            // 
            // ckLote
            // 
            this.ckLote.AutoSize = true;
            this.ckLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckLote.ForeColor = System.Drawing.Color.DarkGreen;
            this.ckLote.Location = new System.Drawing.Point(104, 290);
            this.ckLote.Name = "ckLote";
            this.ckLote.Size = new System.Drawing.Size(86, 17);
            this.ckLote.TabIndex = 29;
            this.ckLote.Text = "Aplica lote";
            this.ckLote.UseVisualStyleBackColor = true;
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(913, 424);
            this.Controls.Add(this.ckLote);
            this.Controls.Add(this.cbSucursal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtInveMax);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtInveMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGananciaMax);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtGananciaMin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCodRef);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnModelo);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClase);
            this.Controls.Add(this.txtClase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Productos";
            this.Activated += new System.EventHandler(this.frmModelo_Activated_1);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMarca_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtClase;
        private System.Windows.Forms.Button btnClase;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodRef;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGananciaMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGananciaMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtInveMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInveMax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbSucursal;
        private System.Windows.Forms.CheckBox ckLote;
    }
}