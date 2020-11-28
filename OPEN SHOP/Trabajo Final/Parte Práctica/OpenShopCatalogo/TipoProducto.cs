using System;
using System.Collections.Generic;

namespace OpenShopCatalogo
{
    // CLASE PRINCIPAL

    public class TipoProducto
    {
        // ATRIBUTOS PROPIOS

        public int Id { get; set; }
        public string Nombre { get; set; }
        public Categoria Categoria { get; set; }

        // FUNCIÓN PRINCIPAL

        public TipoProducto (int id, string nombre, Categoria categoria)
        {
            Id = id;
            Nombre = nombre;
            Categoria = categoria;
        }

        // CONSTRUCTOR

        public TipoProducto ()
        {

        }
    }
}