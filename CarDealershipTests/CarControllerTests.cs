using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comp2084_CarDealer.Controllers;
namespace CarDealershipTests
{
    [TestClass]
    public class CarControllerTests
    {
        [TestMethod]
        public void DeleteUsesDAL()
        {
            //arrange
            Fakes.FakeCarDAL DAL = new Fakes.FakeCarDAL();
            CarsController controller = new CarsController(DAL);

            //Act
            controller.DeleteConfirmed(5);

            //Assert
            Assert.AreEqual(5, DAL.carDeleted);

        }
    }
}
