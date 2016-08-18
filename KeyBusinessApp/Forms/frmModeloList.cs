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
    public partial class frmModeloList : Form
    {
        Modelo modelo;
        string searchingMode = "";

        public frmModeloList()
        {
            InitializeComponent();
            modelo = new Modelo();
            fillComboLists();
        }

        public void fillComboLists()
        {
            //Setiamos los Item del comboBuscar.
            cbBuscarPor.Items.Add(new ItemCombo("ID Modelo", "ID Modelo"));
            cbBuscarPor.Items.Add(new ItemCombo("Descripción Modelo", "Descripción Modelo"));
            cbBuscarPor.Items.Add(new ItemCombo("Código Referencia", "Código Referencia"));
            cbBuscarPor.Items.Add(new ItemCombo("Estado", "Estado"));
            cbBuscarPor.SelectedItem = cbBuscarPor.SelectedIndex = 1;
        }

        private void frmMarcaList_Load(object sender, EventArgs e)
        {
             try
             {
                 //Buscamos todas las marcas y la ponemos en el Grid.
                 modelo.buscaDatosModelo("Estado","AC");
                 dgModelo.DataSource = modelo.obtenerDatosModelo();               
             }
             catch (SqlException ex)
             {
                 MessageBox.Show(this, "Error tratando de buscar las marcas, favor verificar el log", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 AppTools.guardaLogErrores(ex.Message);
             }
             catch (Exception ex) 
             {
                 MessageBox.Show(this, "Error tratando de buscar las marcas, favor verificar el log", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 AppTools.guardaLogErrores(ex.Message);
             }            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivosInactivos.Checked)
            {
                modelo.buscaDatosModelo(null, null);
            }
            else 
            {
                modelo.buscaDatosModelo("Estado", "AC");
            }

            dgModelo.DataSource = modelo.obtenerDatosModelo();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            searchingMode = "btnBuscar";
            //Verificamos si se digito un valor a buscar.            
            if (txtBuscar.Text.Length > 0)
            {
                string valueItem = ((ItemCombo)(cbBuscarPor.SelectedItem)).Value;
                
                if(valueItem.Equals("ID Modelo"))
                {
                    try
                    {
                        int.Parse(txtBuscar.Text);
                        modelo.buscaDatosModelo("idModelo",txtBuscar.Text);
                    }
                    catch(FormatException ex)
                    {
                        MessageBox.Show("El ID del modelo debe ser numérico.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBuscar.Text = "";
                        txtBuscar.Focus();
                        return;
                    }
                    
                }
                if (valueItem.Equals("Descripción Modelo"))
                {
                    modelo.buscaDatosModelo("Descripcion", txtBuscar.Text);                                                            
                }                              
                if(valueItem.Equals("Código Referencia"))
                {
                    modelo.buscaDatosModelo("codRef", txtBuscar.Text);
                }
                if(valueItem.Equals("Descripcion"))
                {
                    modelo.buscaDatosModelo("Descripcion", txtBuscar.Text);
                }
                if (valueItem.Equals("Estado"))
                {
                    modelo.buscaDatosModelo("Estado", txtBuscar.Text);
                }
                dgModelo.DataSource = modelo.obtenerDatosModelo();      
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
                new frmModelo(dgModelo.Rows[e.RowIndex].Cells["cIdModelo"].Value.ToString(), "Edit").ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmModelo("New").ShowDialog();
        }

        private void frmClaseList_Activated(object sender, EventArgs e)
        {
            if (!searchingMode.Equals("btnBuscar")) 
            {
                if (chkActivosInactivos.Checked)
                {
                    modelo.buscaDatosModelo(null, null);
                }
                else
                {
                    modelo.buscaDatosModelo("Estado", "AC");
                }
                dgModelo.DataSource = modelo.obtenerDatosModelo();
            }            
        }
    }
}
