using System;
using System.Collections.Generic;

namespace TP3_Terminado
{
    // CLASE CLIENTE

    class Cliente
    {
        //ATRIBUTOS PERTENECIENTES

        public string Nombre { get; }
        public string Apellido { get; }

        // FUNCIÓN CLIENTE

        public Cliente (string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        // FUNCIÓN MUESTREO CLIENTE

        public void MuestreoClientes ()
        {
            Console.WriteLine ("Cliente: " + Nombre + ", " + Apellido);
        }
    }
}