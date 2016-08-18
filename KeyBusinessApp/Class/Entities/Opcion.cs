/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       09-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones de una opcion.
 * aplicacion.
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
    class Opcion
    {
        #region"atributos"
        DBTools         dbTools;
        private string idOpcion;
        private string descripcion;
        private string nombreFormulario;
        private string url_Icon;
        private string estado;
        private DataSet dsDatosOpcion;
        #endregion

        #region "Constructors"
        public Opcion()
        {
            dbTools = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosOpcion = new DataSet();
        }
       
        #endregion

        #region "Propiedades"
        public string IdOpcion
        {
            get { return idOpcion; }
            set { idOpcion = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string NombreFormulario
        {
            get { return nombreFormulario; }
            set { nombreFormulario = value; }
        }
        public string Url_Icon
        {
            get { return url_Icon; }
            set { url_Icon = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }   
        #endregion 
        

        /// <summary>
        /// Función encargada de buscar los datos de las opciones  por distintos criterios(idOpcion,descripcion,estatus).
        /// </summary>
        /// <param name="criterio">Criterio de busqueda.</param>
        /// <param name="?">Valor del criterio</param>
        /// <returns></returns>
        public void buscarDatosopcion(string criterio, string valor)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT [C_ID_OPCION],[C_DESCRIPCION],[C_NOMBRE_FORMULARIO],[C_ESTATUS],[C_URL_ICON]");
            sqlQuery.Append(" FROM [Kb_C_Opcion]");
            
            if (criterio != null)
            {
                //Verificamos el criterio de búsqueda enviado para construir el where.
                if (criterio.Equals("ID_OPCION"))
                {
                    sqlQuery.Append(" WHERE C_ID_OPCION  like '%" + valor + "%'");
                }
                if (criterio.Equals("Descripcion"))
                {
                    sqlQuery.Append(" WHERE C_DESCRIPCION like '%" + valor + "%'");
                }

                if (criterio.Equals("Estado"))
                {
                    sqlQuery.Append(" WHERE C_ESTATUS Like '%" + valor + "%'");
                }                
            }
            dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosOpcion", ref dsDatosOpcion);
      
        }
        /** recordemos que el campo url icon puede ser  nulo*/
        public void grabarDatosOpcion(string idOpcion,string descripcion,string nombresFormulario,string urlIcon, string estado )
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("INSERT INTO [Kb_C_Opcion]");
            sqlQuery.Append("([C_ID_OPCION]");
            sqlQuery.Append(",[C_DESCRIPCION]");
            sqlQuery.Append(",[C_NOMBRE_FORMULARIO]");
            sqlQuery.Append(",[C_URL_ICON]");
            sqlQuery.Append(",[C_ESTATUS])");
            sqlQuery.Append(" VALUES");
            sqlQuery.Append("('" + idOpcion + "'");
            sqlQuery.Append(",'" + descripcion + "'");
            sqlQuery.Append(",'" + nombresFormulario + "'");
            sqlQuery.Append(",'"+ urlIcon + " ' " );
            sqlQuery.Append(",'" + estado + " ' )");
            dbTools.executeInsertStatement(sqlQuery.ToString());
        }
        /* Pregunta?? si no quisieramos modificari la url y nadamas la descripcion
        le enviariamos en el mantenimiento el campo null pero entonces este se asignaria en la base de datos */
        public void actualizarDatosOpcion(string idOpcion, string descripcion,string nombreFormulario, string urlIcon, string estado)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(" UPDATE [Kb_C_Opcion] SET [C_DESCRIPCION] = '" + descripcion + "',");
            sqlQuery.Append("[C_ESTATUS]                                = '" + estado + "',");
            sqlQuery.Append("[C_NOMBRE_FORMULARIO] = '"                     +nombreFormulario + "',");
            sqlQuery.Append("[C_URL_ICON]          = '"                     + urlIcon + "'");
            sqlQuery.Append(" WHERE C_ID_OPCION    = '"                     + idOpcion + "'");
            dbTools.executeUpdateStatement(sqlQuery.ToString());
        } 
        /// <summary>
        /// Funcion que devuelve un DataTable con los datos obtenidos de la funcion buscarDatosopcion
        /// </summary>
        /// <returns></returns>
        public DataTable obtenerDatosOpcion() 
        {
            return dsDatosOpcion.Tables["DatosOpcion"];
        }

        internal void buscarDatosopcion()
        {
            throw new NotImplementedException();
        }
    }
}
