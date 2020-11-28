using System;
using System.Collections.Generic;

namespace OpenShopCatalogo
{
    // CLASE PRINCIPAL

    public class Producto
    {
        // ATRIBUTOS PROPIOS
        
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public TipoProducto TipoProducto { get; set; }

        
        // FUNCIÓN PRINCIPAL

        public Producto (int idArticulo, string nombre, string marca, decimal precio, string descripcion, int stock, string imagen, TipoProducto tipoProducto )
        {
            IdArticulo = idArticulo;
            Nombre = nombre;
            Marca = marca;
            Precio = precio;
            Descripcion = descripcion;
            Stock = stock;
            Imagen = imagen;
            TipoProducto = tipoProducto;
        }
        
        // FUNCIÓN PRINCIPAL

        public Producto (int idArticulo, string nombre, string marca, decimal precio, string descripcion, int stock)
        {
            IdArticulo = idArticulo;
            Nombre = nombre;
            Marca = marca;
            Precio = precio;
            Descripcion = descripcion;
            Stock = stock;
        }

        // CONSTRUCTOR

        public Producto ()
        {

        }
    }
}