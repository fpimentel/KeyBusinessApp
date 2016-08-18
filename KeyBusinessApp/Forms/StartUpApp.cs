using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using KeyBusinessApp.Class.Tools;

namespace KeyBusinessApp
{
    public partial class StartUpApp : Form
    {
        private  string                   conString;
        private DBTools                  dbTools;
        private Configuration            config;
        private ConnectionStringsSection connSec;
        private ConnectionStringSettings connStrSet;

        public StartUpApp()
        {
            InitializeComponent();
            config                      = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            connSec                     = config.ConnectionStrings;
            connStrSet                  = new ConnectionStringSettings();            
            connStrSet.Name             = "DataBaseConnectionString";
            dbTools                     = new DBTools();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conString = "Data Source=" + txtNombreServidor.Text + ";Initial Catalog= " + txtBaseDatos.Text + ";User Id=" + txtUsuario.Text + ";Password=" + txtContrasena.Text;
                dbTools.SqlConnection = new SqlConnection(conString);
                dbTools.openDbConection();               
                dbTools.closeDbConection();

                connStrSet.ConnectionString = conString;
                connSec.ConnectionStrings.Add(connStrSet);
                connSec.SectionInformation.ForceSave = true;

                config.Save(ConfigurationSaveMode.Full);

                if(!connSec.SectionInformation.IsProtected)
                {
                    connSec.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    connSec.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
                this.Close();
            }
            catch (SqlException ex1)
            {
                
                MessageBox.Show(this, "La cadena de conexión es invalida, favor verificar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBaseDatos.Text       = "";
                txtContrasena.Text      = "";
                txtNombreServidor.Text  = "";
                txtUsuario.Text         = "";

                //Poner aqui a que grabe en el log.
            }
            catch (Exception ex1)
            {
                MessageBox.Show(this, "", "La cadena de conexión es invalida, favor verificar.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Poner aqui a que grabe en el log.
            }
        }
    }
}