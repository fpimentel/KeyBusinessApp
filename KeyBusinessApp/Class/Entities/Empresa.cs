/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       19-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones de una Empresa.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeyBusinessApp.Class.Tools;
using System.Data;

namespace KeyBusinessApp.Class.Entities
{
    class Empresa
    {
        private DBTools dbTools;
        private DataSet dsDatosEmpresa;


        public Empresa() 
        {
            dbTools            = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosEmpresa     = new DataSet();
        }

        public void actualizarDatosEmpresa(int idEmpresa,int idTipoEmpresa, string empresa,string rnc, string estatus)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(" UPDATE [Kb_C_Empresa] SET [N_ID_TIPO_EMPRESA] = " + idTipoEmpresa);
            sqlQuery.Append(",[C_NOMBRE_EMPRESA]           = '" + empresa + "'");
            sqlQuery.Append(",[C_ESTATUS]                  = '" + estatus + "'");
            sqlQuery.Append(",[C_RNC]                      = '" + rnc + "'");
            sqlQuery.Append(" WHERE N_ID_EMPRESA      = " + idEmpresa);

            dbTools.executeUpdateStatement(sqlQuery.ToString());
        }

        public void grabarDatosEmpresa(int idTipoEmpresa, string empresa, string rnc, string estatus)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("INSERT INTO [Kb_C_Empresa]");
            sqlQuery.Append("([N_ID_TIPO_EMPRESA]");
            sqlQuery.Append(",[C_NOMBRE_EMPRESA]");
            sqlQuery.Append(",[C_RNC]");
            sqlQuery.Append(",[C_ESTATUS])");
            sqlQuery.Append(" VALUES");
            sqlQuery.Append("(" + idTipoEmpresa );
            sqlQuery.Append(",'" + empresa + "'");
            sqlQuery.Append(",'" + rnc + "'");
            sqlQuery.Append(",'" + estatus + "')");

            dbTools.executeInsertStatement(sqlQuery.ToString());
        }
        /// <summary>
        /// Función encargada de buscar los datos de una Empresa criterios(idEmpresa, empresa,Rnc, estatus,null(para buscar todos los datos)).
        /// </summary>
        /// <param name="criterio">Criterio de busqueda.</param>
        /// <param name="?">Valor del criterio</param>
        /// <returns></returns>
        public void buscaDatosEmpresa(string criterio, string valor)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT [N_ID_EMPRESA]");
            sqlQuery.Append(",[N_ID_TIPO_EMPRESA]");
            sqlQuery.Append(",[C_NOMBRE_EMPRESA]");
            sqlQuery.Append(",[C_RNC]");
            sqlQuery.Append(",[C_ESTATUS]");
            sqlQuery.Append(" FROM [Kb_C_Empresa] Emp");            
					
            if (criterio != null)
            {
                //Verificamos el criterio de búsqueda enviado para construir el where.
                if (criterio.Equals("idEmpresa"))
                {
                    sqlQuery.Append(" WHERE Emp.N_ID_EMPRESA = " + valor);
                }
                if (criterio.Equals("empresa"))
                {
                    sqlQuery.Append(" WHERE Emp.C_NOMBRE_EMPRESA LIKE '%" + valor + "%'");
                }
                if (criterio.Equals("RNC"))
                {
                    sqlQuery.Append(" WHERE Emp.C_RNC like '%" + valor + "%'");
                }
                if (criterio.Equals("estatus"))
                {
                    sqlQuery.Append(" WHERE Emp.C_ESTATUS like '%" + valor + "%'");
                }               
            }
            dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosEmpresa", ref dsDatosEmpresa);
        }
        public DataTable obtenerDatosEmpresa()
        {
            return dsDatosEmpresa.Tables["DatosEmpresa"];
        }
    }
}
