using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.Demo.EF.Logic;
using Lab.Demo.EF.Entities;
using Newtonsoft.Json.Serialization;

namespace Lab.Demo.EF.Test
{
    /// <summary>
    /// Summary description for RegionTest
    /// </summary>
    [TestClass]
    public class RegionTest
    {

        ILogic<Region> logic;


        [TestInitialize]
        public void setup() {

            this.logic = new RegionLogic();
        }


        [TestMethod]
        public void ObtenerRegiones() {

            //arrange

            //act
            var regiones = logic.GetAll();
            //assert

            Assert.IsTrue(regiones.Count> 0);


          
        }


        [TestMethod]
        public void ObtenerUnaRegion()
        {
            

            //arrange
            int idRegion = 1;
            //act
            var regiones = logic.GetOne(idRegion);
            //assert

            Assert.IsTrue(regiones.RegionID == 1);
            
        }



    }
}
