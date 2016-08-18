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
    public partial class frmTipoEmpresa : Form
    {
        TipoEmpresa                        tipoEmpresa;
        DataTable                          datosTipoEmpresa;
        string                             windowsMode;
        int                                idTipoEmpresa;

        public frmTipoEmpresa(string modeWindows) 
        {
            InitializeComponent();
            tipoEmpresa              = new TipoEmpresa();
            windowsMode              = modeWindows;
            
            fillComboLists();
            cbEstado.SelectedItem = cbEstado.Items[0];           
        }

        public frmTipoEmpresa(string idTipoEmpresa, string modeWindows)
        {
            InitializeComponent();

            //Verificamos si es en modo de edicion o insercion.
            windowsMode  = modeWindows;
            this.idTipoEmpresa = int.Parse(idTipoEmpresa);
            fillComboLists();

            if (modeWindows.Equals("Edit"))
            {
                //Procedemos a buscar los datos del producto seleccionada
                tipoEmpresa      = new TipoEmpresa();
                datosTipoEmpresa = new DataTable();
                tipoEmpresa.buscaDatosTipoEmpresa("idTipoEmpresa", idTipoEmpresa);
                datosTipoEmpresa = tipoEmpresa.obtenerDatosTipoEmpresa();
            
                //Procedemos a setear los datos en los campos del formulario.
                txtDescripcion.Text = datosTipoEmpresa.Rows[0]["C_DESCRIPCION"].ToString();
                if (datosTipoEmpresa.Rows[0]["C_ESTATUS"].Equals("AC"))
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validaCamposRequeridos() 
        {            
            if (txtDescripcion.Text.Length <= 0)
            {
                MessageBox.Show("Debe digitar la descripción de la empresa.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
                return;
            }
        }
        private void validarForm() 
        {
            validaCamposRequeridos();        
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
                       
            //validamos los campos.
            validarForm();

                string estado = ((ItemCombo)(cbEstado.SelectedItem)).Value;

                if (windowsMode.Equals("Edit"))
                {
                    tipoEmpresa.actualizarDatosTipoEmpresa(idTipoEmpresa, txtDescripcion.Text, estado);
                    this.Close();
                }
                else
                {
                        tipoEmpresa.grabarDatosTipoEmpresa(txtDescripcion.Text,estado);
                        this.Close();                 
                }                                                                                       
        }

        private void frmMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1_Click(new object(), new EventArgs());
        }

    }
}
