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

namespace KeyBusinessApp.Forms
{
    public partial class frmInventarioEntrada : Form
    {



        public frmInventarioEntrada() 
        {
            InitializeComponent();
            
            fillComboLists();                 
        }

        public frmInventarioEntrada(string idClase, string modeWindows)
        {
            InitializeComponent();

            //Verificamos si es en modo de edicion o insercion.
            fillComboLists();

        }

        public void fillComboLists() 
        {
            //Setiamos los Item de las listas de combo.

        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                                              
        }

        private void frmMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1_Click(new object(), new EventArgs());
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0) 
            {
                new frmProductoList().ShowDialog();
            }
        }

        private void dgProducto_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }
    }
}
