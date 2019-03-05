using Proyecto2EvaluacionDI.logica;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2EvaluacionDI
{
    public class Avituallamiento : INotifyPropertyChanged, ICloneable, IDataErrorInfo

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

        private int puntoKilometrico;
        public int PuntoKilometrico
        {
            get { return puntoKilometrico; }
            set
            {
                this.puntoKilometrico = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("PuntoKilometrico"));
            }
        }


        private string personaContacto;
       public string PersonaContacto
        {
            get { return personaContacto; }
            set
            {
                this.personaContacto = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("PersonaContacto"));
            }
        }
       private int numeroContacto;
       public int NumeroContacto
       {
           get { return numeroContacto; }
           set
           {
               this.numeroContacto = value;
               this.PropertyChanged(this, new PropertyChangedEventArgs("NumeroContacto"));
           }
       }
       public ObservableCollection<Material> listaMateriales { get; set; }
     

       public  Avituallamiento(string nombre, int punto, string persona, int numero ) {
           this.name = nombre;
           this.puntoKilometrico = punto;
           this.personaContacto = persona;
           this.numeroContacto = numero;
           listaMateriales = new ObservableCollection<Material>();
           
       }

       public void  anadirMaterial(Material m){
           listaMateriales.Add(m);

       
       }
       public Avituallamiento() {
           listaMateriales = new ObservableCollection<Material>();
       }
       public event PropertyChangedEventHandler PropertyChanged;

       public object Clone()
       {
          return this.MemberwiseClone();
       }

       public string Error
       {
           get { return ""; }
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
               if (columnName == "PuntoKilometrico")
               {
                   if (puntoKilometrico < 1)
                       result = "Debe introducir un valor positivo";
               }
               if (columnName == "PersonaContacto")
               {
                   if (String.IsNullOrEmpty(personaContacto))
                       result = "Debe introducir una persona contacto";
               }
               if (columnName == "Precio")
               {
                   if (numeroContacto<1)
                       result = "Debe introducir un valor positivo";
               }
               return result;
           }
       }
    }
}
