using System;

namespace TP3_Terminado
{
    //CLASE MATERIAL

     class Material
    {
        // ATRIBUTOS PERTENECIENTES

        public string denominacion { get; }
        public decimal precioUnidad { get; }
        
        // FUNCIÓN MATERIAL

        public Material (string nombre, decimal precioBolsa)
        {
            denominacion = nombre;
            precioUnidad = precioBolsa;
        }

        // FUNCIÓN MUESTREO MATERIALES

        public void MuestreoMateriales () 
        {
            Console.WriteLine ("Material: " + denominacion + "- $" + precioUnidad ); 
        }
    }
}

