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
    public partial class frmOpcionList : Form
    {
        Opcion opcion;

        public frmOpcionList()
        {
            InitializeComponent();
            opcion = new Opcion();

            //Setiamos los Item del combo.
            cbBuscarPor.Items.Add(new ItemCombo("ID_OPCION", "ID_OPCION"));
            cbBuscarPor.Items.Add(new ItemCombo("Descripción", "Descripcion"));
            cbBuscarPor.Items.Add(new ItemCombo("Estado", "Estado"));
            cbBuscarPor.SelectedItem = cbBuscarPor.SelectedIndex = 1;
        }

        private void frmMarcaList_Load(object sender, EventArgs e)
        {
            try
             {
                 //Buscamos todas las opciones y la ponemos en el Grid.
                 opcion.buscarDatosopcion("Estado", "AC");
                 dgOpcion.DataSource = opcion.obtenerDatosOpcion();               
             }
             catch (SqlException ex)
             {
                  MessageBox.Show(this, "Error tratando de buscar las opciones, favor verificar el log", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //Seteamos el grid con las opciones inactiva o activas dependiendo si seleccionan o no el chekbox.
            if (chkActivosInactivos.Checked)
            {
                opcion.buscarDatosopcion(null , null);
            }
            else 
            {
                opcion.buscarDatosopcion("Estado","AC");
            }

            dgOpcion.DataSource = opcion.obtenerDatosOpcion();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Verificamos si se digito un valor a buscar.    
            
            if (txtBuscar.Text.Length > 0)
            {
                string valueItem = ((ItemCombo)(cbBuscarPor.SelectedItem)).Value;

                if (valueItem.Equals("ID_OPCION"))
                {

                    opcion.buscarDatosopcion("ID_OPCION", txtBuscar.Text.ToUpper());
                }
                if (valueItem.Equals("Descripcion"))
                {
                    opcion.buscarDatosopcion("Descripcion", txtBuscar.Text.ToUpper());
                }
                if (valueItem.Equals("Estado"))
                {
                    opcion.buscarDatosopcion("Estado", txtBuscar.Text.ToUpper());
                }

                                
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
                new frmOpcion(dgOpcion.Rows[e.RowIndex].Cells["cIdOpcion"].Value.ToString(), "Edit").ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmOpcion("New").ShowDialog();
        }

        private void frmOpcion_Activated(object sender, EventArgs e)
        {
            if (chkActivosInactivos.Checked)
            {
                opcion.buscarDatosopcion(null, null);
            }
            else
            {
                opcion.buscarDatosopcion("Estado", "AC");
            }
            dgOpcion.DataSource = opcion.obtenerDatosOpcion();

        }

        private void dgClases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
