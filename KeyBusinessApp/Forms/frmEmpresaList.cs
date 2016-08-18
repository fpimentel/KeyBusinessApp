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
using System.Data.SqlClient;
using KeyBusinessApp.Class;

namespace KeyBusinessApp.Forms
{
    public partial class frmEmpresaList : Form
    {
        Empresa     empresa;
        string      searchingMode = "";

        public frmEmpresaList()
        {
            InitializeComponent();
            empresa = new Empresa();
            fillComboLists();
        }

        public void fillComboLists()
        {
            //Setiamos los Item del comboBuscar.
            cbBuscarPor.Items.Add(new ItemCombo("ID Empresa",  "ID Empresa"));
            cbBuscarPor.Items.Add(new ItemCombo("Empresa", "Empresa"));
            cbBuscarPor.Items.Add(new ItemCombo("Rnc", "Rnc"));
            cbBuscarPor.Items.Add(new ItemCombo("Estado",      "Estado"));
            cbBuscarPor.SelectedItem            = cbBuscarPor.SelectedIndex = 1;
        }

        private void frmMarcaList_Load(object sender, EventArgs e)
        {
             try
             {
                 //Buscamos todas las marcas y la ponemos en el Grid.
                 empresa.buscaDatosEmpresa("estatus", "AC");
                 dgEmpresa.DataSource = empresa.obtenerDatosEmpresa();              
             }
             catch (SqlException ex)
             {
                 MessageBox.Show(this, "Error tratando de buscar los tipos de empresa, favor verificar el log", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 AppTools.guardaLogErrores(ex.Message);
             }
             catch (Exception ex) 
             {
                 MessageBox.Show(this, "Error tratando de buscar los tipos de empresa, favor verificar el log", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 AppTools.guardaLogErrores(ex.Message);
             }            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivosInactivos.Checked)
            {
                empresa.buscaDatosEmpresa(null, null);
            }
            else 
            {
                empresa.buscaDatosEmpresa("estatus", "AC");
            }

            dgEmpresa.DataSource = empresa.obtenerDatosEmpresa();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            searchingMode = "btnBuscar";
            //Verificamos si se digito un valor a buscar.            
            if (txtBuscar.Text.Length > 0)
            {
                string valueItem = ((ItemCombo)(cbBuscarPor.SelectedItem)).Value;

                if (valueItem.Equals("ID Empresa"))
                {
                    try
                    {
                        int.Parse(txtBuscar.Text);
                        empresa.buscaDatosEmpresa("idEmpresa", txtBuscar.Text);
                    }
                    catch(FormatException ex)
                    {
                        MessageBox.Show("El Id de la empresa debe ser numérico.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBuscar.Text = "";
                        txtBuscar.Focus();
                        return;
                    }                    
                }
                if (valueItem.Equals("Empresa"))
                {
                    empresa.buscaDatosEmpresa("empresa", txtBuscar.Text);                                                            
                }
                if (valueItem.Equals("Rnc"))
                {
                    empresa.buscaDatosEmpresa("RNC", txtBuscar.Text);
                }
                if (valueItem.Equals("Estado"))
                {
                    empresa.buscaDatosEmpresa("estatus", txtBuscar.Text);
                }
                dgEmpresa.DataSource = empresa.obtenerDatosEmpresa();      
            }
            else 
            {
                MessageBox.Show(this, "Debe digitar un valor a buscar a buscar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgMarcas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0) 
            {
                new frmEmpresa(dgEmpresa.Rows[e.RowIndex].Cells["cIdEmpresa"].Value.ToString(), "Edit").ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmEmpresa("New").ShowDialog();
        }

        private void frmClaseList_Activated(object sender, EventArgs e)
        {
            if (!searchingMode.Equals("btnBuscar")) 
            {
                if (chkActivosInactivos.Checked)
                {
                    empresa.buscaDatosEmpresa(null, null);
                }
                else
                {
                    empresa.buscaDatosEmpresa("estatus", "AC");
                }
                dgEmpresa.DataSource = empresa.obtenerDatosEmpresa();
            }            
        }
    }
}
