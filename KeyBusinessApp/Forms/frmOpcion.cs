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
    public partial class frmOpcion: Form
    {
        Opcion     opcion;
        DataTable datosOpcion;
        string    windowsMode;
        string       idOpcion;
        
        

        public frmOpcion(string modeWindows) 
        {
            InitializeComponent();
            opcion                 = new Opcion();
            windowsMode           = modeWindows;
            
            fillComboLists();
            cbEstado.SelectedItem = cbEstado.Items[0];
            stateLabel();
        }

        public frmOpcion(string idOpcion, string modeWindows)
        {
            InitializeComponent();

            //Verificamos si es en modo de edicion o insercion.
            windowsMode  = modeWindows;
            this.idOpcion = idOpcion;
            fillComboLists();
            stateLabel();
            if (windowsMode.Equals("Edit"))
            {
                //Procedemos a buscar los datos de la clase seleccionada
                opcion = new Opcion();
                datosOpcion = new DataTable();
                opcion.buscarDatosopcion("ID_OPCION", idOpcion);
                datosOpcion = opcion.obtenerDatosOpcion();
               // Procedemos a setear los datos en los campos del formulario.
                txtCodigoReferencia.Text = datosOpcion.Rows[0]["C_ID_OPCION"].ToString();
                     txtDescripcion.Text = datosOpcion.Rows[0]["C_DESCRIPCION"].ToString();
                txtNombreFormulario.Text = datosOpcion.Rows[0]["C_NOMBRE_FORMULARIO"].ToString();
                         txtUrlIcono.Text= datosOpcion.Rows[0]["C_URL_ICON"].ToString();
                if (datosOpcion.Rows[0]["C_ESTATUS"].Equals("AC"))
                {
                    cbEstado.SelectedItem = cbEstado.Items[0];
                }
                else
                {
                    cbEstado.SelectedItem = cbEstado.Items[1];
                }

                txtCodigoReferencia.Enabled = false;
            }
            else 
            {
                txtCodigoReferencia.Enabled = true;
            }
        }

        public void fillComboLists() 
        {
            //Setiamos los Item de las listas de combo.

            cbEstado.Items.Add(new ItemCombo("Activo", "AC"));
            cbEstado.Items.Add(new ItemCombo("Inactivo", "IN"));
        }

        public bool existeCodigoRef(string codRef) 
        {
            bool existe = false;

            opcion.buscarDatosopcion("ID_OPCION", txtCodigoReferencia.Text);
            if (opcion.obtenerDatosOpcion().Rows.Count > 0)
            {
                existe = true;
            }
            return existe;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string estado = ((ItemCombo)(cbEstado.SelectedItem)).Value;
            if (txtCodigoReferencia.Text.Length == 0 && (txtDescripcion.Text.Length > 0) || txtDescripcion.Text.Length == 0 && (txtCodigoReferencia.Text.Length > 0)) 
            {
                noticeRequeridFields();
            }
            if ((txtCodigoReferencia.Text.Length > 0) && (txtDescripcion.Text.Length > 0))
            {
                     
            //Los datos del  campo descripcion esta en mayuscula aunque el usuario digite los mismos en minuscula   
                    if (windowsMode.Equals("Edit"))
                    {
                        opcion.actualizarDatosOpcion(idOpcion, txtDescripcion.Text.ToUpper(), txtNombreFormulario.Text, txtUrlIcono.Text,estado);
                        this.Close();
                    }
                    else
                    {
                        if (!existeCodigoRef(txtCodigoReferencia.Text))
                        {
                            opcion.grabarDatosOpcion(txtCodigoReferencia.Text, txtDescripcion.Text, txtNombreFormulario.Text, txtUrlIcono.Text, estado);
                            this.Close();
                        }
                        else 
                        {
                            MessageBox.Show(this, "El código de referencia digitado, ya existe en la base de datos, favor digitar otro.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCodigoReferencia.Text = "";
                            txtCodigoReferencia.Focus();
                        }
                    }                
            }
            else 
            {
                noticeRequeridFields();
                if (txtCodigoReferencia.Text.Length == 0) 
                {
                    
                }
                MessageBox.Show(this, "Debe digitar el código de referencia y la descripción de la opcion.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);              
            }                                    
        }

        private void frmMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1_Click(new object(), new EventArgs());
        }

        private void frmOpcion_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void noticeRequeridFields() 
        {
            if (txtCodigoReferencia.Text.Length == 0 && ( txtDescripcion.Text.Length  > 0  ) ) 
            {
                txtCodigoRequerido.Visible = true;
                txtDescripcionRequerido.Visible = false;
                txtCodigoReferencia.Focus();
            }
            else if (txtDescripcion.Text.Length == 0 && (txtCodigoReferencia.Text.Length > 0))
            {
                txtDescripcionRequerido.Visible = true;
                txtCodigoRequerido.Visible = false;
                txtDescripcion.Focus();
            }
            else 
            {
                txtCodigoRequerido.Visible = true;
                txtDescripcionRequerido.Visible = true;
                txtCodigoReferencia.Focus();
            }
        }
        public void stateLabel() 
        {
            txtCodigoRequerido.Visible = false;
            txtDescripcionRequerido.Visible = false;
        }

        private void btnBuscarIma_Click(object sender, EventArgs e)
        {
            ofdImagen.ShowDialog();
            txtUrlIcono.Text = ofdImagen.FileName;
        } 
    }
}
