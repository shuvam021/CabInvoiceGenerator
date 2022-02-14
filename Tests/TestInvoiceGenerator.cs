using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerator;
using CabInvoiceGenerator.Utils;

namespace Tests
{
    [TestClass]
    public class TestInvoiceGenerator
    {
        private CabInvoiceException _ex;
        private InvoiceGenerator _app;

        [TestInitialize]
        public void SetUp()
        {
            _app = new InvoiceGenerator(RideType.Normal);
        }

        [TestMethod, TestCategory("Fare")]
        public void Test_GivenDistanceAndTime_ShouldReturnTotalFair()
        {
            Assert.AreEqual(_app.CalculateFare(time: 5, distance: 2.0), 25); // test for valid time and distance value
            _ex = Assert.ThrowsException<CabInvoiceException>(() => _app.CalculateFare(time: -5, distance: 2.0));
            Assert.AreEqual(ExceptionType.InvalidTime, _ex.exception); // test for negative time value
            _ex = Assert.ThrowsException<CabInvoiceException>(() => _app.CalculateFare(time: 5, distance: -2.0));
            Assert.AreEqual(ExceptionType.InvalidDistance, _ex.exception); // test for negative distance value
        }
    }
}
