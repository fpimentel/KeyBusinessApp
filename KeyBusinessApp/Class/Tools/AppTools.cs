/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       08-Sept-10
 * Descripcion: Clase encargada de gestionar las operaciones generales de la aplicacion.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace KeyBusinessApp.Class.Tools
{
    class AppTools
    {
        public static void guardaLogErrores(string message)
        {
            string errorPath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf(".")) + ".err";
            StreamWriter swError;
            try
            {
                FileInfo fiError = new FileInfo(errorPath);
                swError = fiError.AppendText();
                swError.WriteLine(System.DateTime.Now + " : " + message);
                swError.Flush();
                swError.Close();
            }
            catch (FileNotFoundException ex)
            {
            }
            catch (IOException ex2)
            {
            }
            catch (Exception ex3)
            {
            }
        }
        /// <summary>
        /// Valida que un texto sea numerico
        /// </summary>
        /// <returns></returns>
        public static bool isNumeric(string numero) 
        {
            Regex regex = new Regex("^[0-9]*$");
            return regex.IsMatch(numero);
        }
    public static string encriptarMD5(string cadena){
        string claveCifrada;
        StringBuilder cadenaModificable = new StringBuilder();       
        try{
            MD5 cifradoMD5 = MD5.Create();
            int arrayElement; 
            Byte[]arrayBytes =  cifradoMD5.ComputeHash(Encoding.Default.GetBytes(cadena));//Crea arreglo de bytes en base a la cadena de caracteres
            
            for(arrayElement = 0; arrayElement < arrayBytes.Length; arrayElement++)
            {
                cadenaModificable.Append(arrayBytes[arrayElement].ToString("x2"));
                arrayBytes[arrayElement].ToString();       
            }
        }
        catch(Exception ex){}
        claveCifrada = cadenaModificable.ToString();
        return claveCifrada;
    }
 }
}
