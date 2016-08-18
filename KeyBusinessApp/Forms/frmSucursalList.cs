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
    public partial class frmSucursalList : Form
    {
        Sucursal     sucursal;
        string      searchingMode = "";

        public frmSucursalList()
        {
            InitializeComponent();
            sucursal = new Sucursal();
            fillComboLists();
        }

        public void fillComboLists()
        {
            //Setiamos los Item del comboBuscar.
            cbBuscarPor.Items.Add(new ItemCombo("ID",  "ID"));
            cbBuscarPor.Items.Add(new ItemCombo("Id Empresa", "Id Empresa"));
            cbBuscarPor.Items.Add(new ItemCombo("Rnc", "Rnc"));
            cbBuscarPor.Items.Add(new ItemCombo("Descripción", "Descripción"));
            cbBuscarPor.Items.Add(new ItemCombo("Dirección", "Dirección"));
            cbBuscarPor.Items.Add(new ItemCombo("Estado",      "Estado"));
            cbBuscarPor.SelectedItem            = cbBuscarPor.SelectedIndex = 3;
        }

        private void frmMarcaList_Load(object sender, EventArgs e)
        {
             try
             {
                 //Buscamos las sucursales activas.
                 sucursal.buscaDatosSucursal("estatus", "AC");
                 dgSucursal.DataSource = sucursal.obtenerDatosSucursal();              
             }
             catch (SqlException ex)
             {
                 MessageBox.Show(this, "Error tratando de buscar las sucursales, favor verificar el log", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 AppTools.guardaLogErrores(ex.Message);
             }
             catch (Exception ex) 
             {
                 MessageBox.Show(this, "Error tratando de buscar las sucursales, favor verificar el log", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 AppTools.guardaLogErrores(ex.Message);
             }            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivosInactivos.Checked)
            {
                sucursal.buscaDatosSucursal(null, null);
            }
            else 
            {
                sucursal.buscaDatosSucursal("estatus", "AC");
            }

            dgSucursal.DataSource = sucursal.obtenerDatosSucursal();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            searchingMode = "btnBuscar";
            //Verificamos si se digito un valor a buscar.            
            if (txtBuscar.Text.Length > 0)
            {
                string valueItem = ((ItemCombo)(cbBuscarPor.SelectedItem)).Value;

                if (valueItem.Equals("ID"))
                {
                    try
                    {
                        int.Parse(txtBuscar.Text);
                        sucursal.buscaDatosSucursal("idSucursal", txtBuscar.Text);
                    }
                    catch(FormatException ex)
                    {
                        MessageBox.Show("El Id de la sucursal debe ser numérico.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBuscar.Text = "";
                        txtBuscar.Focus();
                        return;
                    }                    
                }
                if (valueItem.Equals("Id Empresa"))
                {
                    sucursal.buscaDatosSucursal("idEmpresa", txtBuscar.Text);                                                            
                }
                if (valueItem.Equals("Rnc"))
                {
                    sucursal.buscaDatosSucursal("Rnc", txtBuscar.Text);
                }
                if (valueItem.Equals("Descripción"))
                {
                    sucursal.buscaDatosSucursal("descSucursal", txtBuscar.Text);
                }
                if (valueItem.Equals("Dirección"))
                {
                    sucursal.buscaDatosSucursal("direccion", txtBuscar.Text);
                }
                if (valueItem.Equals("Estado"))
                {
                    sucursal.buscaDatosSucursal("estatus", txtBuscar.Text);
                }
                dgSucursal.DataSource = sucursal.obtenerDatosSucursal();      
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
                new frmSucursal(dgSucursal.Rows[e.RowIndex].Cells["cIdSucursal"].Value.ToString(), "Edit").ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmSucursal("New").ShowDialog();
        }

        private void frmClaseList_Activated(object sender, EventArgs e)
        {
            if (!searchingMode.Equals("btnBuscar")) 
            {
                if (chkActivosInactivos.Checked)
                {
                    sucursal.buscaDatosSucursal(null, null);
                }
                else
                {
                    sucursal.buscaDatosSucursal("estatus", "AC");
                }
                dgSucursal.DataSource = sucursal.obtenerDatosSucursal();
            }            
        }
    }
}
