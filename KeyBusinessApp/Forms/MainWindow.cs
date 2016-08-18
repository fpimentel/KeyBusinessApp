using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeyBusinessApp.Class.Entities;
using KeyBusinessApp.Forms;

namespace KeyBusinessApp
{
    public partial class MainWindow : Form
    {
        Usuario   usuario;
        Perfil    perfil;
        Modulo    modulo;
        SubModulo subModulo;

        public MainWindow()
        {
            InitializeComponent();
            usuario = new Usuario();
            perfil  = new Perfil();
            modulo  = new Modulo();
            subModulo = new SubModulo();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //procedemos a buscar el o los perfiles del usuario.
            usuario.buscarPerfilUsuario();
                       

            //Perfiles
            DataTable perfiles = usuario.obtenerPerfiles();
            for (int perfilIndex = 0; perfilIndex < perfiles.Rows.Count; perfilIndex++) 
            {               
                //Modulos
                //Procedemos a buscar los modulos del perfil.
                usuario.Perfil.buscarModulosPerfil(perfiles.Rows[perfilIndex].ItemArray[0].ToString());

                DataTable modulos = usuario.Perfil.getDatosModulosPerfil();

                ToolStripMenuItem moduloItem;
                for (int moduloIndex = 0; moduloIndex < modulos.Rows.Count; moduloIndex++)
                {
                    moduloItem = new ToolStripMenuItem(modulos.Rows[moduloIndex].ItemArray[0].ToString());
                    
                    //Agregamos los modulos al menu.
                    menu.Items.AddRange(new ToolStripMenuItem[] { moduloItem });

                    //SUBMODULOS.

                    //Procedemos a buscar los submodulos del modulo.
                    modulo.buscarSubModulo(modulos.Rows[moduloIndex].ItemArray[0].ToString());

                    DataTable subModulos = modulo.getDatosModulosSubModulos();
                    
                    ToolStripMenuItem subModuloItem;
                    for (int subModuloIndex = 0; subModuloIndex < subModulos.Rows.Count; subModuloIndex++)
                    {
                        //Agregamos los submodulos al menu.

                        if (subModulos.Rows[subModuloIndex].ItemArray[1].ToString().Length > 0)
                        {
                            subModuloItem = new ToolStripMenuItem(subModulos.Rows[subModuloIndex].ItemArray[0].ToString(), Image.FromFile(subModulos.Rows[subModuloIndex].ItemArray[1].ToString()));
                        }
                        else
                        {
                            subModuloItem = new ToolStripMenuItem(subModulos.Rows[subModuloIndex].ItemArray[0].ToString(), null);
                        } 
                        moduloItem.DropDownItems.AddRange(new ToolStripItem[] {
                        subModuloItem});
                        
                        //OPCIONES.
                        //Procedemos a buscar las opciones.
                        subModulo.buscarDatosOpciones(subModulos.Rows[subModuloIndex].ItemArray[0].ToString());

                        DataTable opciones = subModulo.getDatosOpciones();
                        //Agregamos las opciones al menu.
                        for (int opcionesIndex = 0; opcionesIndex < opciones.Rows.Count; opcionesIndex++)
                        {                           
                            ToolStripMenuItem opcionesItem;
                            if (opciones.Rows[opcionesIndex].ItemArray[3].ToString().Length > 0)
                            {
                                 opcionesItem = new ToolStripMenuItem(opciones.Rows[opcionesIndex].ItemArray[0].ToString(), Image.FromFile(opciones.Rows[opcionesIndex].ItemArray[3].ToString()),new EventHandler(newOpenWindow_Click));
                            }
                            else 
                            {
                                 opcionesItem = new ToolStripMenuItem(opciones.Rows[opcionesIndex].ItemArray[0].ToString(), null, new EventHandler(newOpenWindow_Click));
                            }                            

                            opcionesItem.Name = opciones.Rows[opcionesIndex].ItemArray[2].ToString();
                            subModuloItem.DropDownItems.AddRange(new ToolStripItem[] {
                            opcionesItem});
                        }
                    }
                }
            }            
        }
        // encargado de abrir los formularios
        void newOpenWindow_Click(object sender, EventArgs e)
        {
            string nombreForm = ((ToolStripMenuItem)(sender)).Name.ToString();

            if (nombreForm.Equals("frmClienteList")) 
            {
                new frmClienteList().ShowDialog();
            }
            if (nombreForm.Equals("frmUsuario"))
            {
                new frmUsuario().ShowDialog();
            }
            if (nombreForm.Equals("frmMarcaList"))
            {
                new frmMarcaList().ShowDialog();
            }
            if (nombreForm.Equals("frmClaseList"))
            {
                new frmClaseList().ShowDialog();
            } 
            if (nombreForm.Equals("frmModeloList"))
            {
                new frmModeloList().ShowDialog();
            }
            if (nombreForm.Equals("frmProductoList"))
            {
                new frmProductoList().ShowDialog();
            }
            if (nombreForm.Equals("frmTipoEmpresaList"))
            {
                new frmTipoEmpresaList().ShowDialog();
            }
            if (nombreForm.Equals("frmEmpresaList"))
            {
                new frmEmpresaList().ShowDialog();
            }
            if (nombreForm.Equals("frmSucursalList"))
            {
                new frmSucursalList().ShowDialog();
            }
            if (nombreForm.Equals("frmOpcionList"))
            {
                new frmOpcionList().ShowDialog();
            }
            if (nombreForm.Equals("frmFacturacion"))
            {
                new frmFacturacion().ShowDialog();
            }
            if (nombreForm.Equals("frmInventarioEntrada"))
            {
                new frmInventarioEntrada().ShowDialog();
            }
        }

    }
}
