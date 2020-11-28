using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;

namespace OpenShopCatalogo
{
    // CLASE PRINCIPAL

    public class Program
    {
        // FUNCIÓN PRINCIPAL

        static void Main ()
        {
            // FUNCIÓN INICIO SESIÓN

            Inicio.InicioSesion();
        }

        // FUNCIÓN MENÚ PRINCIPAL

        public static int MenuAcciones ()
        {
            int Opcion = 0;
            
            int Accion;
            
            // ACCIONES A REALIZAR EN PROYECTO

            do
            {    
                Console.WriteLine ();
                
                Console.WriteLine ("[1]- Agregado Nuevo Artículo");
                Console.WriteLine ("[2]- Modificación Artículo");
                Console.WriteLine ("[3]- Eliminación Artículo");
                Console.WriteLine ("[4]- Listado Completo Artículo");
                Console.WriteLine ("[5]- Estructura JSON");
                
                Console.WriteLine ();

                // ELECCIÓN ACCIONES A REALIZAR

                Accion = Int32.Parse (Console.ReadLine ());
                
                if (Accion > 0 && Accion < 6)
                {
                    Opcion = 1;
                }
                
                else
                {
                    Console.WriteLine ();
                    
                    Console.WriteLine ("\n¡Lo sentimos! Has ingresado una acción inválida. Prueba nuevamente: ");
                    
                    Console.WriteLine ();
                }
            
            } while (Opcion == 0);

            return Accion;
        }

        // FUNCIÓN ELECCIÓN CONTINUIDAD
        
        public static int MenuPrincipal (int Opcion)
        {
            Console.WriteLine ();
            
            Console.WriteLine ("¿Desea seguir trabajando?");
            
            Console.WriteLine ();
            
            Console.WriteLine (" SI [1] - NO [0]");
            
            Console.WriteLine ();
            
            var Deseo = Int32.Parse (Console.ReadLine());
            
            if (Deseo == 0)
            {
                Opcion = 0;
            }

            return Opcion;
        }

        // FUNCIÓN INGRESO NUEVOS DATOS

        public static void NuevosDatos (Producto nuevoArticulo)
        {
            Console.WriteLine ("\nID (Valor): ");

            GestorProducto.IDFinal ();
            
            // ASIGNACIÓN ID

            nuevoArticulo.IdArticulo = Int32.Parse (Console.ReadLine ());

            // FUNCIÓN ENLISTADO ARTÍCULOS

            foreach (var articulos in GestorProducto.ListaArticulos)
            {
                do
                {
                    foreach (var productoIdSeleccionado in GestorProducto.ListaArticulos)
                    {
                        if (nuevoArticulo.IdArticulo == productoIdSeleccionado.IdArticulo)
                        {
                            Console.WriteLine ("\n¡Lo sentimos! ID no válido. Seleccione un ID nuevamente: \n");
                            
                            nuevoArticulo.IdArticulo = Int32.Parse (Console.ReadLine ());
                        }

                    }

                } while (nuevoArticulo.IdArticulo == articulos.IdArticulo);
                
            }

            // ASIGNACIÓN NOMBRE

            Console.WriteLine ("\nNombre del Artículo: ");
            nuevoArticulo.Nombre = Console.ReadLine ();

            // ASIGNACIÓN MARCA

            Console.WriteLine ("\nMarca del Artículo: ");
            nuevoArticulo.Marca = Console.ReadLine ();

            // ASIGNACIÓN PRECIO
            
            Console.WriteLine ("\nPrecio del Artículo (Valor): ");
            nuevoArticulo.Precio = decimal.Parse (Console.ReadLine ());

            // ASIGNACIÓN DESCRIPCIÓN
            
            Console.WriteLine ("\nDescripción breve del Artículo: ");
            nuevoArticulo.Descripcion = Console.ReadLine ();

            // ASIGNACIÓN STOCK DISPONIBLE
            
            Console.WriteLine ("\nStock disponible del Artículo (Valor): ");
            nuevoArticulo.Stock = Int32.Parse (Console.ReadLine ());

            // ASIGNACIÓN IMÁGEN
            
            Console.WriteLine ("\nImágen del Artículo: ");
            nuevoArticulo.Imagen = Console.ReadLine ();
        }

        // FUNCIÓN INGRESO NUEVOS TIPO PRODUCTO

        public static void NuevosTipoProducto (Producto nuevoArticulo)
        {
            Console.WriteLine ();
            
            // MUESTREO TIPOS PRODUCTOS

            GestorTipoProducto.MostrarTiposProductos ();
            
            Console.WriteLine ();
            
            Console.WriteLine ("Asigne Tipo de Producto (Según ID): ");
            
            Console.WriteLine ();

            var EleccionTP = Int32.Parse (Console.ReadLine ());
            
            // ASIGNACIÓN A TIPO PRODUCTO ESPECÍFICO

            switch (EleccionTP)
            {
                case 0:

                    nuevoArticulo.TipoProducto = GestorTipoProducto.Computadoras;
        
                    break;

                case 1:

                    nuevoArticulo.TipoProducto = GestorTipoProducto.Teclados;

                    break;
                
                case 2:

                    nuevoArticulo.TipoProducto = GestorTipoProducto.Guitarras;

                    break;
                
                case 3:

                    nuevoArticulo.TipoProducto = GestorTipoProducto.Violines;

                    break;
                
                case 4:

                    nuevoArticulo.TipoProducto = GestorTipoProducto.Enlatados;

                    break;
                
                case 5:

                    nuevoArticulo.TipoProducto = GestorTipoProducto.Empaquetados;

                    break;
                
                case 6:

                    nuevoArticulo.TipoProducto = GestorTipoProducto.Alcoholicas;

                    break;
                
                case 7:

                    nuevoArticulo.TipoProducto = GestorTipoProducto.NoAlcoholicas;

                    break;

                default:

                    Console.WriteLine ("\nID Tipo Producto inexistente. Vuelva a intentarlo");
                    
                    NuevosTipoProducto (nuevoArticulo);

                    break;
            }
        }

        // FUNCIÓN MODIFICACIÓN DE ARTÍCULO EN EXISTENCIA

        public static void ModificarArticulo ()
        {
            // PRE MUESTREO

            int totalArticulos = GestorProducto.MostrarArticulos ();
            
            Console.WriteLine("\nCantidad total de Artículos: " + totalArticulos);

            Console.WriteLine ();
            
            Console.WriteLine ("\n¿Qué Artículo desea modificar?");
            
            Console.WriteLine ("\nElija ID: ");
            
            int articuloSeleccionado = Int32.Parse (Console.ReadLine ());

            // MODIFICACIÓN DE ARTÍCULO SELECCIONADO

            GestorProducto.ModificarSeleccion (articuloSeleccionado);
        }
        
        // FUNCIÓN ELIMINACIÓN DE ARTÍCULO EN EXISTENCIA

        public static void EliminarArticulo ()
        {
            // PRE MUESTREO ID

            GestorProducto.MostrarArticulosID ();

            Console.WriteLine ();

            Console.WriteLine ("¿Que Artículo desea eliminar?\n");
            
            Console.WriteLine ("Elija Posición (ID): \n");

            int articuloSeleccionado = Int32.Parse (Console.ReadLine ());
            
            // ELIMINACIÓN DE ARTÍCULO SELECCIONADO

            GestorProducto.EliminarSeleccion (articuloSeleccionado);
            
            // MUESTREO ARTÍCULOS ACTUALIZADOS

            GestorProducto.MostrarArticulosID ();
        }
    }
}
