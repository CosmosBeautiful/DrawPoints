using DrawPoint.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawPoint.Tests.Models
{
    [TestClass]
    public class PointMassTests
    {
        [TestMethod]
        public void PointMass_5xAnd8y_30Returned()
        {
            // arrange
            double x = 5;
            double y = 8;
            double expected = 9.43;

            // act
            PointMass point = new PointMass(x, y);

            // assert
            Assert.AreEqual(x, point.X);
            Assert.AreEqual(y, point.Y);
            Assert.AreEqual(expected, point.Mass);
        }

        [TestMethod]
        public void CompareTo_LessAndMorePointMass_1Returned()
        {
            // arrange
            PointMass lessPoint = new PointMass(5, 8);
            PointMass morePoint = new PointMass(11, 9);
            double expected = -5;

            // act
            double actual = lessPoint.CompareTo(morePoint);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
