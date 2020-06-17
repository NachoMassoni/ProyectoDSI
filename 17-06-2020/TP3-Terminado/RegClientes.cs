using System;
using System.Collections.Generic;

namespace TP3_Terminado
{
    // CLASE REGISTRO CLIENTES

    class RegClientes
    {
        // ATRIBUTOS PERTENECIENTES

        public List <Cliente> clientes { get; set; }

        public RegClientes ()
        {
            clientes = new List <Cliente> ();

            clientes.Add (new Cliente ("Massoni", " Ignacio"));
            clientes.Add (new Cliente ("Pioli"," Pablo")); 
            clientes.Add (new Cliente ("Ferreyra"," Juan Pablo")); 
        }

        // FUNCIÓN MUESTREO CLIENTES

        public void MuestreoClientes ()
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                Console.Write ((i + 1).ToString () + ". " );
                
                clientes [i].MuestreoClientes (); 
            }
        } 
    }
}