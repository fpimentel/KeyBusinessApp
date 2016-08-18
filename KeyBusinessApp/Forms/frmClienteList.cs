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
    public partial class frmClienteList : Form
    {
        Cliente cliente;
        string   searchingMode = "";

        public frmClienteList()
        {
            InitializeComponent();
            cliente = new Cliente();
            fillComboLists();
        }

        public void fillComboLists()
        {
            //Setiamos los Item del comboBuscar.
            cbBuscarPor.Items.Add(new ItemCombo("ID Cliente",     "ID Cliente"));
            cbBuscarPor.Items.Add(new ItemCombo("Cedula cliente", "Cedula cliente"));
            cbBuscarPor.Items.Add(new ItemCombo("Nombre",         "Nombre"));
            cbBuscarPor.Items.Add(new ItemCombo("Apellido",       "Apellido"));
            cbBuscarPor.Items.Add(new ItemCombo("Telefono",       "Telefono"));
            cbBuscarPor.Items.Add(new ItemCombo("Sexo",           "Sexo"));
            cbBuscarPor.Items.Add(new ItemCombo("Direccion",      "Direccion"));
            cbBuscarPor.Items.Add(new ItemCombo("Estado",         "Estado"));
            cbBuscarPor.SelectedItem = cbBuscarPor.SelectedIndex = 2;
        }

        private void frmMarcaList_Load(object sender, EventArgs e)
        {
             try
             {
                 //Buscamos toddos los clientes activos y los ponemos en el grid.
                 cliente.buscaDatosCliente("estatus", "AC");
                 dgClientes.DataSource = cliente.obtenerDatosClientes();
                 txtBuscar.Focus();
             }
             catch (SqlException ex)
             {
                 MessageBox.Show(this, "Error tratando de buscar los clientes, favor verificar el log", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 AppTools.guardaLogErrores(ex.Message);
             }
             catch (Exception ex) 
             {
                 MessageBox.Show(this, "Error tratando de buscar los clientes, favor verificar el log", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 AppTools.guardaLogErrores(ex.Message);
             }            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivosInactivos.Checked)
            {
                cliente.buscaDatosCliente(null, null);
            }
            else 
            {
                cliente.buscaDatosCliente("estatus", "AC");
            }

            dgClientes.DataSource = cliente.obtenerDatosClientes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            searchingMode = "btnBuscar";
            //Verificamos si se digito un valor a buscar.            
            if (txtBuscar.Text.Length > 0)
            {
                string valueItem = ((ItemCombo)(cbBuscarPor.SelectedItem)).Value;

                if (valueItem.Equals("ID Cliente"))
                {
                    try
                    {
                        int.Parse(txtBuscar.Text);
                        cliente.buscaDatosCliente("idCliente", txtBuscar.Text);
                    }
                    catch(FormatException ex)
                    {
                        MessageBox.Show("El ID del cliente debe ser numérico.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBuscar.Text = "";
                        txtBuscar.Focus();
                        return;
                    }
                    
                }
                if (valueItem.Equals("Cedula cliente"))
                {
                    cliente.buscaDatosCliente("cedCliente", txtBuscar.Text);                                                            
                }
                if (valueItem.Equals("Nombre"))
                {
                   cliente.buscaDatosCliente("nombreClie", txtBuscar.Text);
                }
                if (valueItem.Equals("Apellido"))
                {
                    cliente.buscaDatosCliente("apeCliente", txtBuscar.Text);
                }
                if (valueItem.Equals("Telefono"))
                {
                    cliente.buscaDatosCliente("telCliente", txtBuscar.Text);
                }
                if (valueItem.Equals("Sexo"))
                {
                    cliente.buscaDatosCliente("sexo", txtBuscar.Text);
                }
                if (valueItem.Equals("Direccion"))
                {
                    cliente.buscaDatosCliente("direccion", txtBuscar.Text);
                }
                if (valueItem.Equals("Estado"))
                {
                    cliente.buscaDatosCliente("Estado", txtBuscar.Text);
                }
                dgClientes.DataSource = cliente.obtenerDatosClientes();      
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
                new frmCliente(int.Parse(dgClientes.Rows[e.RowIndex].Cells["cIdCliente"].Value.ToString()), "Edit").ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {            
            new frmCliente("New").ShowDialog();
        }

        private void frmClaseList_Activated(object sender, EventArgs e)
        {
            if (!searchingMode.Equals("btnBuscar")) 
            {
                if (chkActivosInactivos.Checked)
                {
                    cliente.buscaDatosCliente(null, null);
                }
                else
                {
                    cliente.buscaDatosCliente("estatus", "AC");
                }
                dgClientes.DataSource = cliente.obtenerDatosClientes();
            }            
        }
    }
}
