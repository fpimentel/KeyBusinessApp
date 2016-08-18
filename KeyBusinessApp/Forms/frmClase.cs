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
    public partial class frmClase : Form
    {
        Clase     clase;
        DataTable datosClase;
        string    windowsMode;
        int       idClase;

        

        public frmClase(string modeWindows) 
        {
            InitializeComponent();
            clase                 = new Clase();
            windowsMode           = modeWindows;
            
            fillComboLists();
            cbEstado.SelectedItem = cbEstado.Items[0];           
        }

        public frmClase(string idClase, string modeWindows)
        {
            InitializeComponent();

            //Verificamos si es en modo de edicion o insercion.
            windowsMode  = modeWindows;
            this.idClase = int.Parse(idClase);
            fillComboLists();

            if (modeWindows.Equals("Edit"))
            {
                //Procedemos a buscar los datos de la clase seleccionada
                clase = new Clase();
                datosClase = new DataTable();
                clase.buscaDatosClase("idClase", idClase);
                datosClase = clase.obtenerDatosClase();

                //Procedemos a setear los datos en los campos del formulario.
                txtCodigoReferencia.Text = datosClase.Rows[0]["C_COD_CLASE"].ToString();
                txtDescripcion.Text = datosClase.Rows[0]["C_DESCRIPCION"].ToString();

                if (datosClase.Rows[0]["C_ESTADO"].Equals("AC"))
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

            clase.buscaDatosClase("CodigoRef",txtCodigoReferencia.Text);
            if(clase.obtenerDatosClase().Rows.Count > 0)
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
                        clase.actualizarDatosClase(idClase, txtDescripcion.Text, estado);
                        this.Close();
                    }
                    else
                    {
                        if (!existeCodigoRef(txtCodigoReferencia.Text))
                        {
                            clase.grabarDatosClase(txtCodigoReferencia.Text, txtDescripcion.Text, estado);
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
    }
}
