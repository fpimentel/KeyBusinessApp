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
    public partial class frmProductoLookUp : Form
    {
        Producto producto;
        string   searchingMode = "";

        public frmProductoLookUp()
        {
            InitializeComponent();
            producto = new Producto();
            fillComboLists();
        }

        public void fillComboLists()
        {
            //Setiamos los Item del comboBuscar.
            cbBuscarPor.Items.Add(new ItemCombo("ID Producto",          "ID Producto"));
           // cbBuscarPor.Items.Add(new ItemCombo("Descripción Producto", "Descripción Producto"));
            cbBuscarPor.Items.Add(new ItemCombo("Descripción Clase",    "Descripción Clase"));
            cbBuscarPor.Items.Add(new ItemCombo("Descripción Marca",    "Descripción Marca"));
            cbBuscarPor.Items.Add(new ItemCombo("Descripción Modelo",   "Descripción Modelo"));
            cbBuscarPor.Items.Add(new ItemCombo("Código referencia",    "Código referencia"));
            cbBuscarPor.Items.Add(new ItemCombo("Estado", "Estado"));
            cbBuscarPor.SelectedItem = cbBuscarPor.SelectedIndex = 1;
        }

        private void frmMarcaList_Load(object sender, EventArgs e)
        {
             try
             {
                 //Buscamos todas las marcas y la ponemos en el Grid.
                 producto.buscaDatosProducto("Estado","AC");
                 dgProducto.DataSource = producto.obtenerDatosProducto();               
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
                producto.buscaDatosProducto(null, null);
            }
            else 
            {
                producto.buscaDatosProducto("Estado", "AC");
            }

            dgProducto.DataSource = producto.obtenerDatosProducto();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            searchingMode = "btnBuscar";
            //Verificamos si se digito un valor a buscar.            
            if (txtBuscar.Text.Length > 0)
            {
                string valueItem = ((ItemCombo)(cbBuscarPor.SelectedItem)).Value;

                if (valueItem.Equals("ID Producto"))
                {
                    try
                    {
                        int.Parse(txtBuscar.Text);
                        producto.buscaDatosProducto("idProducto",txtBuscar.Text);
                    }
                    catch(FormatException ex)
                    {
                        MessageBox.Show("El ID del producto debe ser numérico.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBuscar.Text = "";
                        txtBuscar.Focus();
                        return;
                    }
                    
                }
                if (valueItem.Equals("Descripción Modelo"))
                {
                    producto.buscaDatosProducto("descModelo", txtBuscar.Text);                                                            
                }
                if (valueItem.Equals("Descripción Clase"))
                {
                    producto.buscaDatosProducto("descClase", txtBuscar.Text);
                }
                if (valueItem.Equals("Descripción Marca"))
                {
                    producto.buscaDatosProducto("descMarca", txtBuscar.Text);
                }
                if (valueItem.Equals("Código referencia"))
                {
                    producto.buscaDatosProducto("codRef", txtBuscar.Text);
                }
                if (valueItem.Equals("Descripción Producto"))
                {
                    producto.buscaDatosProducto("descProducto", txtBuscar.Text);
                }
                if (valueItem.Equals("Estado"))
                {
                    producto.buscaDatosProducto("Estado", txtBuscar.Text);
                }
                dgProducto.DataSource = producto.obtenerDatosProducto();      
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
                new frmProducto(dgProducto.Rows[e.RowIndex].Cells["cIdProducto"].Value.ToString(), "Edit").ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Resetemos las variables staticas del mantenimiento en general.
            frmProducto.idModelo = -1;
            frmProducto.idMarca = -1;
            frmProducto.idClase = -1;
            new frmProducto("New").ShowDialog();
        }

        private void frmClaseList_Activated(object sender, EventArgs e)
        {
            if (!searchingMode.Equals("btnBuscar")) 
            {
                if (chkActivosInactivos.Checked)
                {
                    producto.buscaDatosProducto(null, null);
                }
                else
                {
                    producto.buscaDatosProducto("Estado", "AC");
                }
                dgProducto.DataSource = producto.obtenerDatosProducto();
            }            
        }
    }
}
