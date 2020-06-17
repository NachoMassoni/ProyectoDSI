using System;
using System.Collections.Generic;

namespace TP3_Terminado
{
    // CLASE GESTIÓN PEDIDOS

    class GestionPedidos
    {
        // ATRIBUTOS PERTENECIENTES
        
        static RegMetodoAplicacion RegMetodoAplicacion = new RegMetodoAplicacion ();
        static List <Pedido> RegPedidos = new List <Pedido> ();
        static RegMaterial RegMaterial = new RegMaterial ();
        static RegClientes RegClientes = new RegClientes ();

        // FUNCIÓN PRINCIPAL
        
        static void Main (string [] args)
        {
            while (true)
            {
                var finalizado = Operadora ();

                if (finalizado)
                {
                    break;
                }
            }
        }

        // FUNCIÓN OPERADORA
        
        static bool Operadora ()
        {
            Console.WriteLine("\n¡Bienvenido nuevamente! ¿Qué desea realizar? \n");
            Console.WriteLine("---------- MENÚ ---------- \n");
            Console.WriteLine("1. Registro de Pedido");
           
            int opcionElegida = int.Parse (Console.ReadLine ());
            
            Console.Clear ();
 
            if (opcionElegida == 1) 
            {
                RegistroPedido();
            }

            else  
            {
                Console.WriteLine ("Opción registrada Inválida \n");
            }
            
            // ELECCIÓN OPERANDO
            
            Console.WriteLine ("¿Desea continuar Operando? \n\n1. Sí \n2. No \n");
            
            var opcionAfirmativa = int.Parse (Console.ReadLine ());

            Console.Clear ();
            
            if (opcionAfirmativa == 1) 
            {
                return false;
            }

            else 
            {
                return true;
            }
        }

        // FUNCIÓN REGISTRO PEDIDO

        static void RegistroPedido ()
        {
            // ELECCIÓN CLIENTE

            Console.WriteLine ("¿Qué Cliente desea elegir? \n");

            RegClientes.MuestreoClientes ();
            
            var cliIndicador = int.Parse (Console.ReadLine ()) - 1;
            var cliente = RegClientes.clientes [cliIndicador];
            
            Console.Clear ();

            // ELECCIÓN MÉTODO

            Console.WriteLine ("¿Qué Método de aplicación desea? \n");

            RegMetodoAplicacion.MuestreoMetodo ();

            var metIndicador = int.Parse (Console.ReadLine ()) - 1;

            MetodoAplicacion metodoAplicacion = RegMetodoAplicacion.MetAplicacion [metIndicador];

            Console.Clear ();

            // ELECCIÓN MATERIAL

            Console.WriteLine ("¿Que Material desea aplicar? \n");
            
            RegMaterial.MuestreoMateriales ();
            
            var matIndicador = int.Parse (Console.ReadLine ()) - 1;

            Material material = RegMaterial.mat [matIndicador];

            Console.Clear ();

            // ELECCIÓN ÁREA

            Console.WriteLine ("¿Qué Área desea cubrir? En m2 \n");
           
            var superficie = double.Parse (Console.ReadLine ());
            
            Console.Clear ();

            // ELECCIÓN DIRECCIÓN

            Console.WriteLine ("Dirección de Obra \n");

            var direccion = Console.ReadLine ();

            Console.Clear();

            // ARMADO PEDIDO

            var nuevoPedido = new Pedido (material, superficie, direccion, cliente, metodoAplicacion);
            
            nuevoPedido.MuestreoPedido ();

            // ELECCIÓN GUARDADO

            Console.WriteLine ("\nGuardado de Pedido \n\n1.Sí \n2.No\n");
            
            var guardado = int.Parse (Console.ReadLine ());
            
            Console.Clear ();

            if (guardado == 1)
            {
                Console.WriteLine ("¡Pedido guardado exitosamente! \n");
                
                RegPedidos.Add (nuevoPedido);
            }
        }
    }
}

