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
using System.Text.RegularExpressions;

namespace KeyBusinessApp.Forms
{
    public partial class frmProducto : Form
    {
        Producto                           producto;
        DataTable                          datosProducto;
        Sucursal                           sucursal;
        string                             windowsMode;
        int                                idProducto;
        public static int                  idClase;
        public static string               descClase;
        public static int                  idMarca;
        public static string               desMarca;
        public static int                  idModelo;
        public static string               descModelo;
        bool isValid = true;
        public frmProducto(string modeWindows) 
        {
            InitializeComponent();
            producto                 = new Producto();
            sucursal                 = new Sucursal();
            windowsMode              = modeWindows;
            
            fillComboLists();
            cbEstado.SelectedItem = cbEstado.Items[0];           
        }

        public frmProducto(string idProducto, string modeWindows)
        {
            InitializeComponent();
            sucursal = new Sucursal();

            //Verificamos si es en modo de edicion o insercion.
            windowsMode  = modeWindows;
            this.idProducto = int.Parse(idProducto);
            fillComboLists();

            if (modeWindows.Equals("Edit"))
            {
                //Procedemos a buscar los datos del producto seleccionada
                producto      = new Producto();
                datosProducto = new DataTable();
                producto.buscaDatosProducto("idProducto", idProducto);
                datosProducto = producto.obtenerDatosProducto();

                //Procedemos a setear los datos en los campos del formulario.
                txtClase.Text            = datosProducto.Rows[0]["descClase"].ToString();
                txtMarca.Text            = datosProducto.Rows[0]["C_DESCRIPCION_MARCA"].ToString();
                txtCodRef.Text           = datosProducto.Rows[0]["C_COD_REFERENCIA"].ToString();
                txtDescripcion.Text      = datosProducto.Rows[0]["descPro"].ToString();
                txtModelo.Text           = datosProducto.Rows[0]["descMod"].ToString();
                txtGananciaMin.Text      = datosProducto.Rows[0]["N_PORCENTAJE_MIN"].ToString();
                txtGananciaMax.Text      = datosProducto.Rows[0]["N_PORCENTAJE_MAX"].ToString();
                txtInveMin.Text          = datosProducto.Rows[0]["N_CANT_MIN_INVENT"].ToString();
                txtInveMax.Text          = datosProducto.Rows[0]["N_CANT_MAX_INVENT"].ToString();
                idClase                  = int.Parse(datosProducto.Rows[0]["N_ID_CLASE"].ToString());
                idMarca                  = int.Parse(datosProducto.Rows[0]["N_ID_MARCA"].ToString());
                idModelo                 = int.Parse(datosProducto.Rows[0]["N_ID_MODELO"].ToString());
                cbSucursal.SelectedValue = datosProducto.Rows[0]["N_ID_SUCURSAL"].ToString();

                if (datosProducto.Rows[0]["C_ESTADO"].Equals("AC"))
                {
                    cbEstado.SelectedItem = cbEstado.Items[0];
                }
                else
                {
                    cbEstado.SelectedItem = cbEstado.Items[1];
                }

                txtCodRef.Enabled = false;
            }
            else 
            {
                txtCodRef.Enabled = true;
            }
        }

        public void fillComboLists() 
        {
            //Setiamos los Item de las listas de combo.

            cbEstado.Items.Add(new ItemCombo("Activo", "AC"));
            cbEstado.Items.Add(new ItemCombo("Inactivo", "IN"));

            // llenamos los valores del comboSucursal
            sucursal.buscaDatosSucursal("estado","AC");
            cbSucursal.DataSource = sucursal.obtenerDatosSucursal();
            cbSucursal.DisplayMember = "C_DESCRIPCION";
            cbSucursal.ValueMember   = "N_ID_SUCURSAL";
        }

        public bool existeCodigoRef(string codRef) 
        {
            bool existe = false;

            producto.buscaDatosProducto("codRef", txtCodRef.Text);
            if(producto.obtenerDatosProducto().Rows.Count > 0)
            {
                existe = true;
            }
            return existe;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool noExisteCodigoRef()
        {
            bool existe = true;

            producto.buscaDatosProducto("codRef",txtCodRef.Text);
            if (producto.obtenerDatosProducto().Rows.Count > 0)
            {
                existe = false;
            }
            return existe;
        }

        private void validaCamposRequeridos() 
        {
            if (txtCodRef.Text.Length <= 0)
            {
                MessageBox.Show("Debe digitar el codigo de referencia del producto.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodRef.Focus();
                isValid = false;
                return;
            }
            if (txtClase.Text.Length <= 0)
            {
                MessageBox.Show("Debe seleccionar una clase para el producto.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClase.Focus();
                isValid = false;
                return;
            }
            if (txtMarca.Text.Length <= 0)
            {
                MessageBox.Show("Debe seleccionar una marca para el producto.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3.Focus();
                isValid = false;
                return;
            }
            if (txtModelo.Text.Length <= 0)
            {
                MessageBox.Show("Debe seleccionar un modelo para el producto.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnModelo.Focus();
                isValid = false;
                return;
            }
            if (txtGananciaMin.Text.Length <= 0)
            {
                MessageBox.Show("Debe digitar la ganancia mínima del producto .", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGananciaMin.Focus();
                isValid = false;
                return;
            }
            if (txtGananciaMax.Text.Length <= 0)
            {
                MessageBox.Show("Debe digitar la ganancia máxima  del producto .", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGananciaMax.Focus();
                isValid = false;
                return;
            }
        }
        private void validarForm() 
        {
            isValid = true;
            isValid = noExisteCodigoRef();
            validaCamposRequeridos();
            validaFormatoCampos();           
        }
        public bool existProducto() 
        {
            bool exist = false;
            producto.buscarProducto(idClase,idMarca,idModelo);
            
            if(producto.obtenerDatosProducto().Rows.Count > 0)
            {
                exist = true;
            }
            return exist;
        }

        private void validaFormatoCampos() 
        {
            if(!AppTools.isNumeric(txtGananciaMin.Text))
            {
                MessageBox.Show("Valor ganancia minima invalido.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGananciaMin.Text = "";
                txtGananciaMin.Focus();
                return;
            }

            if (existProducto())
            {
                isValid = false;
                MessageBox.Show("Este producto ya existe en la base de datos.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }

            if (!AppTools.isNumeric(txtGananciaMax.Text))
            {
                isValid = false;
                MessageBox.Show("Valor ganancia maxima invalido.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGananciaMax.Text = "";
                txtGananciaMax.Focus();
                return;
            }

            if (!AppTools.isNumeric(txtInveMin.Text))
            {
                MessageBox.Show("La cantidad de inventario mínimo debe numerico.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInveMin.Text = "";
                txtInveMin.Focus();
                return;
            }

            if (!AppTools.isNumeric(txtInveMax.Text))
            {
                MessageBox.Show("La cantidad de inventario máximo invalido.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInveMax.Text = "";
                txtInveMax.Focus();
                return;
            }

            try
            {
                float.Parse(txtGananciaMin.Text);
                float.Parse(txtGananciaMax.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Verifique el formato de la ganacia minima y maxima del producto", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGananciaMin.Focus();
                isValid = false;
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
                       
            //validamos los campos.
            validarForm();
            if (isValid)
            {
                string estado = ((ItemCombo)(cbEstado.SelectedItem)).Value;

                if (windowsMode.Equals("Edit"))
                {
                    producto.actualizarDatosProducto(int.Parse(cbSucursal.SelectedValue.ToString()), idProducto, idClase, idMarca, idModelo, txtCodRef.Text, txtDescripcion.Text, int.Parse(txtGananciaMin.Text), int.Parse(txtGananciaMax.Text),int.Parse(txtInveMin.Text),int.Parse(txtInveMax.Text),ckLote.Checked, estado);
                    this.Close();
                }
                else
                {
                    if (!existeCodigoRef(txtCodRef.Text))
                    {
                        producto.grabarDatosProducto(int.Parse(cbSucursal.SelectedValue.ToString()),idClase, idMarca, idModelo, txtCodRef.Text, txtDescripcion.Text, int.Parse(txtGananciaMin.Text), int.Parse(txtGananciaMax.Text),int.Parse(txtInveMin.Text),int.Parse(txtInveMax.Text),ckLote.Checked, estado);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "El código de referencia digitado, ya existe en la base de datos, favor digitar otro.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCodRef.Text = "";
                        txtCodRef.Focus();
                    }
                }                
            
                                   
            }            
        }

        private void frmMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                button1_Click(new object(), new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            idMarca  = -1;
            desMarca = "";
            new frmMarcaLookUp().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            idClase   = -1;
            descClase = "";
            new frmClaseLookUp().ShowDialog();
        }

        private void frmModelo_Activated_1(object sender, EventArgs e)
        {
            if (((desMarca != null) && (idMarca > 0) ))
            {
                txtMarca.Text = desMarca;                
            }
            if ((idClase > 0) && (descClase.Length > 0))
            {
                txtClase.Text = descClase;
            }
            if ((descModelo != null) && (idModelo > 0))
            {
                txtModelo.Text = descModelo;
            }
        }


        private void btnClase_Click(object sender, EventArgs e)
        {
            new frmClaseLookUp().ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new frmMarcaLookUp().ShowDialog();
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            new frmModeloLookUp().ShowDialog();
        }
    }
}
