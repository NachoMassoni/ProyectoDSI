using System;
using System.Collections.Generic;

namespace OpenShopCatalogo
{
    // CLASE PRINCIPAL

    public class GestorTipoProducto
    {
        // ATRIBUTOS PROPIOS

        public static TipoProducto Computadoras = new TipoProducto ();
        public static TipoProducto Teclados = new TipoProducto ();
        public static TipoProducto Guitarras = new TipoProducto ();
        public static TipoProducto Violines = new TipoProducto ();
        public static TipoProducto Enlatados = new TipoProducto ();
        public static TipoProducto Empaquetados = new TipoProducto ();
        public static TipoProducto Alcoholicas = new TipoProducto ();
        public static TipoProducto NoAlcoholicas = new TipoProducto ();

        public static List <TipoProducto> ListaTipoProductos = new List <TipoProducto> ();

        // FUNCIÓN ASIGNACIÓN TIPO PRODUCTO

        public static void NuevosTiposProductos ()
        {
            Computadoras.Id = 0;
            Computadoras.Nombre = "Computadoras";
            Computadoras.Categoria = GestorCategoria.Tecnologia;

            Teclados.Id = 1;
            Teclados.Nombre = "Teclados";
            Teclados.Categoria = GestorCategoria.Tecnologia;

            Guitarras.Id = 2;
            Guitarras.Nombre = "Guitarras";
            Guitarras.Categoria = GestorCategoria.Musica;

            Violines.Id = 3;
            Violines.Nombre = "Violines";
            Violines.Categoria = GestorCategoria.Musica;

            Enlatados.Id = 4;
            Enlatados.Nombre = "Enlatados";
            Enlatados.Categoria = GestorCategoria.Bebidas;
                 
            Empaquetados.Id = 5;
            Empaquetados.Nombre = "Empaquetados";
            Empaquetados.Categoria = GestorCategoria.Bebidas;

            Alcoholicas.Id = 6;
            Alcoholicas.Nombre = "Bebidas Alcoholicas";
            Alcoholicas.Categoria = GestorCategoria.Alimentos;

            NoAlcoholicas.Id = 7;
            NoAlcoholicas.Nombre = "Bebidas No Alcoholicas";
            NoAlcoholicas.Categoria = GestorCategoria.Alimentos;

            // ENLISTADO TIPOS DE PRODUCTO

            ListaTipoProductos.Add (new TipoProducto (Computadoras.Id, Computadoras.Nombre, Computadoras.Categoria));
            ListaTipoProductos.Add (new TipoProducto (Teclados.Id, Teclados.Nombre, Teclados.Categoria));
            ListaTipoProductos.Add (new TipoProducto (Guitarras.Id, Guitarras.Nombre, Guitarras.Categoria));
            ListaTipoProductos.Add (new TipoProducto (Violines.Id, Violines.Nombre, Violines.Categoria));
            ListaTipoProductos.Add (new TipoProducto (Enlatados.Id, Enlatados.Nombre, Enlatados.Categoria));
            ListaTipoProductos.Add (new TipoProducto (Empaquetados.Id, Empaquetados.Nombre, Empaquetados.Categoria));
            ListaTipoProductos.Add (new TipoProducto (Alcoholicas.Id, Alcoholicas.Nombre, Alcoholicas.Categoria));
            ListaTipoProductos.Add (new TipoProducto (NoAlcoholicas.Id, NoAlcoholicas.Nombre, NoAlcoholicas.Categoria));
        }
        
        // FUNCIÓN MUESTREO TIPO PRODUCTO

        public static void MostrarTiposProductos ()
        {
            Console.WriteLine ();
            
            foreach (var tiposProductos in ListaTipoProductos)
            {
                Console.WriteLine ("ID: " + tiposProductos.Id + " - Nombre: " + tiposProductos.Nombre);
                Console.WriteLine ();
            }
        }
    }
}