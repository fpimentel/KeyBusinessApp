/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       07-Sept-10
 * Descripcion: Clase encargada de gestionar los datos de un usuario.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeyBusinessApp.Class.Tools;
using System.Data;
using System.Data.SqlClient;
namespace KeyBusinessApp.Class.Entities
{
    class Usuario
    {
        private static string idUsuario;
        private string        nombreUsuario;
        private string        apellidoUsuario;
        private string        contrasena;
        private string        cedula;
        private string        email;
        private string        estatus;
        private DateTime      fechaIngreso;
        private string        telefono;
        private string        sexo;
        private DBTools       dbTools;
        private DataSet       dsDatosUsuario;
        private Perfil        perfil;

        public Usuario() 
        {
            //Verificamos si la cadena de conexion esta definida.
            if (Login.connSec.ConnectionStrings["DataBaseConnectionString"] != null) 
            {
                dbTools = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            }            
            dsDatosUsuario = new DataSet();
            perfil         = new Perfil();
        }

        public Usuario(string idUsuario, string contrasena)
        {
            dbTools         = new DBTools();
            dsDatosUsuario  = new DataSet();
            idUsuario       = IdUsuario;
            contrasena      = Contrasena;
        }
        public static string IdUsuario
        {
            get { return Usuario.idUsuario; }
            set { Usuario.idUsuario = value; }
        }

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public string ApellidoUsuario
        {
            get { return apellidoUsuario; }
            set { apellidoUsuario = value; }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public DBTools DbTools
        {
            get { return dbTools; }
            set { dbTools = value; }
        }

        public Perfil Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }

        public void buscarPerfilUsuario() 
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT usuPer.C_ID_PERFIL");
            sqlQuery.Append(" FROM   Kb_C_Usuario_Perfil usuPer, Kb_C_Usuario usu, Kb_C_Perfil per ");            
            sqlQuery.Append(" WHERE usu.C_ID_USUARIO          = usuPer.C_ID_USUARIO");
            sqlQuery.Append(" and   per.C_ID_PERFIL           = usuPer.C_ID_PERFIL");
            sqlQuery.Append(" and   usu.C_ID_USUARIO          = '" + Usuario.IdUsuario + "'");
            sqlQuery.Append(" and   usu.C_ESTATUS_USUARIO     =  'AC'");
            sqlQuery.Append(" and   per.C_ESTATUS_PERFIL      =  'AC'");
            sqlQuery.Append(" and   usuPer.C_ESTADO_USUARIO_PERFIL   =  'AC'");

            try
            {
                dbTools.executeSelectStatement(sqlQuery.ToString(), "Perfiles", ref dsDatosUsuario);
            }
            catch (SqlException ex1) 
            {
                AppTools.guardaLogErrores(ex1.Message);
            }
            catch (Exception ex2) 
            {
                AppTools.guardaLogErrores(ex2.Message);
            }                        
        }
        
        /// <summary>
        /// Funcion encargada de buscar un usuario por estatus, de acuerdo a su idUsuario,Contrasena y estatus.
        /// </summary>
        /// <param name="estatusUsuario">Estatus del usuario.</param>
        /// <returns></returns>
        public bool buscaUsuario(string estatusUsuario) 
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT 1");
            sqlQuery.Append(" FROM   Kb_C_Usuario");
            sqlQuery.Append(" WHERE C_ID_USUARIO           = '" + idUsuario + "'");
            sqlQuery.Append(" and   C_CONTRASENA_USUARIO   = '" + contrasena + "'");
            sqlQuery.Append(" and   C_ESTATUS_USUARIO      = '" + estatusUsuario + "'");

            dbTools.executeSelectStatement(sqlQuery.ToString(), "ExisteUsuario", ref dsDatosUsuario);

            if (dsDatosUsuario.Tables["ExisteUsuario"].Rows.Count > 0) 
            {
                return true;
            }
            return false;
        }
        public DataTable obtenerPerfiles() 
        {
            return dsDatosUsuario.Tables["Perfiles"];
        }
    }
}
