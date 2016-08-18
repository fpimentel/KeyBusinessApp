/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       06-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones a nivel de base de datos de la
 * aplicacion.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KeyBusinessApp.Class.Tools
{
    class DBTools
    {
        #region "Atributos"
            private SqlConnection  sqlConnection;
            private SqlCommand     sqlCommand;
            private SqlDataAdapter sqlDataAdapter;
            SqlTransaction         sqlTransaction;
        #endregion

        #region"Constructores"
            public DBTools()
            {
                sqlConnection = new SqlConnection();
                sqlCommand    = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
            }

            public DBTools(string connString)
            {
                sqlConnection         = new SqlConnection(connString);
                sqlCommand            = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
            }
        #endregion              

        #region"Propiedades."
            public SqlConnection SqlConnection
            {
                get { return sqlConnection; }
                set { sqlConnection = value; }
            }

            public SqlCommand SqlCommand
            {
                get { return sqlCommand; }
                set { sqlCommand = value; }
            }
        #endregion        

        #region "Metodos Customs."

            public void openDbConection() 
            {               
                  sqlConnection.Open();                
            }
            public void closeDbConection()
            {
                  sqlConnection.Close();         
            }
            
            /// <summary>
            /// Funcion usada para invocar una sentencia select a nivel de base de datos.
            /// </summary>
            /// <param name="sqlQuery">  Sentencia Sql a ejecutar.</param>
            /// <param name="tableName"> Nombre de la tabla que se guardara en el DataSet.</param>
            /// <returns>DataSet</returns>
            public void executeSelectStatement(string sqlQuery, string tableName, ref DataSet dsDatos)
            {    
                sqlCommand.CommandText = sqlQuery;
               
                sqlDataAdapter         = new SqlDataAdapter(sqlCommand);
                    if (dsDatos.Tables[tableName] != null) 
                    {
                        dsDatos.Tables[tableName].Clear();
                    }
                   
                    try
                    {
                        sqlDataAdapter.Fill(dsDatos, tableName);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ha ocurrido un error inesperado.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AppTools.guardaLogErrores(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error inesperado.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AppTools.guardaLogErrores(ex.Message);
                    }
            }
            /// <summary>
            /// Función encargada de ejecutar un  insert statement en la base de datos.
            /// </summary>
            /// <param name="sqlQuery">Insert statement a ejecutar. </param>
            public void executeInsertStatement(string sqlQuery) 
            {
                try 
                {
                    sqlCommand.CommandText = sqlQuery;
                    openDbConection();
                    sqlCommand.ExecuteNonQuery();
                    closeDbConection();
                }
                catch(SqlException ex1)
                {
                    MessageBox.Show("Ha ocurrido un error inesperado.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppTools.guardaLogErrores(ex1.Message);
                }
                catch(Exception ex2)
                {
                    MessageBox.Show("Ha ocurrido un error inesperado.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppTools.guardaLogErrores(ex2.Message);
                }
            }

            /// <summary>
            /// Función encargada de ejecutar un  update statement en la base de datos.
            /// </summary>
            /// <param name="sqlQuery">Update statement a ejecutar. </param>
            /// 
            public void executeUpdateStatement(string sqlQuery)
            {
                try
                {
                    sqlCommand.CommandText = sqlQuery;
                    openDbConection();
                    sqlCommand.ExecuteNonQuery();
                    closeDbConection();
                }
                catch (SqlException ex1)
                {
                    MessageBox.Show("Ha ocurrido un error inesperado.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppTools.guardaLogErrores(ex1.Message);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Ha ocurrido un error inesperado.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppTools.guardaLogErrores(ex2.Message);
                }
            }
            /// <summary>
            /// Funcion que obtiene el query ejecutado.
            /// </summary>
            /// <returns></returns>
            public string currentSqlStatement() 
            {
                return sqlCommand.CommandText;
            }
            /// <summary>
            /// Función encargada de dar inicio a una transacción.
            /// </summary>
            public void beginTrans() 
            {
                sqlTransaction = sqlConnection.BeginTransaction();
            }
            /// <summary>
            /// Función encargada de dar commit a una transacción.
            /// </summary>
            public void commitTrans() 
            {
                sqlTransaction.Commit();
            }
            /// <summary>
            /// Función encargada de dar rollback a una transacción.
            /// </summary>
            public void rollBackTrans() 
            {
                sqlTransaction.Rollback();
            }
        #endregion
    }
}
