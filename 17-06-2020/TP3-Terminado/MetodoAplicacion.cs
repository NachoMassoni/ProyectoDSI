using System;

namespace TP3_Terminado
{
    // CLASE MÉTODO APLICACIÓN

    class MetodoAplicacion
    {
        // ATRIBUTOS PERTENECIENTES

        public double Espesor { get; }
        public string Descripcion { get; }
        public decimal valor { get; }
        public double rendimientoUnidad { get; }

        // FUNCIÓN MÉTODO APLICACIÓN

        public MetodoAplicacion (string descripcion, double espesor, decimal precio)
        {   
            Espesor = espesor;            
            rendimientoUnidad = espesor * 4.5 / 100;
            valor = precio;
            Descripcion = descripcion;
        }

        // FUNCIÓN MUESTREO MÉTODO APLICACIÓN

        public void MuestreoMetodo () 
        {
            Console.WriteLine ("Descripción: " + Descripcion + "- $" + valor + "\nEspesor: " + Espesor + " mm\n"); 
        }
    }
}