/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       09-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones de una Clase.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeyBusinessApp.Class.Tools;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KeyBusinessApp.Class.Entities
{
    class Clase
    {
        DBTools         dbTools;
        private int     idClase;
        private string  codClase;
        private string  descripcion;
        private string  estado;
        private DataSet dsDatosClase;

        #region "Constructors"
        public Clase()
        {
            dbTools = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosClase = new DataSet();
        }
        #endregion

        #region "Propiedades"
        public int IdClase
        {
            get { return idClase; }
            set { idClase = value; }
        }
        public string CodClase
        {
            get { return codClase; }
            set { codClase = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion 
        

        /// <summary>
        /// Función encargada de buscar los datos de una clase por distintos criterios(idClase,CodigoRef,Descripcion,Estado,null(para buscar todos los datos)).
        /// </summary>
        /// <param name="criterio">Criterio de busqueda.</param>
        /// <param name="?">Valor del criterio</param>
        /// <returns></returns>
        public void buscaDatosClase(string criterio, string valor)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT [N_ID_CLASE],[C_COD_CLASE],[C_DESCRIPCION],[C_ESTADO]");
            sqlQuery.Append(" FROM Kb_C_Clase_Producto");
            
            if (criterio != null)
            {
                //Verificamos el criterio de búsqueda enviado para construir el where.
                if (criterio.Equals("idClase"))
                {
                    sqlQuery.Append(" WHERE N_ID_CLASE = " + valor);
                }
                if (criterio.Equals("CodigoRef"))
                {
                    sqlQuery.Append(" WHERE C_COD_CLASE like '%" + valor + "%'");
                }
                if (criterio.Equals("Descripcion"))
                {
                    sqlQuery.Append(" WHERE C_DESCRIPCION like '%" + valor + "%'");
                }
                if (criterio.Equals("Estado"))
                {
                    sqlQuery.Append(" WHERE C_ESTADO Like '%" + valor + "%'");
                }                
            }
            dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosClase", ref dsDatosClase);
      
        }
        public void grabarDatosClase(string codRef,string descripcion,string estado)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("INSERT INTO [Kb_C_Clase_Producto]");
            sqlQuery.Append("([C_COD_CLASE]");
            sqlQuery.Append(",[C_DESCRIPCION]");
            sqlQuery.Append(",[C_ESTADO])");
            sqlQuery.Append(" VALUES");
            sqlQuery.Append("('" + codRef      + "'");
            sqlQuery.Append(",'" + descripcion + "'");
            sqlQuery.Append(",'" + estado      + "')");           
            dbTools.executeInsertStatement(sqlQuery.ToString());
        }
        public void actualizarDatosClase(int idClase, string descripcion, string estado)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(" UPDATE [Kb_C_Clase_Producto] SET [C_DESCRIPCION] = '" + descripcion + "',");
            sqlQuery.Append("[C_ESTADO]      = '"                       + estado +"'");
            sqlQuery.Append(" WHERE N_ID_CLASE =" + idClase);
            dbTools.executeUpdateStatement(sqlQuery.ToString());
        }    
        public DataTable obtenerDatosClase() 
        {
            return dsDatosClase.Tables["DatosClase"];
        }        
    }
}
