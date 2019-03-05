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
using System.Windows.Shapes;

namespace Proyecto2EvaluacionDI.interfaz
{
    /// <summary>
    /// Lógica de interacción para AltaCarrera.xaml
    /// </summary>
    public partial class AltaCarrera : Window
    {
        LogicaNegocio logicaprincipal;
        public Carrera carreraNueva;
        public int posicion;
        private Boolean modificar;
        private int errores;

        public AltaCarrera(LogicaNegocio logica)
        {
            InitializeComponent();
            this.logicaprincipal = logica;
            carreraNueva= new Carrera();
            this.DataContext = carreraNueva;
            this.modificar = false;
        }

        public AltaCarrera(LogicaNegocio logica, Carrera carreraModificada, int posicion)
        {
            InitializeComponent();
            this.logicaprincipal = logica;
            carreraNueva = carreraModificada;
            this.posicion = posicion;
            this.DataContext = carreraNueva;
            this.modificar = true;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (modificar)
            {
                logicaprincipal.modificarCarrera(carreraNueva, posicion);
            }
            else
            {
                logicaprincipal.anadirCarrera(carreraNueva);
            }
            this.Close();

        }
        public void validation(Object sender, ValidationErrorEventArgs e) {

            if (e.Action == ValidationErrorEventAction.Added)
            {
                errores++;
            }
            else
            {
                errores--;
            }

            if (errores == 0)
                botonAlta.IsEnabled = true;
            else
                botonAlta.IsEnabled = false;
        }
    }
}
