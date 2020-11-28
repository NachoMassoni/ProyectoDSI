using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenShopCatalogo
{
    // CLASE PRINCIPAL 

    public class Inicio
    {
        // ATRIBUTOS PROPIOS

        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        
        // FUNCIÓN PRINCIPAL

        public Inicio ()
        {

        }

        // FUNCIÓN VALIDACIÓN INICIO SESIÓN

        public static bool VerificarInicio (string usuario, string contraseña)
        {
            // ATRIBUTOS PROPIOS

            bool Ver = false;

            var inicio = new Inicio ();
            
            inicio.Usuario = "nacho.massoni";
            inicio.Contraseña = "1999nacho";

            if (usuario == inicio.Usuario && contraseña == inicio.Contraseña)
            {
                Ver = true;
            }

            return Ver;
        }

        // FUNCIÓN INICIO SESIÓN

        public static void InicioSesion ()
        {
            Console.WriteLine ("\n¡Bienvenido Nuevamente!");
            Console.WriteLine ();

            Console.WriteLine ("Nombre de Usuario: ");
            var Usuario = Console.ReadLine ();

            Console.WriteLine ("\nContraseña: ");
            var Contraseña = Console.ReadLine ();

            bool inic = VerificarInicio (Usuario, Contraseña);

            if (inic)
            {
                Console.Clear ();
                
                Console.WriteLine ("¡Inicio de Sesión satisfactorio!");
                Console.WriteLine ();

                GestorVendedor.NuevosVendedores ();
                GestorProducto.NuevosArticulos ();
                GestorCategoria.NuevasCategorias ();
                GestorTipoProducto.NuevosTiposProductos ();

                int Val = 1;

                do
                {
                    // ATRIBUTOS PROPIOS

                    int Accion = Program.MenuAcciones ();
                    int totalArticulos = 0;

                    switch (Accion)
                    {
                        case 1:

                            // ATRIBUTOS PROPIOS
                            
                            Producto articuloNuevo = new Producto ();

                            Program.NuevosDatos (articuloNuevo);
                            Program.NuevosTipoProducto (articuloNuevo);

                            GestorProducto.ListaArticulos.Add (new Producto (articuloNuevo.IdArticulo, articuloNuevo.Nombre, articuloNuevo.Marca, articuloNuevo.Precio, articuloNuevo.Descripcion, articuloNuevo.Stock, articuloNuevo.Imagen, articuloNuevo.TipoProducto));
                            GestorProducto.JSON.Add (new Producto (articuloNuevo.IdArticulo, articuloNuevo.Nombre, articuloNuevo.Marca, articuloNuevo.Precio, articuloNuevo.Descripcion, articuloNuevo.Stock));
                            
                            totalArticulos = GestorProducto.MostrarArticulos ();
                            
                            Console.WriteLine ("\nCantidad total de Artículos: " + totalArticulos);
                            
                            Val = Program.MenuPrincipal (Val);

                            break;

                        case 2:

                            Program.ModificarArticulo ();
                            
                            totalArticulos = GestorProducto.MostrarArticulos ();
                            
                            Console.WriteLine("\nCantidad total de Artículos: " + totalArticulos);
                            
                            Val = Program.MenuPrincipal (Val);
                            
                            break;

                        case 3:
                            
                            Program.EliminarArticulo ();
                            
                            Val = Program.MenuPrincipal (Val);
                            
                            break;

                        case 4:

                            totalArticulos = GestorProducto.MostrarArticulos ();
                            
                            Console.WriteLine ("\nCantidad total de Artículos: " + totalArticulos);
                            
                            Val = Program.MenuPrincipal (Val);
                            
                            break;

                        case 5:
                            
                            GestorProducto.CreacionJSON ();
                            
                            Val = Program.MenuPrincipal (Val);
                            
                            break;

                        default:
                            
                            break;
                    }

                } while (Val == 1);
            }

            else
            {
                Console.WriteLine ("\n¡Lo sentimos! Has ingresado erroneamente Usuario o Contraseña\n");
            }
        }
    }
}
