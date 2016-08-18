/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       18-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones de un Tipo de Empresa.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KeyBusinessApp.Class.Tools;

namespace KeyBusinessApp.Class.Entities
{
    class TipoEmpresa
    {
        private DBTools dbTools;
        private DataSet dsDatosTipoEmpresa;

        public TipoEmpresa() 
        {
            dbTools            = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosTipoEmpresa = new DataSet();
        }

        public void actualizarDatosTipoEmpresa(int idTipoEmpresa, string descripcion, string estatus)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(" UPDATE [Kb_C_Tipo_Empresa] SET [C_DESCRIPCION] = '" + descripcion + "'");
            sqlQuery.Append(",[C_ESTATUS]                    = '" + estatus + "'");            
            sqlQuery.Append(" WHERE N_ID_TIPO_EMPRESA      = " + idTipoEmpresa);

            dbTools.executeUpdateStatement(sqlQuery.ToString());
        }

        public void grabarDatosTipoEmpresa(string descripcion, string estatus)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("INSERT INTO [Kb_C_Tipo_Empresa]");
            sqlQuery.Append("([C_DESCRIPCION]");
            sqlQuery.Append(",[C_ESTATUS])");
            sqlQuery.Append(" VALUES");
            sqlQuery.Append("('" + descripcion + "'");
            sqlQuery.Append(",'" + estatus + "')");

            dbTools.executeInsertStatement(sqlQuery.ToString());
        }
        /// <summary>
        /// Función encargada de buscar los datos de un Tipo Empresa criterios(idTipoEmpresa, descripcion, estatus,null(para buscar todos los datos)).
        /// </summary>
        /// <param name="criterio">Criterio de busqueda.</param>
        /// <param name="?">Valor del criterio</param>
        /// <returns></returns>
        public void buscaDatosTipoEmpresa(string criterio, string valor)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT [N_ID_TIPO_EMPRESA]");
            sqlQuery.Append(",[C_DESCRIPCION]");
            sqlQuery.Append(",[C_ESTATUS]");
            sqlQuery.Append(" FROM [Kb_C_Tipo_Empresa] TipoEmp");            
						    
            if (criterio != null)
            {
                //Verificamos el criterio de búsqueda enviado para construir el where.
                if (criterio.Equals("idTipoEmpresa"))
                {
                    sqlQuery.Append(" WHERE TipoEmp.N_ID_TIPO_EMPRESA = " + valor);
                }
                if (criterio.Equals("descripcion"))
                {
                    sqlQuery.Append(" WHERE TipoEmp.C_DESCRIPCION like '%" + valor + "%'");
                }
                if (criterio.Equals("estatus"))
                {
                    sqlQuery.Append(" WHERE TipoEmp.C_ESTATUS like '%" + valor + "%'");
                }               
            }
            dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosTipoEmpresa", ref dsDatosTipoEmpresa);
        }
        public DataTable obtenerDatosTipoEmpresa()
        {
            return dsDatosTipoEmpresa.Tables["DatosTipoEmpresa"];
        }
    }
}
