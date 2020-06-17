using System;

namespace TP3_Terminado
{
    // CLASE COTIZACIÓN

    class Cotizacion
    {
        // ATRIBUTOS PERTENECIENTES

        DateTime fechaInicio { get; set; }
        DateTime fechaVenc { get; set; }
        decimal valor { get; set; }

        // FUNCIÓN COTIZACIÓN

        public Cotizacion (decimal precio)
        {
            valor=precio;
            fechaInicio = DateTime.Now; 
            fechaVenc = DateTime.Now.AddDays (30); 
        }

        // FUNCIÓN MUESTREO COTIZACIÓN

        public void MuestreoCotizacion ()
        {
            Console.WriteLine ("Valor: $" + valor + "\nFecha Inicio: -" + fechaInicio + "\nFecha Vencimiento: -" + fechaVenc); 
        }
    }
}

