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
    public partial class frmCliente : Form
    {
        Cliente cliente;
        Sucursal sucursal;
        DataTable datosClientes;
        string windowsMode;
        int idCliente;
       
        public frmCliente(string modeWindows)
        {
            InitializeComponent();
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            cliente = new Cliente();
            sucursal = new Sucursal();
            windowsMode = modeWindows;

            fillComboLists();
            cbEstado.SelectedItem = cbEstado.Items[0];
            cbSexo.SelectedItem = cbSexo.Items[0];
        }

        public frmCliente(int idCliente, string modeWindows)
        {            
            InitializeComponent();
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            sucursal = new Sucursal();
            //Verificamos si es en modo de edicion o insercion.
            windowsMode = modeWindows;
            this.idCliente = idCliente;
            fillComboLists();

            if (modeWindows.Equals("Edit"))
            {
                //Procedemos a buscar los datos del producto seleccionada
                cliente = new Cliente();
                datosClientes = new DataTable();
                cliente.buscaDatosCliente("idCliente", idCliente.ToString());
                datosClientes = cliente.obtenerDatosClientes();

                //Procedemos a setear los datos en los campos del formulario.
                cbSucursal.SelectedValue = datosClientes.Rows[0]["N_ID_SUCURSAL"].ToString();
                txtCed.Text              = datosClientes.Rows[0]["C_CEDULA_CLIENTE"].ToString();
                txtApellido.Text         = datosClientes.Rows[0]["C_APELLIDO_CLIENTE"].ToString();
                txtApellido.Text         = datosClientes.Rows[0]["C_APELLIDO_CLIENTE"].ToString();
                cbSexo.SelectedValue     = datosClientes.Rows[0]["C_SEXO_CLIENTE"].ToString();
                dtpFechaNac.Text         = datosClientes.Rows[0]["D_FECHA_NACIMIENTO"].ToString();
                txtNombre.Text           = datosClientes.Rows[0]["C_NOMBRE_CLIENTE"].ToString();
                txtTelefono.Text         = datosClientes.Rows[0]["C_TELEFONO_CLIENTE"].ToString();
                txtDireccion.Text        = datosClientes.Rows[0]["C_DIRECCION_CLIENTE"].ToString();

                if (datosClientes.Rows[0]["C_SEXO_CLIENTE"].Equals("M"))
                {
                    cbSexo.SelectedItem = cbSexo.Items[0];
                }
                else
                {
                    cbSexo.SelectedItem = cbSexo.Items[1];
                }

                if (datosClientes.Rows[0]["C_ESTATUS_CLIENTE"].Equals("AC"))
                {
                    cbEstado.SelectedItem = cbEstado.Items[0];
                }
                else
                {
                    cbEstado.SelectedItem = cbEstado.Items[1];
                }
               
            }
        }

        public void fillComboLists()
        {
            //Setiamos los Item de las listas de combo.

            cbEstado.Items.Add(new ItemCombo("Activo",   "AC"));
            cbEstado.Items.Add(new ItemCombo("Inactivo", "IN"));

            cbSexo.Items.Add(new ItemCombo("Masculino", "M"));
            cbSexo.Items.Add(new ItemCombo("Femenino",  "F"));

            // llenamos los valores del comboSucursal
            sucursal.buscaDatosSucursal("estado", "AC");
            cbSucursal.DataSource = sucursal.obtenerDatosSucursal();
            cbSucursal.DisplayMember = "C_DESCRIPCION";
            cbSucursal.ValueMember = "N_ID_SUCURSAL";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
              
        private void button1_Click(object sender, EventArgs e)
        {

            //validamos los campos.

            string estado = ((ItemCombo)(cbEstado.SelectedItem)).Value;

            if (windowsMode.Equals("Edit"))
            {
                cliente.actualizarDatosCliente(idCliente, int.Parse(cbSucursal.SelectedValue.ToString()), txtCed.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, ((ItemCombo)(cbSexo.SelectedItem)).Value, txtDireccion.Text, estado, dtpFechaNac.Text);
                this.Close();
            }
            else
            {
                cliente.grabarDatosCliente(int.Parse(cbSucursal.SelectedValue.ToString()), txtCed.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, ((ItemCombo)(cbSexo.SelectedItem)).Value, txtDireccion.Text, estado, dtpFechaNac.Text);
                this.Close();
            }
        }

        private void frmMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1_Click(new object(), new EventArgs());
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string estado = ((ItemCombo)(cbEstado.SelectedItem)).Value;

            if (windowsMode.Equals("Edit"))
            {
                cliente.actualizarDatosCliente(idCliente, int.Parse(cbSucursal.SelectedValue.ToString()), txtCed.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, ((ItemCombo)(cbSexo.SelectedItem)).Value, txtDireccion.Text, estado, dtpFechaNac.Text);
                this.Close();
            }
            else
            {
                cliente.grabarDatosCliente(int.Parse(cbSucursal.SelectedValue.ToString()), txtCed.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, ((ItemCombo)(cbSexo.SelectedItem)).Value, txtDireccion.Text, estado, dtpFechaNac.Text);
            }
            this.Close();
        }
    }
}
