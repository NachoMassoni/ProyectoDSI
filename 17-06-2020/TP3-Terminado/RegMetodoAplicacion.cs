using System;
using System.Collections.Generic;

namespace TP3_Terminado
{
    // CLASE REGISTRO MÉTODOS DE APLICACIÓN

    class RegMetodoAplicacion
    {
        // ATRIBUTOS PERTENECIENTES

        public List<MetodoAplicacion> MetAplicacion { get; }
        
        // FUNCIÓN REGISTRO MÉTODOS DE APLICACIÓN
        
        public RegMetodoAplicacion()
        {
            MetAplicacion = new List <MetodoAplicacion> ();

            MetAplicacion.Add (new MetodoAplicacion ("Aplicado en Pared", 50, 53.60m));
            MetAplicacion.Add (new MetodoAplicacion ("Aplicado en Pared", 70, 87.00m));
            MetAplicacion.Add (new MetodoAplicacion ("Aplicado en Pared", 100, 117.49m));
            MetAplicacion.Add (new MetodoAplicacion ("Aplicado en Pared", 120, 128.48m));
            MetAplicacion.Add (new MetodoAplicacion ("Aplicado en Pared", 160, 143.05m));
            MetAplicacion.Add (new MetodoAplicacion ("Aplicado en Pared", 200, 180.19m));
        }

        // FUNCIÓN MUESTREO MÉTODOS DE APLICACIÓN
        
        public void MuestreoMetodo ()
        {
            for (int i = 0; i < MetAplicacion.Count; i++)
            {
                Console.Write ((i + 1).ToString () + ". ");
               
                MetAplicacion [i].MuestreoMetodo ();
            }
        }
    }
}