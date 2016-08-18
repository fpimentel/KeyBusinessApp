/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       13-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones de un Producto.
 * aplicacion.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KeyBusinessApp.Class.Tools;

namespace KeyBusinessApp.Class.Entities
{
    class Producto
    {
        #region"Atributos"        
            private int     idProducto;       
            private int     idClase;       
            private int     idMarca;       
            private int     idModelo;       
            private string  codReferencia;
            private string  descripcion;       
            private string  estado;
            private DBTools dbTools;
            private DataSet dsDatosProducto;
        #endregion

        public Producto() 
        {
            dbTools         = new DBTools(Login.connSec.ConnectionStrings["DataBaseConnectionString"].ConnectionString);
            dsDatosProducto = new DataSet();
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public int IdClase
        {
            get { return idClase; }
            set { idClase = value; }
        }

        public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }

        public int IdModelo
        {
            get { return idModelo; }
            set { idModelo = value; }
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
        /// <summary>
        /// Función encargada de buscar un producto en especifico
        /// </summary>
        /// <param name="idClase">idClase de producto</param>
        /// <param name="idMarca"> idMarca del producto</param>
        /// <param name="idModelo">idModelo del producto</param>
        public void buscarProducto(int idClase, int idMarca, int idModelo) 
        {
             StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("select * From Kb_C_Producto pro");
            sqlQuery.Append(" where pro.N_ID_CLASE  = " + idClase);
            sqlQuery.Append("   and pro.N_ID_MARCA  = " + idMarca);
            sqlQuery.Append("   and pro.N_ID_MODELO = " + idModelo);

            dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosProductos", ref dsDatosProducto);
        }


        /// Función encargada de buscar los datos de un producto por distintos criterios(idProducto, descClase,, descMarca, descModelo, codRef, descProducto, estado,null(para buscar todos los datos)).
        /// </summary>
        /// <param name="criterio">Criterio de busqueda.</param>
        /// <param name="?">Valor del criterio</param>
        /// <returns></returns>
        public void buscaDatosProducto(string criterio, string valor)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT pro.[N_ID_PRODUCTO],pro.[N_ID_CLASE],");
            sqlQuery.Append(" cla.C_DESCRIPCION descClase, pro.[N_ID_MARCA],");
            sqlQuery.Append(" marc.C_DESCRIPCION_MARCA, pro.[N_ID_MODELO],");
            sqlQuery.Append(" pro.[C_COD_REFERENCIA],pro.[C_DESCRIPCION] descPro,pro.[C_ESTADO], mo.C_DESCRIPCION descMod, pro.N_PORCENTAJE_MIN, pro.N_PORCENTAJE_MAX,");
            sqlQuery.Append(" pro.N_CANT_MIN_INVENT,pro.N_CANT_MAX_INVENT");
            sqlQuery.Append(" ,pro.N_ID_SUCURSAL");
            sqlQuery.Append(" FROM [Kb_C_Producto] pro, ");
            sqlQuery.Append(" Kb_C_Clase_Producto cla,");
            sqlQuery.Append(" Kb_C_Marca marc,");
            sqlQuery.Append(" Kb_C_Modelo mo");
            sqlQuery.Append(" WHERE pro.N_ID_CLASE  = cla.N_ID_CLASE");
            sqlQuery.Append(" and pro.N_ID_MARCA  = marc.N_ID_MARCA");
            sqlQuery.Append(" and pro.N_ID_MODELO = mo.N_ID_MODELO");			
			    
            if (criterio != null)
            {
                //Verificamos el criterio de búsqueda enviado para construir el where.
                if (criterio.Equals("idProducto"))
                {
                    sqlQuery.Append(" and pro.N_ID_PRODUCTO = " + valor);
                }
                if (criterio.Equals("descClase"))
                {
                    sqlQuery.Append(" and cla.C_DESCRIPCION like '%" + valor + "%'");
                }
                if (criterio.Equals("descMarca"))
                {
                    sqlQuery.Append(" and marc.C_DESCRIPCION_MARCA like '%" + valor + "%'");
                }
                if (criterio.Equals("descModelo"))
                {
                    sqlQuery.Append(" and mo.C_DESCRIPCION like '%" + valor + "%'");
                }
                if (criterio.Equals("codRef"))
                {
                    sqlQuery.Append(" and pro.C_COD_REFERENCIA like '%" + valor + "%'");
                }
                if (criterio.Equals("descProducto"))
                {
                    sqlQuery.Append(" and pro.C_DESCRIPCION like '%" + valor + "%'");
                }                
                if (criterio.Equals("Estado"))
                {
                    sqlQuery.Append(" and pro.C_ESTADO Like '%" + valor + "%'");
                }

            }
            dbTools.executeSelectStatement(sqlQuery.ToString(), "DatosProductos", ref dsDatosProducto);
        }

        public void grabarDatosProducto(int idSucursal,int idClase, int idMarca, int idModelo, string codRef, string descripcion,int porcentMin, int porcentMax,int inventMin, int inventMax,bool aplicaLote, string estado)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("INSERT INTO [Kb_C_Producto]");
            sqlQuery.Append("([N_ID_CLASE]");
            sqlQuery.Append(", N_ID_SUCURSAL");
            sqlQuery.Append(",[N_ID_MARCA]");
            sqlQuery.Append(",[N_ID_MODELO]");
            sqlQuery.Append(",[C_COD_REFERENCIA]");
            sqlQuery.Append(",[C_DESCRIPCION]");
            sqlQuery.Append(",[N_PORCENTAJE_MIN]");
            sqlQuery.Append(",[N_PORCENTAJE_MAX]");
            sqlQuery.Append(",[N_CANT_MIN_INVENT]");
            sqlQuery.Append(",[B_APLICA_LOTE]");
            sqlQuery.Append(",[C_ESTADO])");
            sqlQuery.Append(" VALUES");
            sqlQuery.Append("(" + idClase );
            sqlQuery.Append("," + idSucursal);
            sqlQuery.Append("," + idMarca );
            sqlQuery.Append("," + idModelo );
            sqlQuery.Append(",'" + codRef + "'");
            sqlQuery.Append(",'" + descripcion + "'");
            sqlQuery.Append(","  + porcentMin);
            sqlQuery.Append(","  + porcentMax);
            sqlQuery.Append("," + inventMin);
            sqlQuery.Append("," + inventMax);
            sqlQuery.Append("," + aplicaLote);
            sqlQuery.Append(",'" + estado + "')");

            dbTools.executeInsertStatement(sqlQuery.ToString());
        }
        public void actualizarDatosProducto(int idSucursal,int idProducto, int idClase, int idMarca, int idModelo, string codRef, string descripcion, int porcentMin, int porcentMax ,int inventMin, int inventMax,bool aplicaLote,string estado)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(" UPDATE [Kb_C_Producto] SET [N_ID_CLASE] = " + idClase);
            sqlQuery.Append(",[N_ID_MARCA]                  = " + idMarca );
            sqlQuery.Append(", N_ID_SUCURSAL                = " + idSucursal);            
            sqlQuery.Append(",[N_ID_MODELO]                 = " + idModelo );
            sqlQuery.Append(",[C_COD_REFERENCIA]            = '" + codRef +"'");
            sqlQuery.Append(",[C_DESCRIPCION]               = '" + descripcion + "'");
            sqlQuery.Append(",[N_PORCENTAJE_MIN]            = " + porcentMin);
            sqlQuery.Append(",[N_PORCENTAJE_MAX]            = " + porcentMax);
            sqlQuery.Append(",[N_CANT_MIN_INVENT]           = " + inventMin);
            sqlQuery.Append(",[N_CANT_MAX_INVENT]           = " + inventMax);
            sqlQuery.Append(",[B_APLICA_LOTE]               = " + aplicaLote);
            sqlQuery.Append(",[C_ESTADO]                    = '" + estado + "'");
            sqlQuery.Append(" WHERE N_ID_PRODUCTO           = " + idProducto);
            dbTools.executeUpdateStatement(sqlQuery.ToString());
        }
        public DataTable obtenerDatosProducto()
        {
            return dsDatosProducto.Tables["DatosProductos"];
        }

    }
}
