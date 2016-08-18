/*
 * Autor:       Fausto T. Pimentel Cruz
 * Fecha:       12-Sept-10
 * Descripcion: Clase que representa un item de un combobox.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyBusinessApp.Class.Tools
{
    class ItemCombo
    {
        private string    name;       
        private string    value;


        public ItemCombo(string name, string value)
        {
             this.name  = name; 
             this.value = value;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
           return name;
        }
      }
}

