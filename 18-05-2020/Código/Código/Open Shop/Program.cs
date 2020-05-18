﻿using System;
using System.Collections.Generic;

namespace OpenShop
{
    // CLASE VENTAS
    class GestorVentas
    {
        // CREACIÓN OBJETO CARRITO

        static Carrito Carrito = new Carrito ();

        // CREACIÓN LISTA FORMAS DE PAGO
        
        static List <FormasPago> FormasPagos = new List <FormasPago> ();

        // FUNCIÓN PRINCIPAL

        static void Main (string [] args)
        {
            // AÑADIDO FORMAS DE PAGO DISPONIBLES

            FormasPagos.Add (new FormasPago ("Tarjeta - 6 cuotas sin Interés"));
            FormasPagos.Add (new FormasPago ("Débito"));

            // PEDIDO DE ARTÍCULOS POR CLIENTE
            
            while (true)
            {
                // LLAMADO A FUNCIÓN COMPRAR

                var finalizado = Comprar ();

                if (finalizado)
                {
                    break;
                }
            }

            // LLAMADO A FUNCIÓN PAGO

            AgregarPago ();

            System.Console.WriteLine ("Gracias por su Compra");
        }

        // FUNCIÓN COMPRAR

        static public bool Comprar ()
        {
            // MUESTREO ARTÍCULOS
        
            RegistroProductos.MostrarProductos ();

            System.Console.WriteLine ();
            System.Console.WriteLine ("Seleccione un Artículo");

            // CREACIÓN VARIABLE OPCIÓN ARTÍCULO ELEGIDO

            var opcionProducto = System.Console.ReadLine ();
            
            var producto = RegistroProductos.Productos [int.Parse (opcionProducto) - 1];

            System.Console.WriteLine ();
            System.Console.WriteLine ("Cantidad de Artículos que desea comprar");

            // CREACIÓN VARIABLE OPCIÓN CANTIDAD ELEGIDA

            var opcionCantidad = System.Console.ReadLine();

            int cantidadElegida = (int.Parse (opcionCantidad));

            // AGREGADO AL CARRO DE ARTÍCULOS Y CANTIDAD

            Carrito.Agregar (producto, cantidadElegida);
            
            // MUESTREO CARRITO

            Carrito.MostrarCarrito ();

            System.Console.WriteLine ("");
            System.Console.WriteLine ("1 si desea seguir comprando / 2 si desea abonar Artículos de Carrito");
            
            // CREACIÓN VARIABLE OPCIÓN ELEGIDA
            
            var opcionSeguir = System.Console.ReadLine ();

            if (int.Parse (opcionSeguir) == 1)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        // FUNCIÓN PAGO
        
        static public void AgregarPago ()
        {
            System.Console.WriteLine ();
            System.Console.WriteLine ("Formas de Pago");
            
            int pos = 1;
            
            foreach (var pago in FormasPagos)
            {
                System.Console.WriteLine (pos + "- " + pago.Tipo);
                
                pos++;
            }

            System.Console.WriteLine ();
            System.Console.WriteLine ("Seleccione Forma de Pago - Digite 1 ó 2");
            
            // CREACIÓN VARIABLE OPCIOÓN ELEGIDA

            var seleccion2 = System.Console.ReadLine ();

            var formasPagos = FormasPagos [int.Parse (seleccion2) - 1];
            
            System.Console.WriteLine ("Forma de Pago elegida " + formasPagos.Tipo);
            System.Console.WriteLine ("");
        }
    }

    // CLASE PAGO
    
    class FormasPago
    {
        public string Tipo {get; set;}

        // TIPO FORMAS DE PAGO
        public FormasPago (string tipo)
        {
            Tipo = tipo;
        }
    }
    
    // CLASE CARRITO 
    
    class Carrito
    {
        // CREACIÓN LISTA PRODUCTOS EN CARRITO
        private List <ProductoEnCarrito> Productos = new List <ProductoEnCarrito> ();

        // FUNCIÓN AGREGADO A CARRITO
        public void Agregar (Producto producto, int cantidad)
        {
            var prodEnCarrito = new ProductoEnCarrito ();
            
            prodEnCarrito.Producto = producto;
            prodEnCarrito.Cantidad = cantidad;

            Productos.Add (prodEnCarrito);
        }

        // FUNCIÓN MUESTREO CARRITO
        public void MostrarCarrito ()
        {
            System.Console.WriteLine ("");
            System.Console.WriteLine ("Tu Carrito ");

            decimal totalCarrito = 0;
            
            foreach (var productoEnCarrito in Productos)
            {
                var cantidad = productoEnCarrito.Cantidad;
                var precio = productoEnCarrito.Producto.Precio;
                var nombre = productoEnCarrito.Producto.Nombre;
                
                System.Console.WriteLine (cantidad + "x " + nombre + " $" + cantidad * precio);

                totalCarrito = totalCarrito + cantidad * precio;
            }

            System.Console.WriteLine ("Total: $" + totalCarrito);
        }
    }

    // CLASE CARRITO CON PRODUCTOS
    
    class ProductoEnCarrito
    {
        public Producto Producto {get; set;}

        public int Cantidad {get; set;}
    }

    // CLASE PRODUCTO
    
    class Producto
    {
        public string Nombre {get; set;}
        public decimal Precio {get; set;}
        public string Marca {get; set;}

        // FUNCIÓN CONSTRUCTOR
        public Producto (string nombre, decimal precio, string marca)
        {
            Nombre = nombre;
            Precio = precio;
            Marca = marca;
        }
    }
    
    // CLASE REGISTRO DE PRODUCTOS
    
    class RegistroProductos
    {
        // CREACIÓN LISTA PRODUCTOS DISPONIBLES
        public static List <Producto> Productos = new List <Producto> ();
        
        // FUNCIÓN CONSTRUCTOR
       
        static RegistroProductos()
        {
            // ARTÍCULOS EN STOCK

            Productos.Add (new Producto ("Cafetera", 3000, "Philips"));
            Productos.Add (new Producto ("Celular", 249999.99m, "Apple"));
            Productos.Add (new Producto ("Televisor", 22000, "Sony"));
            Productos.Add (new Producto ("Ojotas", 700, "Havaianas"));
            Productos.Add (new Producto ("Teclado", 6500.99m, "Razer"));
        }

        // FUNCIÓN MUESTREO PRODUCTOS

        static public void MostrarProductos ()
        {
            System.Console.WriteLine ();
            System.Console.WriteLine ("OPEN SHOP");
            System.Console.WriteLine ("Listado de Productos");
            
            int pos = 1;
            
            foreach (var producto in Productos)
            {
                System.Console.WriteLine (pos + "-" + producto.Nombre + " " + producto.Marca + " $" + producto.Precio);
                
                pos++;
            }
        }
    }
}
