using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLogic;

namespace ParkingLogicTests
{
    [TestClass]
    public class FullSliceTests
    {
        public AvailableRates availableRates = new AvailableRates();
        public int year = 2019;
        [TestMethod]
        public void EarlyBird()
        {
            DateTime sd = new DateTime(2019, 10, 25, 7, 0, 0);
            DateTime ed = new DateTime(2019, 10, 25, 16, 0, 0);
            PatronTimeSpend pts = new PatronTimeSpend(sd, ed);
            Result r = availableRates.GetResult(pts);
            Assert.AreEqual(r.RateName, "Early Bird");
            Assert.AreEqual(r.TotalPrice, 13.00);
        }

        [TestMethod]
        public void NightRate()
        {
            DateTime sd = new DateTime(2019, 10, 25, 19, 0, 0);
            DateTime ed = new DateTime(2019, 10, 26, 6, 0, 0);
            PatronTimeSpend pts = new PatronTimeSpend(sd, ed);
            Result r = availableRates.GetResult(pts);
            Assert.AreEqual(r.RateName, "Night Rate");
            Assert.AreEqual(r.TotalPrice, 6.50);
        }

        [TestMethod]
        public void WeekendRate()
        {
            DateTime sd = new DateTime(2019, 10, 26, 0, 0, 0);
            DateTime ed = new DateTime(2019, 10, 27, 23, 59, 59);
            PatronTimeSpend pts = new PatronTimeSpend(sd, ed);
            Result r = availableRates.GetResult(pts);
            Assert.AreEqual(r.RateName, "Weekend Rate");
            Assert.AreEqual(r.TotalPrice, 10.00);
        }

        [TestMethod]
        public void StandardRateOneHour()
        {
            DateTime sd = new DateTime(2019, 10, 25, 10, 0, 0);
            DateTime ed = new DateTime(2019, 10, 25, 10, 59, 59);
            PatronTimeSpend pts = new PatronTimeSpend(sd, ed);
            Result r = availableRates.GetResult(pts);
            Assert.AreEqual(r.RateName, "Standard Rate");
            Assert.AreEqual(r.TotalPrice, 5.00);
        }

        [TestMethod]
        public void StandardRateTwoHours()
        {
            DateTime sd = new DateTime(2019, 10, 25, 10, 0, 0);
            DateTime ed = new DateTime(2019, 10, 25, 11, 59, 59);
            PatronTimeSpend pts = new PatronTimeSpend(sd, ed);
            Result r = availableRates.GetResult(pts);
            Assert.AreEqual(r.RateName, "Standard Rate");
            Assert.AreEqual(r.TotalPrice, 20.00);
        }

        [TestMethod]
        public void StandardRateThreeHours()
        {
            DateTime sd = new DateTime(2019, 10, 25, 10, 0, 0);
            DateTime ed = new DateTime(2019, 10, 25, 12, 59, 59);
            PatronTimeSpend pts = new PatronTimeSpend(sd, ed);
            Result r = availableRates.GetResult(pts);
            Assert.AreEqual(r.RateName, "Standard Rate");
            Assert.AreEqual(r.TotalPrice, 45.00);
        }

        [TestMethod]
        public void StandardRateMoreThanThreeHours()
        {
            DateTime sd = new DateTime(2019, 10, 25, 10, 0, 0);
            DateTime ed = new DateTime(2019, 10, 29, 12, 59, 59);
            PatronTimeSpend pts = new PatronTimeSpend(sd, ed);
            Result r = availableRates.GetResult(pts);
            Assert.AreEqual(r.RateName, "Standard Rate");
            Assert.AreEqual(r.TotalPrice, 80.00);
        }

    }
}
