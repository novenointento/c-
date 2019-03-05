using Proyecto2EvaluacionDI.interfaz;
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

namespace Proyecto2EvaluacionDI
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class VisualizadorCarreras : Window
    {
     private   LogicaNegocio logicaprincipal = new LogicaNegocio() ;
       private  Carrera carreraSeleccionada;
       private Avituallamiento avituallamientoSeleccionado;
        
        public VisualizadorCarreras()
        {
            InitializeComponent();
            logicaprincipal.anadirCarreras();
            this.DataContext = logicaprincipal;
     
            


        }

        private void buttonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if(comboBoxCarrera.SelectedIndex>-1){
            AltaPuntoAvituallamiento alta = new AltaPuntoAvituallamiento(logicaprincipal,(Carrera)comboBoxCarrera.SelectedItem);
            alta.ShowDialog();
            }
        }

        private void df_Click(object sender, RoutedEventArgs e)
        {
            AltaCarrera altaCarrera = new AltaCarrera(logicaprincipal);
            altaCarrera.ShowDialog();

        }

        private void comboBoxCarrera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            carreraSeleccionada=(Carrera)comboBoxCarrera.SelectedItem;

            tablaAvituallamientos.DataContext = carreraSeleccionada;
            tablaMaterialEnElPunto.DataContext = avituallamientoSeleccionado;
        }



        private void tablaAvituallamientos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tablaAvituallamientos.SelectedIndex > -1)
            {
                avituallamientoSeleccionado = (Avituallamiento)tablaAvituallamientos.SelectedItem;
                tablaMaterialEnElPunto.DataContext = avituallamientoSeleccionado;

            }


        }

        private void tablaAvituallamientos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void buttonAltaMaterial_Click(object sender, RoutedEventArgs e)
        {
            AltaMateriales altaMaterial = new AltaMateriales(logicaprincipal);
            altaMaterial.ShowDialog();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tablaAvituallamientos.SelectedIndex >-1)
            {
                altaMaterialEnElPunto altapunto = new altaMaterialEnElPunto(avituallamientoSeleccionado, logicaprincipal);
                altapunto.ShowDialog();
            }
        }

        private void botonBorrarCarrera_Click(object sender, RoutedEventArgs e)
        {
            logicaprincipal.borrarCarrera(carreraSeleccionada); 
        }

        private void botonBorrarAvituallamiento_Click(object sender, RoutedEventArgs e)
        {
            carreraSeleccionada.listaAvituallamientos.Remove(avituallamientoSeleccionado);
        }

        private void botonEliminarMaterialPunto_Click(object sender, RoutedEventArgs e)
        {
            if (tablaMaterialEnElPunto.SelectedIndex > -1)
            {
                Material materialSeleccionado = (Material)tablaMaterialEnElPunto.SelectedItem;
                avituallamientoSeleccionado.listaMateriales.Remove(materialSeleccionado); 
                tablaMaterialEnElPunto.DataContext = avituallamientoSeleccionado;

            }
        }

        private void botonEliminarMaterial_Click(object sender, RoutedEventArgs e)
        {
            Material material = (Material)tablaMaterialDisponible1.SelectedItem;
            logicaprincipal.borrarMaterial(material);
        }

        private void botonModificar_Click(object sender, RoutedEventArgs e)
        {
            Carrera carrera;
           if( comboBoxCarrera.SelectedIndex!=-1){
               carrera=(Carrera)comboBoxCarrera.SelectedItem;
               AltaCarrera altaCarrera = new AltaCarrera(logicaprincipal,(Carrera) carrera.Clone(), comboBoxCarrera.SelectedIndex);
               altaCarrera.ShowDialog();
              
               this.DataContext = logicaprincipal;
           }
          
   
        }

        private void botonModificarAvituallamiento_Click(object sender, RoutedEventArgs e)
        {
           
            if (tablaAvituallamientos.SelectedIndex != -1)
            {
                AltaPuntoAvituallamiento alta = new AltaPuntoAvituallamiento(logicaprincipal,(Avituallamiento) avituallamientoSeleccionado.Clone(), tablaAvituallamientos.SelectedIndex,(Carrera)comboBoxCarrera.SelectedItem);
                 alta.ShowDialog();
            }
        }

        private void botonModificarMateriales_Click(object sender, RoutedEventArgs e)
        {
            Material material= (Material)tablaMaterialDisponible1.SelectedItem;
            AltaMateriales altaMaterial = new AltaMateriales(logicaprincipal,(Material) material.Clone(),tablaMaterialDisponible1.SelectedIndex);
            altaMaterial.ShowDialog();

        }

      

   
    }
}
