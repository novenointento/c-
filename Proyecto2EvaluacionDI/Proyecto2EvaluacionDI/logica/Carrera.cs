using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2EvaluacionDI
{
   public class Carrera : INotifyPropertyChanged, ICloneable, IDataErrorInfo

    {
      public  ObservableCollection<Avituallamiento> listaAvituallamientos{get; set;}
      private string name;
       public string Name {
           get { return name; }
           set {
               this.name = value;
               this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
           }
       }
     


       public Carrera(String nombre)
       {
           this.name = nombre;
           listaAvituallamientos = new ObservableCollection<Avituallamiento>();
       }

       public Carrera()
       {
           listaAvituallamientos = new ObservableCollection<Avituallamiento>();
       }

       public override string ToString()
       {
           return this.Name;
       }
       public void altaPunto(Avituallamiento punto) {

           listaAvituallamientos.Add(punto);

       }

       public void modificarPunto(Avituallamiento punto,int posicion) {
           listaAvituallamientos[posicion] = punto;
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
           get {
               string result = "";
               if (columnName == "Name") {
                   if (String.IsNullOrEmpty(name))
                       result = "Debe introducir un nombre";
               }
               return result;
           }
       }
    }


}
