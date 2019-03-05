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
using Proyecto2EvaluacionDI.interfaz;
using Proyecto2EvaluacionDI.logica;
namespace Proyecto2EvaluacionDI.interfaz
{
    /// <summary>
    /// Lógica de interacción para altaMaterialEnElPunto.xaml
    /// </summary>
    public partial class altaMaterialEnElPunto : Window
    {
        private LogicaNegocio logicaprincipal;
        private Avituallamiento avituallamientoSeleccionado;
      

        public altaMaterialEnElPunto(Avituallamiento avituallamiento,LogicaNegocio logica)
        {
           
            InitializeComponent();
            this.logicaprincipal = logica;
            DataContext = logicaprincipal;
            this.avituallamientoSeleccionado = avituallamiento;
        }

        private void butonAnadir_Click(object sender, RoutedEventArgs e)
        {

            Material material=(Material) comboMateriales.SelectedItem;
            avituallamientoSeleccionado.anadirMaterial(material);
            logicaprincipal.borrarMaterial(material);

        }

        private void volver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
