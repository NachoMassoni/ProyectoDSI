using System;
using System.Collections.Generic;

namespace OpenShopCatalogo
{
    // CLASE PRINCIPAL

    public class GestorCategoria
    {
        // ATRIBUTOS PROPIOS

        public static Categoria Tecnologia = new Categoria ();
        public static Categoria Musica = new Categoria ();
        public static Categoria Alimentos = new Categoria ();
        public static Categoria Bebidas = new Categoria ();

        public static List <Categoria> ListaCategorias = new List <Categoria> ();

        // FUNCIÓN ASIGNACIÓN CATEGORÍA

        public static void NuevasCategorias ()
        {
            Tecnologia.Id = 0;
            Tecnologia.Nombre = "Tecnologia";
            
            Musica.Id = 1;
            Musica.Nombre = "Musica";
        
            Alimentos.Id = 2;
            Alimentos.Nombre = "Alimentos";

            Bebidas.Id = 3;
            Bebidas.Nombre = "Bebidas";

            // FUNCIÓN ENLISTADO CATEGORÍAS

            ListaCategorias.Add (new Categoria (Tecnologia.Id, Tecnologia.Nombre));
            ListaCategorias.Add (new Categoria (Musica.Id, Musica.Nombre));
            ListaCategorias.Add (new Categoria (Alimentos.Id, Alimentos.Nombre));
            ListaCategorias.Add (new Categoria (Bebidas.Id, Bebidas.Nombre));
        }
    }
}
