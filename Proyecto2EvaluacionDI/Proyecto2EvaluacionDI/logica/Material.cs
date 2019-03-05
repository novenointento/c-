using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2EvaluacionDI.logica
{
    public class Material : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                this.name = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                this.cantidad = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Cantidad"));
            }
        }


        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set
            {
                this.tipo = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Tipo"));
            }
        }
        private int precio;
        public int Precio
        {
            get { return precio; }
            set
            {
                this.precio = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Precio"));
            }
        }


       public Material(String nombre,int cantidad,string tipo,int precio) {
           this.name = nombre;
           this.cantidad = cantidad;
           this.tipo = tipo;
           this.precio = precio;
           
       }

       public Material()
       {
         

       }

       public override string ToString()
       {
           return Name + " " + cantidad+" "+tipo+" "+precio+" €";
       }
       public event PropertyChangedEventHandler PropertyChanged;

       public object Clone()
       {
           return this.MemberwiseClone();
       }

       public string this[string columnName]
       {
           get
           {
               string result = "";
               if (columnName == "Name")
               {
                   if (String.IsNullOrEmpty(name))
                       result = "Debe introducir un nombre";
               }
               if (columnName == "Cantidad")
               {
                   if (cantidad<1)
                       result = "Debe introducir un valor positivo";
               }
               if (columnName == "Tipo")
               {
                   if (String.IsNullOrEmpty(tipo))
                       result = "Debe introducir un tipo";
               }
               if (columnName == "Precio")
               {
                   if (precio<1)
                       result = "Debe introducir un valor positivo";
               }
               return result;
           }
       }

       public string Error
       {
           get { return ""; }
       }
    }
}
