using System;
using System.Collections.Generic;

namespace TP3_Terminado
{
    // CLASE PEDIDO

    class Pedido
    {
        // ATRIBUTOS PERTENECIENTES

        public string DirObra { get; }
        public double Superficie { get; }
        public int CantBolsas{get; }
        public List <Cotizacion> Cotizaciones { get; }
        public MetodoAplicacion MetAplicacion { get; }
        public Cliente Cliente { get; }
        public Material Material { get; }
        
        // FUNCIÓN PEDIDO

        public Pedido (Material material, double superficie, string direccionObra, Cliente cliente, MetodoAplicacion metodoAplicacion)
        {
            Cliente = cliente;
            MetAplicacion = metodoAplicacion;
            Material = material;
            Cotizaciones = new List<Cotizacion>();
            Superficie = superficie;
            DirObra = direccionObra;
            CantBolsas = (int)Math.Ceiling (Superficie / MetAplicacion.rendimientoUnidad); 
            
            CotizarPedido ();
        }

        // FUNCIÓN COTIZACIÓN DE PEDIDO

        public void CotizarPedido ()
        {
            var costoMat = (decimal)CantBolsas* Material.precioUnidad;
            var costoAplic = (decimal)Superficie * MetAplicacion.valor;
            var costoTot = costoMat + costoAplic;
            var cot = new Cotizacion(costoTot);
            
            Cotizaciones.Add(cot);
        }

        // FUNCIÓN MUESTREO DE PEDIDO

        public void MuestreoPedido()
        {
            Console.WriteLine ("\n¡Ha finalizado la realización de su Pedido!");
            Console.WriteLine ("\n---------- PEDIDO ----------\n");
            
            Cliente.MuestreoClientes ();
            MetAplicacion.MuestreoMetodo ();
            Material.MuestreoMateriales ();
            
            Console.WriteLine ("\nBolsas Requeridas: " + CantBolsas); 
            Console.WriteLine("\nSuperficie: " + Superficie + " m2");
            Console.WriteLine("\nDirección: " + DirObra);
            
            Console.WriteLine("\n---------- COTIZACIONES ----------\n");

            foreach (var cot in Cotizaciones)
            {
                cot.MuestreoCotizacion ();
            }
        }
    }
}