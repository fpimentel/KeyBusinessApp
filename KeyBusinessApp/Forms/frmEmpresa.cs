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
using System.Text.RegularExpressions;

namespace KeyBusinessApp.Forms
{
    public partial class frmEmpresa : Form
    {
        TipoEmpresa                        tipoEmpresa;
        DataTable                          datosEmpresa;
        Empresa                            empresa;
        string                             windowsMode;
        int                                idEmpresa;

        public frmEmpresa(string modeWindows) 
        {
            InitializeComponent();
            tipoEmpresa              = new TipoEmpresa();
            empresa                  = new Empresa();
            windowsMode              = modeWindows;
            fillComboLists();
            cbEstado.SelectedItem = cbEstado.Items[0];           
        }

        public frmEmpresa(string idEmpresa, string modeWindows)
        {
            tipoEmpresa = new TipoEmpresa();
            InitializeComponent();

            //Verificamos si es en modo de edicion o insercion.
            windowsMode    = modeWindows;
            this.idEmpresa = int.Parse(idEmpresa);
            fillComboLists();

            if (modeWindows.Equals("Edit"))
            {
                //Procedemos a buscar los datos de la empresa  seleccionada
                datosEmpresa = new DataTable();
                empresa = new Empresa();
                empresa.buscaDatosEmpresa("idEmpresa", idEmpresa);
                datosEmpresa = empresa.obtenerDatosEmpresa();
            
                //Procedemos a setear los datos en los campos del formulario.
                cbTipoEmpresa.SelectedValue = datosEmpresa.Rows[0]["N_ID_TIPO_EMPRESA"].ToString();
                txtNombreEmpresa.Text = datosEmpresa.Rows[0]["C_NOMBRE_EMPRESA"].ToString();
                txtRNC.Text = datosEmpresa.Rows[0]["C_RNC"].ToString();

                if (datosEmpresa.Rows[0]["C_ESTATUS"].Equals("AC"))
                {
                    cbEstado.SelectedItem = cbEstado.Items[0];
                }
                else
                {
                    cbEstado.SelectedItem = cbEstado.Items[1];
                }

            }
        }

        public void fillComboLists() 
        {
            //Setiamos los Item de las listas de combo.
            cbEstado.Items.Add(new ItemCombo("Activo", "AC"));
            cbEstado.Items.Add(new ItemCombo("Inactivo", "IN"));

            //Setiamos los valores del comboTipoEmpresa.
            tipoEmpresa.buscaDatosTipoEmpresa("estatus", "AC");
            cbTipoEmpresa.DataSource    = tipoEmpresa.obtenerDatosTipoEmpresa();
            cbTipoEmpresa.DisplayMember = "C_DESCRIPCION";
            cbTipoEmpresa.ValueMember   = "N_ID_TIPO_EMPRESA";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validarForm() 
        {
            if(txtNombreEmpresa.Text.Length <= 0)
            {
                MessageBox.Show(this, "Debe digitar el nombre de la empresa.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreEmpresa.Focus();
                return false;
            }
            if (txtRNC.Text.Length <= 0)
            {
                MessageBox.Show(this, "Debe digitar el RNC de la empresa.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRNC.Focus();
                return false;
            }

            return true;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

            if (validarForm())
            {
                string estado = ((ItemCombo)(cbEstado.SelectedItem)).Value;

                if (windowsMode.Equals("Edit"))
                {
                    empresa.actualizarDatosEmpresa(idEmpresa,int.Parse(cbTipoEmpresa.SelectedValue.ToString()),txtNombreEmpresa.Text,txtRNC.Text,estado);
                    this.Close();
                }
                else
                {
                    empresa.grabarDatosEmpresa(int.Parse(cbTipoEmpresa.SelectedValue.ToString()),txtNombreEmpresa.Text,txtRNC.Text,estado);
                    this.Close();
                }
            }                                                                      
        }

        private void frmMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1_Click(new object(), new EventArgs());
        }

        private void frmEmpresa_Load(object sender, EventArgs e)
        {

        }

    }
}
