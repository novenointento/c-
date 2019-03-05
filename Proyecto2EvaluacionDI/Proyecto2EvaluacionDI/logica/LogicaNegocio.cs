using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2EvaluacionDI.logica
{
    public class LogicaNegocio
    {
        public ObservableCollection<Carrera> listaCarreras { get; set;}
        public ObservableCollection<Material> listaMaterialesDisponibles { get; set; }
        
        Carrera carrera1 = new Carrera("Run Aviles");
        Carrera carrera2 = new Carrera("Oviedo corre");
        Carrera carrera3 = new Carrera("Gijon a pata");
        
        Avituallamiento avi1 = new Avituallamiento("punto1", 12, "pepe", 23456);
        Avituallamiento avi2 = new Avituallamiento("punto2", 12, "juan", 23456);
        Avituallamiento avi3 = new Avituallamiento("punto3", 12, "luis", 23456);
        Avituallamiento avi4 = new Avituallamiento("punto4", 12, "manuel", 23456);
        Avituallamiento avi5 = new Avituallamiento("punto5", 12, "paco", 23456);
        Avituallamiento avi6 = new Avituallamiento("punto6", 12, "pedro", 23456);
        Material mat1 = new Material("vendas",10,"Medicamento",25);
        Material mat2 = new Material("agua", 40,"Bebida",1);
        Material mat3 = new Material("esponjas", 30,"Medicamento",2);
        Material mat4 = new Material("barrita", 10,"Comida",1);
        Material mat5 = new Material("Pomada", 4, "Medicamento", 15);
        Material mat6 = new Material("Cocacola", 23, "Bebida", 21);
        Material mat7 = new Material("Tiritas", 56, "Medicamento", 2);
        Material mat8 = new Material("Peras", 8, "Comida", 1);






        public void anadirCarreras()
        {
            avi1.anadirMaterial(mat1);
            avi1.anadirMaterial(mat2);
            avi1.anadirMaterial(mat3);
            avi2.anadirMaterial(mat4);
            carrera1.altaPunto(avi1);
            carrera1.altaPunto(avi2);
            carrera2.altaPunto(avi3);
            carrera2.altaPunto(avi4);
            carrera1.altaPunto(avi5);
            carrera3.altaPunto(avi6);
            listaCarreras = new ObservableCollection<Carrera>();
            listaMaterialesDisponibles = new ObservableCollection<Material>();
            listaCarreras.Add(carrera1);
            listaCarreras.Add(carrera2);
            listaCarreras.Add(carrera3);
            listaMaterialesDisponibles.Add(mat5);
            listaMaterialesDisponibles.Add(mat6);
            listaMaterialesDisponibles.Add(mat7);
            listaMaterialesDisponibles.Add(mat8);

            

        }

        public void anadirCarrera(Carrera carrera) {
            listaCarreras.Add(carrera);
        
        }
        public void modificarCarrera(Carrera carrera, int posicion) {

            listaCarreras[posicion] = carrera;
        
        }
        public void borrarCarrera(Carrera carrera) {
            listaCarreras.Remove(carrera);
        
        
        }
        public void anadirMaterial(Material material) {
            listaMaterialesDisponibles.Add(material);

        
        }


        public void modificarMaterial(Material material,int posicion)
        {
            listaMaterialesDisponibles[posicion] = material;
        
        
        }
        public void borrarMaterial(Material material)
        {
            listaMaterialesDisponibles.Remove(material);
        
        }


    }
}
