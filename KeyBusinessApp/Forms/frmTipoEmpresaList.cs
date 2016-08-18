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
    public partial class frmTipoEmpresaList : Form
    {
        TipoEmpresa tipoEmpresa;
        string      searchingMode = "";

        public frmTipoEmpresaList()
        {
            InitializeComponent();
            tipoEmpresa = new TipoEmpresa();
            fillComboLists();
        }

        public void fillComboLists()
        {
            //Setiamos los Item del comboBuscar.
            cbBuscarPor.Items.Add(new ItemCombo("ID Empresa",  "ID Empresa"));
            cbBuscarPor.Items.Add(new ItemCombo("Descripción", "Descripción"));
            cbBuscarPor.Items.Add(new ItemCombo("Estado",      "Estado"));
            cbBuscarPor.SelectedItem            = cbBuscarPor.SelectedIndex = 1;
        }

        private void frmMarcaList_Load(object sender, EventArgs e)
        {
             try
             {
                 //Buscamos todas las marcas y la ponemos en el Grid.
                 tipoEmpresa.buscaDatosTipoEmpresa("estatus","AC");
                 dgTipoEmpresa.DataSource = tipoEmpresa.obtenerDatosTipoEmpresa();              
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
                tipoEmpresa.buscaDatosTipoEmpresa(null, null);
            }
            else 
            {
                tipoEmpresa.buscaDatosTipoEmpresa("estatus", "AC");
            }

            dgTipoEmpresa.DataSource = tipoEmpresa.obtenerDatosTipoEmpresa();
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
                        tipoEmpresa.buscaDatosTipoEmpresa("idTipoEmpresa", txtBuscar.Text);
                    }
                    catch(FormatException ex)
                    {
                        MessageBox.Show("El Id del tipo empresa debe ser numerico.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBuscar.Text = "";
                        txtBuscar.Focus();
                        return;
                    }                    
                }
                if (valueItem.Equals("Descripción"))
                {
                    tipoEmpresa.buscaDatosTipoEmpresa("descripcion", txtBuscar.Text);                                                            
                }
                if (valueItem.Equals("Estado"))
                {
                    tipoEmpresa.buscaDatosTipoEmpresa("estatus", txtBuscar.Text);
                }
                dgTipoEmpresa.DataSource = tipoEmpresa.obtenerDatosTipoEmpresa();      
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
                new frmTipoEmpresa(dgTipoEmpresa.Rows[e.RowIndex].Cells["cIdTipoEmpresa"].Value.ToString(), "Edit").ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmTipoEmpresa("New").ShowDialog();
        }

        private void frmClaseList_Activated(object sender, EventArgs e)
        {
            if (!searchingMode.Equals("btnBuscar")) 
            {
                if (chkActivosInactivos.Checked)
                {
                    tipoEmpresa.buscaDatosTipoEmpresa(null, null);
                }
                else
                {
                    tipoEmpresa.buscaDatosTipoEmpresa("estatus", "AC");
                }
                dgTipoEmpresa.DataSource = tipoEmpresa.obtenerDatosTipoEmpresa();
            }            
        }
    }
}
