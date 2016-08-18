/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       09-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones de una marca.
 * aplicacion.
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
    class Marca
    {
        private string  descripcion;
        private string  estado;
        private DBTools dbTools;
        private DataSet dsDatosMarca;

        public Marca() 
        {            
            dbTools      = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosMarca = new DataSet();
        }

        /// <summary>
        /// Función encargada de buscar los datos de una marca por distintos criterios(idMarca,Descripcion,estado,null(para buscar todos los datos)).
        /// </summary>
        /// <param name="criterio"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public void buscaDatosMarca(string criterio, string valor)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT [N_ID_MARCA],[C_DESCRIPCION_MARCA],[ESTADO]");
            sqlQuery.Append("FROM Kb_C_Marca");

            if (criterio != null)
            {
                //Verificamos el criterio de búsqueda enviado para construir el where.
                if (criterio.Equals("idMarca"))
                {
                    sqlQuery.Append(" WHERE N_ID_MARCA = " + valor);
                }
                if (criterio.Equals("Descripcion"))
                {
                    sqlQuery.Append(" WHERE C_DESCRIPCION_MARCA like '%" + valor + "%'");
                }
                if (criterio.Equals("estado"))
                {
                    sqlQuery.Append(" WHERE ESTADO = '" + valor + "'");
                }
            }
            try
            {
                dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosMarca", ref dsDatosMarca);
            }
            catch (SqlException ex)
            {
                AppTools.guardaLogErrores(ex.Message);
            }
            catch (Exception ex) 
            {
                AppTools.guardaLogErrores(ex.Message);
            }            
        }

        /// <summary>
        /// Función encargada de buscar los datos de una marca por distintos criterios(idMarca,Descripcion,estado,null(para buscar todos los datos)).
        /// </summary>
        /// <param name="criterio"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public void buscaDatosMarcaActivas()
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT [N_ID_MARCA],[C_DESCRIPCION_MARCA],[ESTADO]");
            sqlQuery.Append(" FROM Kb_C_Marca");
            sqlQuery.Append(" WHERE ESTADO = 'AC'");         

            dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosMarcaActivas", ref dsDatosMarca);                       
        }
        public void grabarDatosMarca(string marca, string estado) 
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("INSERT INTO Kb_C_Marca(C_DESCRIPCION_MARCA,ESTADO)");
            sqlQuery.Append("Values('" + marca +"','" + estado+"')");
            dbTools.executeInsertStatement(sqlQuery.ToString()); 
        }
        public void actualizarDatosMarca(int idMarca, string marca, string estado)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("Update Kb_C_Marca SET C_DESCRIPCION_MARCA = '" + marca+"',");
            sqlQuery.Append("ESTADO = '" + estado + "'");
            sqlQuery.Append(" WHERE N_ID_MARCA =" + idMarca);
            dbTools.executeUpdateStatement(sqlQuery.ToString());
        }
        public DataTable obtenerMarcas() 
        {
            return dsDatosMarca.Tables["DatosMarca"];
        }

        public DataTable obtenerMarcasActivas()
        {
            return dsDatosMarca.Tables["DatosMarcaActivas"];
        }  
    }
}
