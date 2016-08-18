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

namespace KeyBusinessApp.Forms
{
    public partial class frmMarcaList : Form
    {
        Marca marca;

        public frmMarcaList()
        {
            InitializeComponent();
            marca = new Marca();
        }

        private void frmMarcaList_Load(object sender, EventArgs e)
        {
             try
             {
                 //Buscamos todas las marcas y la ponemos en el Grid.
                 marca.buscaDatosMarcaActivas();
                 dgMarcas.DataSource     = marca.obtenerMarcasActivas();                 
             }
             catch (SqlException ex)
             {
                 MessageBox.Show(this, "Error tratando de buscar las marcas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 AppTools.guardaLogErrores(ex.Message);
             }
             catch (Exception ex) 
             {
                 MessageBox.Show(this, "Error tratando de buscar las marcas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 AppTools.guardaLogErrores(ex.Message);
             }            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivosInactivos.Checked)
            {
                marca.buscaDatosMarca(null,null);
            }
            else 
            {
                marca.buscaDatosMarca("estado", "AC");
            }
            
            dgMarcas.DataSource = marca.obtenerMarcas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                marca.buscaDatosMarca("Descripcion", txtBuscar.Text);
                dgMarcas.DataSource = marca.obtenerMarcas();
            }
            else 
            {
                MessageBox.Show(this, "Debe digitar una marca a buscar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgMarcas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0) 
            {
                new frmMarca(dgMarcas.Rows[e.RowIndex].Cells["cIdMarca"].Value.ToString(), "Edit").ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmMarca("New").ShowDialog();
        }

        private void frmMarcaList_Activated(object sender, EventArgs e)
        {
            if (chkActivosInactivos.Checked)
            {
                marca.buscaDatosMarca(null, null);
            }
            else
            {
                marca.buscaDatosMarca("estado", "AC");
            }

            dgMarcas.DataSource = marca.obtenerMarcas();
        }
    }
}
