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
    public partial class frmMarcaLookUp : Form
    {
        Marca marca;


        public frmMarcaLookUp()
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                marca.buscaDatosMarca(null, null);
                dgMarcas.DataSource = marca.obtenerMarcas();
            }
            else 
            {
                marca.buscaDatosMarca("Descripcion", txtBuscar.Text);
                dgMarcas.DataSource = marca.obtenerMarcas();
            }
        }

        private void dgMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgMarcas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0) 
            {
                frmProducto.idMarca              = int.Parse(dgMarcas.Rows[e.RowIndex].Cells["cIdMarca"].Value.ToString());
                frmProducto.desMarca             = dgMarcas.Rows[e.RowIndex].Cells["cDescripcion"].Value.ToString();
                this.Close();
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

        private void frmMarcaLookUp_Activated(object sender, EventArgs e)
        {

        }
    }
}
