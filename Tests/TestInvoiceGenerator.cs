using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerator;
using CabInvoiceGenerator.Utils;

namespace Tests
{
    [TestClass]
    public class TestInvoiceGenerator
    {
        private CabInvoiceException _ex;
        private InvoiceGenerator _appNormal;
        private InvoiceGenerator _appPremium;

        [TestInitialize]
        public void SetUp()
        {
            _appNormal = new InvoiceGenerator(RideType.Normal);
            _appPremium = new InvoiceGenerator(RideType.Premium);
        }

        [TestMethod, TestCategory("Fare")]
        public void Test_GivenDistanceAndTime_ShouldReturnTotalFair()
        {
            Assert.AreEqual(_appNormal.CalculateFare(time: 5, distance: 2.0), 25); // test for valid time and distance value
            _ex = Assert.ThrowsException<CabInvoiceException>(() => _appNormal.CalculateFare(time: -5, distance: 2.0));
            Assert.AreEqual(ExceptionType.InvalidTime, _ex.exception); // test for negative time value
            _ex = Assert.ThrowsException<CabInvoiceException>(() => _appNormal.CalculateFare(time: 5, distance: -2.0));
            Assert.AreEqual(ExceptionType.InvalidDistance, _ex.exception); // test for negative distance value
        }
        
        [TestMethod, TestCategory("Fare")]
        public void Test_GivenMultipleRides_ShouldReturnAggregateTotalFair()
        {
            _ex = Assert.ThrowsException<CabInvoiceException>(()=> _appNormal.CalculateFare(null));
            Assert.AreEqual(ExceptionType.NullRides, _ex.exception);
            
            Ride[] payload = new Ride[] { };
            _ex = Assert.ThrowsException<CabInvoiceException>(()=> _appNormal.CalculateFare(payload));
            Assert.AreEqual(0, payload.Length);
            Assert.AreEqual(ExceptionType.NullRides, _ex.exception);
            
            payload = new Ride[] {new Ride(2.0, 5), new Ride(0.1, 1)};
            Assert.AreEqual(30, _appNormal.CalculateFare(payload));
            Assert.AreEqual(60, _appPremium.CalculateFare(payload));
            
        }
    }
}
