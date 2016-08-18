/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       08-Sept-10
 * Descripcion: Clase encargada de gestionar los datos de un perfil.
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
    class Perfil
    {
        private DBTools dbTools;
        private DataSet dsDatosPerfil;
      
        public Perfil()
        {
            if (Login.connSec.ConnectionStrings["DataBaseConnectionString"] != null) 
            {
                dbTools = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            }            
            dsDatosPerfil = new DataSet();
        }

        public void buscarModulosPerfil(string perfil)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT C_ID_MODULO");
            sqlQuery.Append(" FROM   Kb_C_Perfil_Modulo");
            sqlQuery.Append(" WHERE C_ID_PERFIL   = '" + perfil + "'");
            sqlQuery.Append(" and   C_ESTADO      = 'AC'");
            try
            {
                dbTools.executeSelectStatement(sqlQuery.ToString(), "Modulos", ref dsDatosPerfil);
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
        public DataTable getDatosModulosPerfil()
        {
              return dsDatosPerfil.Tables["Modulos"];          
        }
    }
}
