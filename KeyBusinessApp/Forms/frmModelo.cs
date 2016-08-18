using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeyBusinessApp.Class.Entities;
using KeyBusinessApp.Class.Tools;

namespace KeyBusinessApp.Forms
{
    public partial class frmModelo : Form
    {
        Modelo               modelo;
        DataTable            datosModelo;
        string               windowsMode;
        int                  idModelo;       

        public frmModelo(string modeWindows) 
        {
            InitializeComponent();
            modelo                 = new Modelo();
            windowsMode           = modeWindows;
            
            fillComboLists();
            cbEstado.SelectedItem = cbEstado.Items[0];           
        }

        public frmModelo(string idModelo, string modeWindows)
        {
            InitializeComponent();

            //Verificamos si es en modo de edicion o insercion.
            windowsMode  = modeWindows;
            this.idModelo = int.Parse(idModelo);
            fillComboLists();

            if (modeWindows.Equals("Edit"))
            {
                //Procedemos a buscar los datos de la clase seleccionada
                modelo = new Modelo();
                datosModelo = new DataTable();
                modelo.buscaDatosModelo("idModelo", idModelo);
                datosModelo = modelo.obtenerDatosModelo();

                //Procedemos a setear los datos en los campos del formulario.
                txtCodigoReferencia.Text = datosModelo.Rows[0]["C_COD_REFERENCIA"].ToString();
                txtDescripcion.Text = datosModelo.Rows[0]["C_DESCRIPCION"].ToString();

                if (datosModelo.Rows[0]["C_ESTADO"].Equals("AC"))
                {
                    cbEstado.SelectedItem = cbEstado.Items[0];
                }
                else
                {
                    cbEstado.SelectedItem = cbEstado.Items[1];
                }

                txtCodigoReferencia.Enabled = false;
            }
            else 
            {
                txtCodigoReferencia.Enabled = true;
            }
        }

        public void fillComboLists() 
        {
            //Setiamos los Item de las listas de combo.

            cbEstado.Items.Add(new ItemCombo("Activo", "AC"));
            cbEstado.Items.Add(new ItemCombo("Inactivo", "IN"));
        }

        public bool existeCodigoRef(string codRef) 
        {
            bool existe = false;

            modelo.buscaDatosModelo("codRef", txtCodigoReferencia.Text);
            if(modelo.obtenerDatosModelo().Rows.Count > 0)
            {
                existe = true;
            }
            return existe;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string estado = ((ItemCombo)(cbEstado.SelectedItem)).Value;

            if ((txtCodigoReferencia.Text.Length > 0) && (txtDescripcion.Text.Length > 0))
            {
                
                    if (windowsMode.Equals("Edit"))
                    {
                        modelo.actualizarDatosModelo(idModelo, txtCodigoReferencia.Text, txtDescripcion.Text, estado);
                        
                        this.Close();
                    }
                    else
                    {
                        if (!existeCodigoRef(txtCodigoReferencia.Text))
                        {
                            modelo.grabarDatosModelo(txtCodigoReferencia.Text, txtDescripcion.Text, estado);
                            this.Close();
                        }
                        else 
                        {
                            MessageBox.Show(this, "El código de referencia digitado, ya existe en la base de datos, favor digitar otro.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCodigoReferencia.Text = "";
                            txtCodigoReferencia.Focus();
                        }
                    }                
            }
            else 
            {
                MessageBox.Show(this, "Debe digitar el código de referencia y la descripción de la clase.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);              
            }                                    
        }

        private void frmMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1_Click(new object(), new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmClaseLookUp().ShowDialog();
        }

        private void frmModelo_Activated_1(object sender, EventArgs e)
        {      
        }
    }
}
