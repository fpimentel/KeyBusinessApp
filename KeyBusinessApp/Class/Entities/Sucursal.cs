/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       24-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones de una Sucursal.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeyBusinessApp.Class.Tools;
using System.Data;

namespace KeyBusinessApp.Class.Entities
{
    class Sucursal
    {
        private DBTools dbTools;
        private DataSet dsDatosSucursal;


        public Sucursal() 
        {
            dbTools            = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosSucursal = new DataSet();
        }

        public void actualizarDatosSucursal(int idSucursal, int idEmpresa,string descSucursal, string direccion,string rnc, string estatus)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(" UPDATE [Kb_C_Sucursal] SET [N_ID_EMPRESA] = " + idEmpresa);
            sqlQuery.Append(",[C_DESCRIPCION]                  = '" + descSucursal + "'");
            sqlQuery.Append(",[C_DIRECCION]                    = '" + direccion + "'");
            sqlQuery.Append(",[C_RNC]                          = '" + rnc + "'");
            sqlQuery.Append(",[C_ESTATUS]                      = '" + estatus + "'");
            sqlQuery.Append(" WHERE N_ID_SUCURSAL      = " + idSucursal);

            dbTools.executeUpdateStatement(sqlQuery.ToString());
        }

        public void grabarDatosSucursal(int idEmpresa, string descSucursal, string direccion, string rnc, string estatus)
        {           
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("INSERT INTO [Kb_C_Sucursal]");
            sqlQuery.Append("([N_ID_EMPRESA]");
            sqlQuery.Append(",[C_DESCRIPCION]");
            sqlQuery.Append(",[C_DIRECCION]");
            sqlQuery.Append(",[C_RNC]");
            sqlQuery.Append(",[C_ESTATUS])");
            sqlQuery.Append(" VALUES");
            sqlQuery.Append("(" + idEmpresa );
            sqlQuery.Append(",'" + descSucursal + "'");
            sqlQuery.Append(",'" + direccion + "'");
            sqlQuery.Append(",'" + rnc + "'");
            sqlQuery.Append(",'" + estatus + "')");

            dbTools.executeInsertStatement(sqlQuery.ToString());
        }
        /// <summary>
        /// Función encargada de buscar los datos de una sucursal criterios(idSucursal,idEmpresa, descSucursal,direccion, Rnc, estatus,null(para buscar todos los datos)).
        /// </summary>
        /// <param name="criterio">Criterio de busqueda.</param>
        /// <param name="?">Valor del criterio</param>
        /// <returns></returns>
        public void buscaDatosSucursal(string criterio, string valor)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT suc.[N_ID_SUCURSAL]");
            sqlQuery.Append(",suc.[N_ID_EMPRESA]");
            sqlQuery.Append(",suc.[C_DESCRIPCION]");
            sqlQuery.Append(",suc.[C_DIRECCION]");
            sqlQuery.Append(",suc.[C_RNC]");
            sqlQuery.Append(",suc.[C_ESTATUS]");
            sqlQuery.Append(" FROM [Kb_C_Sucursal] suc, Kb_C_Empresa emp");
            sqlQuery.Append(" WHERE suc.N_ID_EMPRESA = emp.N_ID_EMPRESA");   
					
            if (criterio != null)
            {
                //Verificamos el criterio de búsqueda enviado para construir el where.
                if (criterio.Equals("idSucursal"))
                {
                    sqlQuery.Append(" and suc.N_ID_SUCURSAL = " + valor);
                }
                if (criterio.Equals("idEmpresa"))
                {
                    sqlQuery.Append(" and emp.N_ID_EMPRESA = " + valor);
                }
                if (criterio.Equals("descSucursal"))
                {
                    sqlQuery.Append(" and suc.C_DESCRIPCION LIKE '%" + valor + "%'");
                }
                if (criterio.Equals("direccion"))
                {
                    sqlQuery.Append(" and suc.C_DIRECCION like '%" + valor + "%'");
                }
                if (criterio.Equals("Rnc"))
                {
                    sqlQuery.Append(" and suc.C_RNC like '%" + valor + "%'");
                }
                if (criterio.Equals("estatus"))
                {
                    sqlQuery.Append(" and suc.C_ESTATUS like '%" + valor + "%'");
                }               
            }
            dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosSucursal", ref dsDatosSucursal);
        }
        public DataTable obtenerDatosSucursal()
        {
            return dsDatosSucursal.Tables["DatosSucursal"];
        }
    }
}
