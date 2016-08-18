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
    public partial class frmSucursal : Form
    {
        Sucursal                           sucursal;
        DataTable                          datosSucursal;
        Empresa                            empresa;
        string                             windowsMode;
        int                                idSucursal;

        public frmSucursal(string modeWindows) 
        {
            InitializeComponent();            
            empresa                  = new Empresa();
            sucursal                 = new Sucursal();
            windowsMode              = modeWindows;

            fillComboLists();
            cbEstado.SelectedItem = cbEstado.Items[0];           
        }

        public frmSucursal(string idSucursal, string modeWindows)
        {
            empresa        = new Empresa();
            datosSucursal  = new DataTable();
            sucursal       = new Sucursal();
            InitializeComponent();

            //Verificamos si es en modo de edicion o insercion.
            windowsMode     = modeWindows;
            this.idSucursal = int.Parse(idSucursal);

            fillComboLists();

            if (modeWindows.Equals("Edit"))
            {
                //Procedemos a buscar los datos de la empresa  seleccionada
                sucursal.buscaDatosSucursal("idSucursal", idSucursal);
                datosSucursal           = sucursal.obtenerDatosSucursal();
            
                //Procedemos a setear los datos en los campos del formulario.
                cbEmpresa.SelectedValue = datosSucursal.Rows[0]["N_ID_EMPRESA"].ToString();
                txtDescSucursal.Text    = datosSucursal.Rows[0]["C_DESCRIPCION"].ToString();
                txtDireccion.Text       = datosSucursal.Rows[0]["C_DIRECCION"].ToString();
                txtRNC.Text             = datosSucursal.Rows[0]["C_RNC"].ToString();

                if (datosSucursal.Rows[0]["C_ESTATUS"].Equals("AC"))
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

            //Setiamos los valores del comboEmpresa.
            empresa.buscaDatosEmpresa("estatus", "AC");
            cbEmpresa.DataSource    = empresa.obtenerDatosEmpresa();
            cbEmpresa.DisplayMember = "C_NOMBRE_EMPRESA";
            cbEmpresa.ValueMember   = "N_ID_EMPRESA";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validarForm() 
        {
            if(txtDescSucursal.Text.Length <= 0)
            {
                MessageBox.Show(this, "Debe digitar el nombre de la empresa.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescSucursal.Focus();
                return false;
            }
            if (txtDireccion.Text.Length <= 0)
            {
                MessageBox.Show(this, "Debe digitar el RNC de la empresa.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDireccion.Focus();
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
                    sucursal.actualizarDatosSucursal(idSucursal,int.Parse(cbEmpresa.SelectedValue.ToString()),txtDescSucursal.Text,txtDireccion.Text,txtRNC.Text,estado);
                    this.Close();
                }
                else
                {
                    sucursal.grabarDatosSucursal(int.Parse(cbEmpresa.SelectedValue.ToString()),txtDescSucursal.Text,txtDireccion.Text,txtRNC.Text,estado);
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
