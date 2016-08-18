/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       09-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones de un cliente.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeyBusinessApp.Class.Tools;
using System.Data;

namespace KeyBusinessApp.Class.Entities
{
    class Cliente
    {
        DBTools dbTools;
        DataSet dsDatosCliente;

        public Cliente() 
        {
            dbTools        = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosCliente = new DataSet();
        }

        /// <summary>
        /// Función encargada de buscar los datos de clientes por distintos criterios(idCliente, descSucursal, cedCliente, nombreClie, apeCliente,telCliente,sexo,direccion,estatus)
        /// </summary>
        /// <param name="criterio">Criterio de busqueda.</param>
        /// <param name="?">Valor del criterio</param>
        /// <returns></returns>
        public void buscaDatosCliente(string criterio, string valor)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT clie.[N_ID_CLIENTE]");
            sqlQuery.Append(",clie.[N_ID_SUCURSAL]");
            sqlQuery.Append(",suc.[C_DESCRIPCION]");
            sqlQuery.Append(",clie.[C_CEDULA_CLIENTE]");
            sqlQuery.Append(",clie.[C_NOMBRE_CLIENTE]");
            sqlQuery.Append(",clie.[C_APELLIDO_CLIENTE]");
            sqlQuery.Append(",clie.[C_TELEFONO_CLIENTE]");
            sqlQuery.Append(",clie.[C_SEXO_CLIENTE]");
            sqlQuery.Append(",clie.[C_DIRECCION_CLIENTE]");
            sqlQuery.Append(",clie.[D_FECHA_REGISTRO]");
            sqlQuery.Append(",clie.[C_ESTATUS_CLIENTE]");
            sqlQuery.Append(",clie.[D_FECHA_NACIMIENTO]");
            sqlQuery.Append(" FROM  [Kb_C_Cliente] clie, Kb_C_Sucursal suc");
            sqlQuery.Append(" WHERE clie.N_ID_SUCURSAL = suc.N_ID_SUCURSAL");


            if (criterio != null)
            {
                //Verificamos el criterio de búsqueda enviado para construir el where.
                if (criterio.Equals("idCliente"))
                {
                    sqlQuery.Append(" and clie.[N_ID_CLIENTE] = " + valor);
                }
                if (criterio.Equals("descSucursal"))
                {
                    sqlQuery.Append(" and suc.C_DESCRIPCION like '%" + valor + "%'");
                }
                if (criterio.Equals("cedCliente"))
                {
                    sqlQuery.Append(" and clie.[C_CEDULA_CLIENTE] like '%" + valor + "%'");
                }
                if (criterio.Equals("nombreClie"))
                {
                    sqlQuery.Append(" and clie.[C_NOMBRE_CLIENTE] like '%" + valor + "%'");
                }
                if (criterio.Equals("apeCliente"))
                {
                    sqlQuery.Append(" and clie.[C_APELLIDO_CLIENTE] like '%" + valor + "%'");
                }
                if (criterio.Equals("telCliente"))
                {
                    sqlQuery.Append(" and clie.[C_TELEFONO_CLIENTE] like '%" + valor + "%'");
                }
                if (criterio.Equals("sexo"))
                {
                    sqlQuery.Append(" and clie.[C_SEXO_CLIENTE] Like '%" + valor + "%'");
                }

                if (criterio.Equals("estatus"))
                {
                    sqlQuery.Append(" and clie.[C_ESTATUS_CLIENTE] Like '%" + valor + "%'");
                }

                if (criterio.Equals("direccion"))
                {
                    sqlQuery.Append(" and clie.[C_DIRECCION_CLIENTE] Like '%" + valor + "%'");
                }

            }
            dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosClientes", ref dsDatosCliente);
        }

        public void grabarDatosCliente(int idSucursal, string cedCliente,string nombre,string apellido, string telefono,string sexo,string direccion, string estatus,string fechaNac)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("INSERT INTO [Kb_C_Cliente]");
            sqlQuery.Append("([N_ID_SUCURSAL]");
            sqlQuery.Append(", [C_CEDULA_CLIENTE]");
            sqlQuery.Append(",[C_NOMBRE_CLIENTE]");
            sqlQuery.Append(",[C_APELLIDO_CLIENTE]");
            sqlQuery.Append(",[C_TELEFONO_CLIENTE]");
            sqlQuery.Append(",[C_SEXO_CLIENTE]");
            sqlQuery.Append(",[C_DIRECCION_CLIENTE]");
            sqlQuery.Append(",[C_ESTATUS_CLIENTE]");
            sqlQuery.Append(",[D_FECHA_NACIMIENTO])");
            sqlQuery.Append(" VALUES");
            sqlQuery.Append("(" + idSucursal);
            sqlQuery.Append(",'" + cedCliente + "'");
            sqlQuery.Append(",'" + nombre + "'");
            sqlQuery.Append(",'" + apellido + "'");
            sqlQuery.Append(",'" + telefono + "'");
            sqlQuery.Append(",'" + sexo + "'");
            sqlQuery.Append(",'" + direccion + "'");
            sqlQuery.Append(",'" + estatus + "'");
            sqlQuery.Append(",'" + fechaNac + "')");

            dbTools.executeInsertStatement(sqlQuery.ToString());
        }

        public void actualizarDatosCliente(int idCliente ,int idSucursal, string cedCliente, string nombreClie, string apeClie, string telefono, string sexo, string direccion, string status, string fechaNac)
        {

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(" UPDATE [Kb_C_Cliente] SET [N_ID_SUCURSAL] = " + idSucursal);
            sqlQuery.Append(",[C_CEDULA_CLIENTE]                 = " + cedCliente);
            sqlQuery.Append(",[C_NOMBRE_CLIENTE]                 = '" + nombreClie + "'");
            sqlQuery.Append(",[C_APELLIDO_CLIENTE]               = '" + apeClie + "'");
            sqlQuery.Append(",[C_TELEFONO_CLIENTE]               = '" + telefono + "'");
            sqlQuery.Append(",[C_SEXO_CLIENTE]                   = '" + sexo + "'");
            sqlQuery.Append(",[C_DIRECCION_CLIENTE]              = '" + direccion+ "'");
            sqlQuery.Append(",[C_ESTATUS_CLIENTE]                = '" + status +"'");
            sqlQuery.Append(",[D_FECHA_NACIMIENTO]               = '" + fechaNac + "'");
            sqlQuery.Append(" WHERE N_ID_CLIENTE                 = " + idCliente);
            dbTools.executeUpdateStatement(sqlQuery.ToString());
        }
        public DataTable obtenerDatosClientes()
        {
            return dsDatosCliente.Tables["DatosClientes"];
        }

    }
}
