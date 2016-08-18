using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using KeyBusinessApp.Class.Entities;
using KeyBusinessApp.Class.Tools;

namespace KeyBusinessApp
{
    public partial class Login : Form
    {

        private  Configuration                  config;
        public  static ConnectionStringsSection connSec;
        private ConnectionStringSettings        connStrSet;
        private StartUpApp                      starApp;
        private Usuario                         usuario;

        public Login()
        {
            InitializeComponent();
            config  = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            connSec = config.ConnectionStrings;
            usuario = new Usuario();
        }

        private void Login_Load(object sender, EventArgs e)
        {           
            if(connSec.ConnectionStrings["DataBaseConnectionString"] == null)
            {
                starApp = new StartUpApp();
                starApp.ShowDialog();
            }
            txtUserId.Text = "FPIMENTEL";
            txtContrasena.Text = "logicsoft";
       }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario.IdUsuario  = txtUserId.Text;
            usuario.Contrasena = AppTools.encriptarMD5(txtContrasena.Text);

            //Validamos el usuario.
            if (usuario.buscaUsuario("AC"))
            {
                new MainWindow().ShowDialog();
            }
            else 
            {
                MessageBox.Show(this, "Usuario o contraseña invalida, favor verificar", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);              
                txtContrasena.Text = "";
                txtContrasena.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtUserId.Text= openFileDialog1.FileName;
        }
    }
}
