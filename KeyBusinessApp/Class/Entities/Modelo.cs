/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       12-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones de un modelo.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeyBusinessApp.Class.Tools;
using System.Data;

namespace KeyBusinessApp.Class.Entities
{
    class Modelo
    {
        private int     idModelo;
        private int     idMarca;
        private int     idClase;       
        private string  codReferencia;      
        private string  descripcion;        
        private string  estado;
        private DBTools dbTools;
        private DataSet dsDatosModelo;

        public Modelo()
        {
            dbTools = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosModelo = new DataSet();
        }

        /// <summary>
        /// Función encargada de buscar los datos de un modelo por distintos criterios(idModelo,idMarca,idClase,codRef,Descripcion,Estado,Descripcion Marca,Descripcion Clase,Descripción Modelo,null(para buscar todos los datos)).
        /// </summary>
        /// <param name="criterio">Criterio de busqueda.</param>
        /// <param name="?">Valor del criterio</param>
        /// <returns></returns>
        public void buscaDatosModelo(string criterio, string valor)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT [N_ID_MODELO],[C_COD_REFERENCIA],[C_DESCRIPCION],[C_ESTADO]");
            sqlQuery.Append(" FROM Kb_C_Modelo");
           
            if (criterio != null)
            {
                //Verificamos el criterio de búsqueda enviado para construir el where.
                if (criterio.Equals("idModelo"))
                {
                    sqlQuery.Append(" WHERE N_ID_MODELO = " + valor);
                }
              
                if (criterio.Equals("codRef"))
                {
                    sqlQuery.Append(" WHERE C_COD_REFERENCIA like '%" + valor + "%'");
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
            dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosModelo", ref dsDatosModelo);

        }

        public void grabarDatosModelo(string codRef, string descripcion, string estado)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("INSERT INTO [Kb_C_Modelo]");                        
            sqlQuery.Append("([C_COD_REFERENCIA]");       
            sqlQuery.Append(",[C_DESCRIPCION]");  
            sqlQuery.Append(",[C_ESTADO])");
            sqlQuery.Append(" VALUES");
            sqlQuery.Append("('" + codRef + "'");
            sqlQuery.Append(",'" + descripcion + "'");
            sqlQuery.Append(",'" + estado + "')");
            dbTools.executeInsertStatement(sqlQuery.ToString());
        }
        public void actualizarDatosModelo(int idModelo, string codRef, string descripcion, string estado)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(" UPDATE [Kb_C_Modelo] SET [C_DESCRIPCION] = '" + descripcion + "'");
            sqlQuery.Append(",[C_COD_REFERENCIA]      = '" + codRef + "'");
            sqlQuery.Append(",[C_ESTADO]           = '" + estado + "'");
            sqlQuery.Append(" WHERE N_ID_MODELO    = " + idModelo);
            dbTools.executeUpdateStatement(sqlQuery.ToString());
        }
        public DataTable obtenerDatosModelo()
        {
            return dsDatosModelo.Tables["DatosModelo"];
        }
        

        public int IdModelo
        {
            get { return idModelo; }
            set { idModelo = value; }
        }

        public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }

        public int IdClase
        {
            get { return idClase; }
            set { idClase = value; }
        }

        public string CodReferencia
        {
            get { return codReferencia; }
            set { codReferencia = value; }
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
    }
}
