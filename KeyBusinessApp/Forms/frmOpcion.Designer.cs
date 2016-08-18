namespace KeyBusinessApp.Forms
{
    partial class frmOpcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcion));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoReferencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreFormulario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUrlIcono = new System.Windows.Forms.TextBox();
            this.txtCodigoRequerido = new System.Windows.Forms.Label();
            this.txtDescripcionRequerido = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscarIma = new System.Windows.Forms.Button();
            this.ofdImagen = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(102, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mantenimiento de Opciones.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(57, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Código referencia:";
            // 
            // txtCodigoReferencia
            // 
            this.txtCodigoReferencia.Location = new System.Drawing.Point(174, 84);
            this.txtCodigoReferencia.Name = "txtCodigoReferencia";
            this.txtCodigoReferencia.Size = new System.Drawing.Size(277, 20);
            this.txtCodigoReferencia.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(118, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(174, 180);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(122, 21);
            this.cbEstado.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(197, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(289, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(174, 107);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(277, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(13, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Descripción de la Opcion: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(31, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre del Formulario:";
            // 
            // txtNombreFormulario
            // 
            this.txtNombreFormulario.Location = new System.Drawing.Point(174, 129);
            this.txtNombreFormulario.Name = "txtNombreFormulario";
            this.txtNombreFormulario.Size = new System.Drawing.Size(277, 20);
            this.txtNombreFormulario.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(84, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Url del Icono:";
            // 
            // txtUrlIcono
            // 
            this.txtUrlIcono.Location = new System.Drawing.Point(174, 153);
            this.txtUrlIcono.Name = "txtUrlIcono";
            this.txtUrlIcono.Size = new System.Drawing.Size(232, 20);
            this.txtUrlIcono.TabIndex = 4;
            // 
            // txtCodigoRequerido
            // 
            this.txtCodigoRequerido.AutoSize = true;
            this.txtCodigoRequerido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoRequerido.ForeColor = System.Drawing.Color.Red;
            this.txtCodigoRequerido.Location = new System.Drawing.Point(457, 91);
            this.txtCodigoRequerido.Name = "txtCodigoRequerido";
            this.txtCodigoRequerido.Size = new System.Drawing.Size(12, 13);
            this.txtCodigoRequerido.TabIndex = 13;
            this.txtCodigoRequerido.Text = "*";
            // 
            // txtDescripcionRequerido
            // 
            this.txtDescripcionRequerido.AutoSize = true;
            this.txtDescripcionRequerido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionRequerido.ForeColor = System.Drawing.Color.Red;
            this.txtDescripcionRequerido.Location = new System.Drawing.Point(457, 114);
            this.txtDescripcionRequerido.Name = "txtDescripcionRequerido";
            this.txtDescripcionRequerido.Size = new System.Drawing.Size(12, 13);
            this.txtDescripcionRequerido.TabIndex = 14;
            this.txtDescripcionRequerido.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(51, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 15;
            // 
            // btnBuscarIma
            // 
            this.btnBuscarIma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarIma.Location = new System.Drawing.Point(412, 151);
            this.btnBuscarIma.Name = "btnBuscarIma";
            this.btnBuscarIma.Size = new System.Drawing.Size(39, 23);
            this.btnBuscarIma.TabIndex = 16;
            this.btnBuscarIma.Text = "...";
            this.btnBuscarIma.UseVisualStyleBackColor = true;
            this.btnBuscarIma.Click += new System.EventHandler(this.btnBuscarIma_Click);
            // 
            // ofdImagen
            // 
            this.ofdImagen.FileName = "openFileDialog1";
            // 
            // frmOpcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(518, 258);
            this.Controls.Add(this.btnBuscarIma);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDescripcionRequerido);
            this.Controls.Add(this.txtCodigoRequerido);
            this.Controls.Add(this.txtUrlIcono);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNombreFormulario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoReferencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOpcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Opciones";
            this.Load += new System.EventHandler(this.frmOpcion_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMarca_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoReferencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreFormulario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUrlIcono;
        private System.Windows.Forms.Label txtCodigoRequerido;
        private System.Windows.Forms.Label txtDescripcionRequerido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscarIma;
        private System.Windows.Forms.OpenFileDialog ofdImagen;
    }
}