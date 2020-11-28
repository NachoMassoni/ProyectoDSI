using System;
using System.Collections.Generic;

namespace OpenShopCatalogo
{
    // CLASE PRINCIPAL

    public class GestorVendedor
    {
        //ATRIBUTOS PROPIOS

        public static Vendedor Vendedor1 = new Vendedor ();

        public static List <Vendedor> ListaVendedores = new List <Vendedor> ();

        // FUNCIÓN ASIGNACIÓN DATOS DEL VENDEDOR

        public static void NuevosVendedores ()
        {
            Vendedor1.Id = 0;
            Vendedor1.Nombre = "Ignacio";
            Vendedor1.Apellido = "Massoni";
            Vendedor1.Email = "nachomassoni@gmail.com";
            Vendedor1.Usuario = "nacho.massoni";
            Vendedor1.Contraseña = "1999nacho";
            Vendedor1.Dni = 42161429;

            ListaVendedores.Add (new Vendedor (Vendedor1.Id, Vendedor1.Nombre, Vendedor1.Apellido, Vendedor1.Email, Vendedor1.Usuario, Vendedor1.Contraseña, Vendedor1.Dni));
        }
    }
}
