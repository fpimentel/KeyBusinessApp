using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeyBusinessApp.Class.Entities;

namespace KeyBusinessApp.Forms
{
    public partial class frmMarca : Form
    {
        Marca     marca;
        DataTable datosMarca;
        string    windowsMode;
        int       idMarca;

        public frmMarca(string modeWindows) 
        {
            InitializeComponent();
            marca        = new Marca();
            windowsMode  = modeWindows;
            cbEstado.SelectedItem = cbEstado.Items[0];
        }

        public frmMarca(string idMarca, string modeWindows)
        {
            InitializeComponent();

            //Verificamos si es en modo de edicion o insercion.
            windowsMode  = modeWindows;
            this.idMarca = int.Parse(idMarca);
            if(modeWindows.Equals("Edit"))
            {
                //Procedemos a buscar los datos de la marca seleccionada
                marca      = new Marca();
                datosMarca = new DataTable();
                marca.buscaDatosMarca("idMarca", idMarca);
                datosMarca = marca.obtenerMarcas();
                txtMarca.Text = datosMarca.Rows[0]["C_DESCRIPCION_MARCA"].ToString();
               
                if(datosMarca.Rows[0]["ESTADO"].Equals("AC"))
                {
                    cbEstado.SelectedItem = cbEstado.Items[0];
                }
                else
                {
                    cbEstado.SelectedItem = cbEstado.Items[1];
                }
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string estado;
            if (txtMarca.Text.Length > 0)
            {
                if (cbEstado.SelectedItem.ToString().Equals("Activo"))
                {
                    estado = "AC";
                }
                else
                {
                    estado = "IN";
                }
                if (windowsMode.Equals("Edit"))
                {
                    marca.actualizarDatosMarca(idMarca, txtMarca.Text, estado);
                    this.Close();
                }
                else
                {
                    marca.grabarDatosMarca(txtMarca.Text, estado);
                    this.Close();
                }
            }
            else 
            {
                MessageBox.Show(this, "Debe digitar la marca.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);              
            }                                    
        }

        private void frmMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1_Click(new object(), new EventArgs());
        }
    }
}
