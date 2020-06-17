using System;
using System.Collections.Generic;

namespace TP3_Terminado
{
    // CLASE REGISTRO MATERIAL

    class RegMaterial
    {
        // ATRIBUTOS PERTENECIENTES

        public List <Material> mat { get; }

        // FUNCIÓN REGISTRO MATERIAL

        public RegMaterial ()
        {
            mat = new List <Material> ();
            
            mat.Add (new Material ("Estándar", 200.00m));
            mat.Add (new Material ("Premium", 250.00m));
        }

        // FUNCIÓN MUESTREO MATERIALES

        public void MuestreoMateriales ()
        {
            for (int i = 0; i < mat.Count; i++)
            {
                Console.Write ((i + 1).ToString () + ". ");
                
                mat [i].MuestreoMateriales (); 
            }
        }
    }
}