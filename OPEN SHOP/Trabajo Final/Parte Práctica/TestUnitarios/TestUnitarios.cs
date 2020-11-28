using Newtonsoft.Json;
using System.IO;
using OpenShopCatalogo;
using System.Collections.Generic;
using System;
using Xunit;

namespace TestUnitarios
{   
    // TEST VALIDADOS

    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        public void TestJSON ()
        {
            bool Json = false;
            
            var EstructuraJSON = JsonConvert.SerializeObject (GestorProducto.CreacionJSON, Formatting.Indented);
            
            File.WriteAllText ("JSON - Catálogo.txt", EstructuraJSON);

            if (File.Exists ("JSON - Catálogo.txt"))
            {
                Json = true;
            }
 
            Assert.IsTrue (Json);
        }

        [TestMethod]
        public void TestInicioSesion ()
        {
            string Usuario = "nacho.massoni";
            string Contraseña = "1999nacho";

            var Validacion = Inicio.VerificarInicio (Usuario, Contraseña);

            Assert.IsTrue (Validacion);
        }

        [TestMethod]
        public void TestNombre ()
        {
            string nombre = "81WB00S6AR";

            var Validacion = GestorProducto.ValidarNombre (nombre);

            Assert.IsTrue (Validacion);
        }

        [TestMethod]
        public void TestArticulo ()
        {
            int totalArticulos = GestorProducto.MostrarArticulos();
           
            var JSON = File.ReadAllText ("JSON - Catálogo.txt");

            List <Producto> articulosJSON = JsonConvert.DeserializeObject <List <Producto>> (JSON);

            foreach (var articulo in articulosJSON)
            {
                GestorProducto.JSON.Add (new Producto (articulo.IdArticulo, articulo.Nombre, articulo.Marca, articulo.Precio, articulo.Descripcion, articulo.Stock));
            }

            Assert.AreEqual (GestorProducto.ListaArticulos.Count, totalArticulos);
        }
    }
}