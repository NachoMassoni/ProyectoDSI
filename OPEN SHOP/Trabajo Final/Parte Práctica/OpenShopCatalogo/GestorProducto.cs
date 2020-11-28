using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OpenShopCatalogo
{
    // CLASE PRINCIPAL

    public class GestorProducto
    {
        // ATRIBUTOS PROPIOS

        public static Producto ComputadoraLenovo = new Producto ();
        public static Producto TecladoRedragon = new Producto ();
        public static Producto GuitarraGibson = new Producto ();
        public static Producto ViolinFender = new Producto ();
        public static Producto Arvejas = new Producto ();
        public static Producto PapasNoisette = new Producto ();
        public static Producto FernetBranca = new Producto ();
        public static Producto JugoTANG = new Producto ();

        public static List <Producto> ListaArticulos = new List <Producto> ();
        public static List <Producto> JSON = new List <Producto> ();

       

        // FUNCIÓN MUESTREO ARTÍCULOS

        public static int MostrarArticulos ()
        {
            // ATRIBUTOS PROPIOS
            
            int totalArticulos = 0;
            
            foreach (var articulo in ListaArticulos)
            {
                Console.WriteLine ("ID: " + articulo.IdArticulo + "\nNombre: " + articulo.Nombre + " - Marca: " + articulo.Marca + " - Precio: " + articulo.Precio + "$ - Descripción: " + articulo.Descripcion + " - Stock: " + articulo.Stock + " - Tipo de Artículo: " + articulo.TipoProducto.Nombre);
            
                Console.WriteLine ();

                totalArticulos++;
            }

            return totalArticulos;
        }

        // FUNCIÓN MUESTREO ID

        public static void MostrarArticulosID ()
        {
            var pos = 0;

            foreach (var articulo in ListaArticulos)
            {
                Console.WriteLine ("Posición: " + pos + " - ID: " + articulo.IdArticulo + "\nNombre: " + articulo.Nombre + " - Marca: " + articulo.Marca + " - Precio: " + articulo.Precio + "$ - Descripción: " + articulo.Descripcion + " - Stock: " + articulo.Stock + " - Tipo de Artículo: " + articulo.TipoProducto.Nombre);
                
                Console.WriteLine ();

                pos++;
            }
        }

        // FUNCIÓN DETECCIÓN ID

        public static void IDFinal ()
        {
            Console.WriteLine ("\nID en Uso:");
            
            Console.WriteLine ();

            foreach (var articulo in ListaArticulos)
            {
                Console.Write (" - " + articulo.IdArticulo + " - ");
            }

            Console.WriteLine ();
            Console.WriteLine ();

        }

        // FUNCIÓN ASIGNACIÓN ATRIBUTOS

        public static void NuevosArticulos ()
        {
            ComputadoraLenovo.IdArticulo = 0;
            ComputadoraLenovo.Nombre = "81WB00S6AR";
            ComputadoraLenovo.Marca = "Lenovo";
            ComputadoraLenovo.Precio = 59.999m;
            ComputadoraLenovo.Descripcion = "Computadora Lenovo IdeaPad 320S 4K";
            ComputadoraLenovo.Stock = 15;
            ComputadoraLenovo.Imagen = "computadora.jpg";
            ComputadoraLenovo.TipoProducto = GestorTipoProducto.Computadoras;

            TecladoRedragon.IdArticulo = 1;
            TecladoRedragon.Nombre = "KEY235BOARD";
            TecladoRedragon.Marca = "Redragon";
            TecladoRedragon.Precio = 10000m;
            TecladoRedragon.Descripcion = "Teclado Redragon Mecánico Retroiluminado";
            TecladoRedragon.Stock = 50;
            TecladoRedragon.Imagen = "teclado.jpg";
            TecladoRedragon.TipoProducto = GestorTipoProducto.Teclados;

            GuitarraGibson.IdArticulo = 2;
            GuitarraGibson.Nombre = "GUI145TAR";
            GuitarraGibson.Marca = "Gibson";
            GuitarraGibson.Precio = 50000m;
            GuitarraGibson.Descripcion = "Guitarra Eléctrica Gibson";
            GuitarraGibson.Stock = 20;
            GuitarraGibson.Imagen = "guitarra.jpg";
            GuitarraGibson.TipoProducto = GestorTipoProducto.Guitarras;

            ViolinFender.IdArticulo = 3;
            ViolinFender.Nombre = "FID365DLE";
            ViolinFender.Marca = "Fender";
            ViolinFender.Precio = 55000m;
            ViolinFender.Descripcion = "Violín Finder Medium";
            ViolinFender.Stock = 25;
            ViolinFender.Imagen = "violin.jpg";
            ViolinFender.TipoProducto = GestorTipoProducto.Violines;

            Arvejas.IdArticulo = 4;
            Arvejas.Nombre = "VET89CH";
            Arvejas.Marca = "Campagnola";
            Arvejas.Precio = 100;
            Arvejas.Descripcion = "Arvejas Campagnola 300gr";
            Arvejas.Stock = 120;
            Arvejas.Imagen = "arvejas.jpg";
            Arvejas.TipoProducto = GestorTipoProducto.Enlatados;

            PapasNoisette.IdArticulo = 5;
            PapasNoisette.Nombre = "POT456ATO";
            PapasNoisette.Marca = "McCain";
            PapasNoisette.Precio = 150;
            PapasNoisette.Descripcion = "Papas Noisette McCain 500gr";
            PapasNoisette.Stock = 150;
            PapasNoisette.Imagen = "papasnoisette.jpg";
            PapasNoisette.TipoProducto = GestorTipoProducto.Empaquetados;

            FernetBranca.IdArticulo = 6;
            FernetBranca.Nombre = "ALCO741HOL";
            FernetBranca.Marca = "Branca";
            FernetBranca.Precio = 300;
            FernetBranca.Descripcion = "Fernet Branca 2l";
            FernetBranca.Stock = 200;
            FernetBranca.Imagen = "fernet.jpg";
            FernetBranca.TipoProducto = GestorTipoProducto.Alcoholicas;

            JugoTANG.IdArticulo = 7;
            JugoTANG.Nombre = "JUI653CE";
            JugoTANG.Marca = "TANG";
            JugoTANG.Precio = 15;
            JugoTANG.Descripcion = "Jugo TANG sabor Naranja Mango";
            JugoTANG.Stock = 500;
            JugoTANG.Imagen = "jugo.jpg";
            JugoTANG.TipoProducto = GestorTipoProducto.NoAlcoholicas;

            // ENLISTADO ARTÍCULOS EN VENTA

            ListaArticulos.Add (new Producto (ComputadoraLenovo.IdArticulo, ComputadoraLenovo.Nombre, ComputadoraLenovo.Marca, ComputadoraLenovo.Precio, ComputadoraLenovo.Descripcion, ComputadoraLenovo.Stock, ComputadoraLenovo.Imagen, ComputadoraLenovo.TipoProducto));
            ListaArticulos.Add (new Producto (TecladoRedragon.IdArticulo, TecladoRedragon.Nombre, TecladoRedragon.Marca, TecladoRedragon.Precio, TecladoRedragon.Descripcion, TecladoRedragon.Stock, TecladoRedragon.Imagen, TecladoRedragon.TipoProducto));
            ListaArticulos.Add (new Producto (GuitarraGibson.IdArticulo, GuitarraGibson.Nombre, GuitarraGibson.Marca, GuitarraGibson.Precio, GuitarraGibson.Descripcion, GuitarraGibson.Stock, GuitarraGibson.Imagen, GuitarraGibson.TipoProducto));
            ListaArticulos.Add (new Producto (ViolinFender.IdArticulo, ViolinFender.Nombre, ViolinFender.Marca, ViolinFender.Precio, ViolinFender.Descripcion, ViolinFender.Stock, ViolinFender.Imagen, ViolinFender.TipoProducto));
            ListaArticulos.Add (new Producto (Arvejas.IdArticulo, Arvejas.Nombre, Arvejas.Marca, Arvejas.Precio, Arvejas.Descripcion, Arvejas.Stock, Arvejas.Imagen, Arvejas.TipoProducto));
            ListaArticulos.Add (new Producto (PapasNoisette.IdArticulo, PapasNoisette.Nombre, PapasNoisette.Marca, PapasNoisette.Precio, PapasNoisette.Descripcion, PapasNoisette.Stock, PapasNoisette.Imagen, PapasNoisette.TipoProducto));
            ListaArticulos.Add (new Producto (FernetBranca.IdArticulo, FernetBranca.Nombre, FernetBranca.Marca, FernetBranca.Precio, FernetBranca.Descripcion, FernetBranca.Stock, FernetBranca.Imagen, FernetBranca.TipoProducto));
            ListaArticulos.Add (new Producto (JugoTANG.IdArticulo, JugoTANG.Nombre, JugoTANG.Marca, JugoTANG.Precio, JugoTANG.Descripcion, JugoTANG.Stock, JugoTANG.Imagen, JugoTANG.TipoProducto));
        }

        // FUNCIÓN MODIFICACIÓN DE ARTÍCULO EN EXISTENCIA

        public static void ModificarSeleccion (int articuloID)
        {
            int bandera = 0;
            bool val = true;

            foreach (var articuloSeleccionID in ListaArticulos)
            {
                if (articuloSeleccionID.IdArticulo == articuloID)
                {
                    bandera = 1;
                    
                    // ASIGNACIÓN NOMBRE

                    do
                    {
                        Console.WriteLine("\nNombre del Artículo: [Max 15 Carácteres]");
                        
                        articuloSeleccionID.Nombre = Console.ReadLine();
                        
                        val = ValidarNombre (articuloSeleccionID.Nombre);

                    } while (!val);

                    Console.WriteLine ("\nNombre del Artículo: ");
                    articuloSeleccionID.Nombre = Console.ReadLine ();

                    // ASIGNACIÓN MARCA

                    Console.WriteLine ("\nMarca del Artículo: ");
                    articuloSeleccionID.Marca = Console.ReadLine ();
                    
                    // ASIGNACIÓN PRECIO

                    Console.WriteLine ("\nPrecio del Artículo (Valor): ");
                    articuloSeleccionID.Precio = decimal.Parse (Console.ReadLine ());

                    // ASIGNACIÓN DESCRIPCIÓN

                    Console.WriteLine ("\nDescripción breve del Artículo: ");
                    articuloSeleccionID.Descripcion = Console.ReadLine ();

                    // ASIGNACIÓN STOCK DISPONIBLE

                    Console.WriteLine ("\nStock del Artículo (Valor): ");
                    articuloSeleccionID.Stock = Int32.Parse (Console.ReadLine ());

                    // ASIGNACIÓN IMÁGEN

                    Console.WriteLine ("\nImágen del Artículo: ");
                    articuloSeleccionID.Imagen = Console.ReadLine ();
                }
            }

            if (bandera == 0)
            {
                Console.WriteLine ("\nID inexistente. Reinicie el programa");
                Console.WriteLine ();
            }
        }
        
        // FUNCIÓN VALIDACIÓN NOMBRE

        public static bool ValidarNombre (string nombre)
        {
            var val = false;

            if (nombre.Length <= 15)
            {
                val = true;
            }

            return val;
        }

        // FUNCIÓN ELIMINACIÓN DE ARTÍCULO EN EXISTENCIA

        public static void EliminarSeleccion (int articuloID)
        {   
            ListaArticulos.Remove (ListaArticulos [articuloID]);
          
            Console.WriteLine();
            
            Console.WriteLine ("¡Artículo eliminado exitosamente!");
            
            Console.WriteLine ();
        }
        
        // CREACIÓN ESTRUCTURA JSON

        public static void CreacionJSON ()
        {
            foreach (var articulo in ListaArticulos)
            {
                JSON.Add (new Producto (articulo.IdArticulo, articulo.Nombre, articulo.Marca, articulo.Precio, articulo.Descripcion, articulo.Stock, articulo.Imagen, articulo.TipoProducto));
            }
            
            // LÍNEAS DE CÓDIGO CREACIÓN DE ESTRUCTURA

            var EstructuraJSON = JsonConvert.SerializeObject (JSON, Formatting.Indented);
            
            Console.WriteLine (EstructuraJSON);
            
            File.WriteAllText ("JSON - Catálogo.txt", EstructuraJSON);
        }
    }
}