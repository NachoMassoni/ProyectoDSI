using System;
using System.Collections.Generic;

namespace OpenShopCatalogo
{
    // CLASE PRINCIPAL

    public class Vendedor
    {
        // ATRIBUTOS PROPIOS

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public double Dni { get; set; }

        // FUNCIÓN PRINCIPAL

        public Vendedor (int id, string nombre, string apellido, string email, string usuario, string contraseña, double dni)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Usuario = usuario;
            Contraseña = contraseña;
            Dni = dni;
        }

        // CONSTRUCTOR

        public Vendedor ()
        {

        }
    }
}
