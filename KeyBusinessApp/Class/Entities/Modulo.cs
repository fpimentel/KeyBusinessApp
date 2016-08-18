/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       08-Sept-10
 * Descripcion: Clase encargada de gestionar los datos de un modulo.
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
    class Modulo
    {
        private DBTools dbTools;
        private DataSet dsDatosModulos;

        public Modulo()
        {
            dbTools        = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosModulos = new DataSet();
        }

        public void buscarSubModulo(string modulo)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT modSubmo.C_ID_SUBMODULO,subMo.C_URL_ICON");
            sqlQuery.Append(" FROM   Kb_C_Modulo_SubModulo modSubmo, Kb_C_SubModulo subMo");
            sqlQuery.Append(" WHERE C_ID_MODULO           = '" + modulo + "'");
            sqlQuery.Append(" and   subMo.C_ID_SUBMODULO   = modSubmo.C_ID_SUBMODULO");
            sqlQuery.Append(" and   modSubmo.C_ESTADO              = 'AC'");
            try
            {
                dbTools.executeSelectStatement(sqlQuery.ToString(), "SubModulos", ref dsDatosModulos);
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
        public DataTable getDatosModulosSubModulos()
        {
            return dsDatosModulos.Tables["SubModulos"];
        }
    }     
}
