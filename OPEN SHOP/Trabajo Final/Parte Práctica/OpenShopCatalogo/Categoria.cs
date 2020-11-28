using System;
using System.Collections.Generic;

namespace OpenShopCatalogo
{
    // CLASE PRINCIPAL
    
    public class Categoria
    {
        // ATRIBUTOS PROPIOS

        public int Id { get; set; }
        public string Nombre { get; set; }

        // FUNCIÓN PRINCIPAL

        public Categoria (int id, string nombre)
        {
            // ASIGNACIÓN ATRIBUTOS

            Id = id;
            Nombre = nombre;
        }

        // CONSTRUCTOR

        public Categoria ()
        {

        }
    }
}