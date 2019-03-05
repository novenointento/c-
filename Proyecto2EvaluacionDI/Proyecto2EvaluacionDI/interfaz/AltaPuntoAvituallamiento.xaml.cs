using Proyecto2EvaluacionDI.logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto2EvaluacionDI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class AltaPuntoAvituallamiento : Window
    {
       private LogicaNegocio logicaprincipal;
       public  Carrera carreraTemporal;
       public Boolean modificar;
       public int posicion;
       public Avituallamiento avituallamientoModificar;
       private int errores;

        public AltaPuntoAvituallamiento(LogicaNegocio logica, Carrera carrera)
        {
            InitializeComponent();
            this.logicaprincipal = logica;
            this.carreraTemporal = carrera;
            avituallamientoModificar = new Avituallamiento();
            this.DataContext = this.avituallamientoModificar;
            modificar = false;
       
        }
        public AltaPuntoAvituallamiento(LogicaNegocio logica, Avituallamiento avi,int posicion,Carrera carrera)
        {
            InitializeComponent();
            this.logicaprincipal = logica;
            this.carreraTemporal = carrera;
            this.avituallamientoModificar = avi;
            this.posicion = posicion;
            this.DataContext = avituallamientoModificar;
            this.modificar = true;

        }
        private void ButtonVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAlta_Click(object sender, RoutedEventArgs e)
        {
           
            if (modificar) {
                carreraTemporal.modificarPunto(avituallamientoModificar,posicion);
            }
            else
            {
              
                carreraTemporal.altaPunto(avituallamientoModificar);
                avituallamientoModificar = new Avituallamiento();
            }
            this.DataContext = avituallamientoModificar;
            this.Close();

        }
        public void validation(Object sender, ValidationErrorEventArgs e)
        {

            if (e.Action == ValidationErrorEventAction.Added)
            {
                errores++;
            }
            else
            {
                errores--;
            }

            if (errores == 0)
                ButtonAlta.IsEnabled = true;
            else
                ButtonAlta.IsEnabled = false;
              
        }


    }
}
