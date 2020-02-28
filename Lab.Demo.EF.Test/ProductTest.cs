﻿using System;
using Lab.Demo.EF.Logic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.Demo.EF.Entities;

namespace Lab.Demo.EF.Test
{
    [TestClass]
    public class ProductTest
    {
        ILogic<Region> logic;

        ///Este metodo decorado con el [Test Initialize] sirve para preparar los escenarios de prueba de esta Test Class, antes de ejecutar el Test, se va a 
        ///ejecutar este metodo Setup, de esta manera como en ambos Test Methods necesitamos utilizar una instancia de nuestro ProductLogic, lo que estamos 
        ///haciendo es instanciarlo una sola vez en el metodo Setup y sacarlo de cada uno de los Test Methods.
        [TestInitialize]
        public void Setup()
        {
            logic = new RegionLogic();
        }

        [TestMethod]
        public void QuieroObtenerTodosLosProductos()
        {
            //ARRANGE
            int cantidadDeProductos = 4;
        
            //ACT
            var list = logic.GetAll();

            //ASSERT
            Assert.IsTrue(list.Any());
            Assert.AreEqual(cantidadDeProductos, list.Count);
        }

        [TestMethod]
        public void QuieroObtenerElProductoConId65()
        {
            //ARRANGE
            int id = 3;
            string description = "Northern";
            
            //ACT
            Region productoObtenido = logic.GetOne(id);

            //ASSERT
            Assert.AreEqual(id, productoObtenido.RegionID);
            Assert.AreEqual(description, productoObtenido.RegionDescription.Trim());
        }
    }
}
