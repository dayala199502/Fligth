using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IFlightsInterfaces flightsInterfaces = new FlightsServices();
            Assert.IsNotNull(flightsInterfaces.GetFligths());
        }
        [TestMethod]
        public void TestMethod()
        {
            IFlightsInterfaces flightsInterfaces = new FlightsServices();
            Assert.IsNotNull(flightsInterfaces.GetFligthsSearch(new Business.Models.JourneyModels()
            {
                Origin = "MZL",
                Destination = "BCN"
            }));

        }
    }
}
