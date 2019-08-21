using DrawPoint.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawPoint.Tests.Models
{
    [TestClass]
    public class CurvedLineTests
    {
        [TestMethod]
        public void CurvedLine_3PointsAnd270Angle_43MassAnd27x45yBezEPoint()
        {
            // arrange
            Point startPoint = new Point(16,47);
            Point endPoint = new Point(25, 34); ;
            Point centerPoint = new Point(5, 5); ;
            double angle = 270;
            double expectedMass = 43.42;
            Point expectedBezEPoint = new Point(27,45);

            // act
            CurvedLine curvedLine = new CurvedLine(startPoint, endPoint, centerPoint, angle);

            // assert
            Assert.AreEqual(startPoint, curvedLine.StartPoint);
            Assert.AreEqual(endPoint, curvedLine.EndPoint);
            Assert.AreEqual(expectedMass, curvedLine.Mass);
            Assert.AreEqual(expectedBezEPoint.X, curvedLine.BezEPoint.X);
            Assert.AreEqual(expectedBezEPoint.Y, curvedLine.BezEPoint.Y);
        }
    }
}
