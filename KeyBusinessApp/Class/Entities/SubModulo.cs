/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       08-Sept-10
 * Descripcion: Clase encargada de gestionar los datos de un SubModulo.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KeyBusinessApp.Class.Tools;
using System.Data.SqlClient;

namespace KeyBusinessApp.Class.Entities
{
    class SubModulo
    {
        private DBTools dbTools;
        private DataSet dsDatosSubModulo;

        public SubModulo()
        {
            dbTools        = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosSubModulo = new DataSet();
        }

        public void buscarDatosOpciones(string subModulo)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT subMoOpc.C_ID_OPCION,C_DESCRIPCION,opc.C_NOMBRE_FORMULARIO,C_URL_ICON,C_ESTATUS");
            sqlQuery.Append(" FROM   Kb_C_Submodulo_Opcion subMoOpc, Kb_C_Opcion opc");
            sqlQuery.Append(" WHERE subMoOpc.C_ID_OPCION    = opc.C_ID_OPCION");
            sqlQuery.Append(" and   subMoOpc.C_ID_SUBMODULO = '" + subModulo + "'");
            sqlQuery.Append(" and   C_ESTADO                = 'AC'");
            try
            {
                dbTools.executeSelectStatement(sqlQuery.ToString(), "Opciones", ref dsDatosSubModulo);
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
        public DataTable getDatosOpciones()
        {
            return dsDatosSubModulo.Tables["Opciones"];
        }
    }
}
