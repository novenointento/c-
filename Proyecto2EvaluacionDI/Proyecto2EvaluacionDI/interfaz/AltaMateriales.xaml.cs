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
using System.Collections.ObjectModel;

namespace Proyecto2EvaluacionDI
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class AltaMateriales : Window
    {
      
        public List<string> tipos { get; set; }
        public Material materialNuevo;
        public Avituallamiento avituallamiento;
        public LogicaNegocio logica;
        public Boolean modificar;
        public int posicion;
        private int errores;

        public AltaMateriales(LogicaNegocio logica) {
            InitializeComponent();
            tipos = new List<string>();
            tipos.Add("Comida");
            tipos.Add("Bebida");
            tipos.Add("Medicamento");
            materialNuevo = new Material();
            this.logica = logica;
            this.DataContext = materialNuevo;
            comboTipo.DataContext = this;
            this.modificar = false;
        }
        public AltaMateriales(LogicaNegocio logica,Material material,int posicion)
        {
            InitializeComponent();
            tipos = new List<string>();
            tipos.Add("Comida");
            tipos.Add("Bebida");
            tipos.Add("Medicamento");
            materialNuevo = material;
            this.logica = logica;
            this.DataContext = materialNuevo;
            comboTipo.DataContext = this;
            this.posicion = posicion;
            this.modificar = true;
        }

        private void altaMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (modificar) {
                logica.modificarMaterial(materialNuevo,posicion);

            }
            else
            {
                logica.anadirMaterial(materialNuevo);
                materialNuevo = new Material();    
            }
            this.Close();
        }

        private void buttonVolver_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }

        private void comboTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            materialNuevo.Tipo = (string)comboTipo.SelectedItem;
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
                altaMaterial.IsEnabled = true;
            else
                altaMaterial.IsEnabled = false;
        }
    }
}
