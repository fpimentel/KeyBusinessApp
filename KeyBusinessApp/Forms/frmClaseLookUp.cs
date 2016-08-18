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
    public partial class frmClaseLookUp : Form
    {
        Clase clase;
 

        public frmClaseLookUp()
        {
            InitializeComponent();
            clase = new Clase();

            //Setiamos los Item del combo.
            cbBuscarPor.Items.Add(new ItemCombo("ID_Clase", "ID_Clase"));
            cbBuscarPor.Items.Add(new ItemCombo("Descripción", "Descripcion"));
            cbBuscarPor.Items.Add(new ItemCombo("Código Referencia", "Cod"));
            cbBuscarPor.Items.Add(new ItemCombo("Estado", "Estado"));
            cbBuscarPor.SelectedItem = cbBuscarPor.SelectedIndex = 1;
        }

        private void frmMarcaList_Load(object sender, EventArgs e)
        {
             try
             {
                 //Buscamos todas las marcas y la ponemos en el Grid.
                 clase.buscaDatosClase("Estado", "AC");
                 dgClases.DataSource = clase.obtenerDatosClase();               
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

       
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Verificamos si se digito un valor a buscar.            
            if (txtBuscar.Text.Length > 0)
            {
                string valueItem = ((ItemCombo)(cbBuscarPor.SelectedItem)).Value;
                
                if(valueItem.Equals("Descripcion"))
                {
                    clase.buscaDatosClase("Descripcion", txtBuscar.Text);
                }
                if (valueItem.Equals("Cod"))
                {
                    clase.buscaDatosClase("CodigoRef", txtBuscar.Text);
                }
                if (valueItem.Equals("Estado"))
                {
                    clase.buscaDatosClase("Estado", txtBuscar.Text);
                }

                if (valueItem.Equals("ID_Clase"))
                {
                    try 
                    {
                        int.Parse(txtBuscar.Text);
                        clase.buscaDatosClase("idClase", txtBuscar.Text);
                    }
                    catch(FormatException ex)
                    {
                        MessageBox.Show("El ID de la clase debe ser numérico.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                }                
            }
            else 
            {
                MessageBox.Show(this, "Debe digitar un valor a buscar a buscar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmClase("New").ShowDialog();
        }

        private void dgClases_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                frmProducto.idClase = int.Parse(dgClases.Rows[e.RowIndex].Cells["cIdClase"].Value.ToString());
                frmProducto.descClase = dgClases.Rows[e.RowIndex].Cells["cDescripcion"].Value.ToString();
                this.Close();
            }
        }
    }
}
