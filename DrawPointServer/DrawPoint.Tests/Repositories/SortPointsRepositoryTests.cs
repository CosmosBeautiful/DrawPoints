using DrawPoint.Models;
using DrawPoint.Models.Get;
using DrawPoint.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DrawPoint.Tests.Repositories
{
    [TestClass]
    public class SortPointsRepositoryTests
    {
        private SortPointsRepository sortPointsRepository;

        [TestInitialize]
        public void ClassInitialize()
        {
            sortPointsRepository = new SortPointsRepository();
        }

        [TestMethod]
        public void CreateListPointMass_ArrXAndArrY_ReturnListPointMass()
        {
            // arrange
            GetArrayPoints[] arrayPoints = 
            {
                new GetArrayPoints() { X = 5, Y = 8 },
                new GetArrayPoints() { X = 4, Y = 6 },
                new GetArrayPoints() { X = -7, Y = -4 },
            };

            // act
            List<PointMass> points = sortPointsRepository.CreateListPointMass(arrayPoints);

            // assert
            int i = 0;
            foreach (PointMass actualPoint in points)
            {
                Assert.AreEqual(arrayPoints[i].X, actualPoint.X);
                Assert.AreEqual(arrayPoints[i].Y, actualPoint.Y);

                i++;
            }
        }

        [TestMethod]
        public void SortPointsToLine_ListPoint_SortingListPoint()
        {
            // arrange
            List<PointMass> points = new List<PointMass>
            {
                new PointMass(82, 45),
                new PointMass(65, 73),
                new PointMass(5, 17),
                new PointMass(40, 86),
                new PointMass(95, 94)
            };
            List<PointMass> expectedPoints = new List<PointMass>
            {
                new PointMass(5, 17),
                new PointMass(82, 45),
                new PointMass(40, 86),
                new PointMass(65, 73),
                new PointMass(95, 94)
            };

            // act
            List<PointMass> actualPoints = sortPointsRepository.SortPointsToLine(points);

            // assert
            CollectionAssert.AreEqual(expectedPoints, actualPoints);
        }

        [TestMethod]
        public void SortPointsToCurvedLine()
        {
            // arrange
            List<PointMass> points = new List<PointMass>
            {
                new PointMass(82, 45),
                new PointMass(65, 73),
                new PointMass(5, 17),
                new PointMass(40, 86),
                new PointMass(95, 94)
            };
            double angle = 270;
            Point centerPoint = new Point(5, 17);
            List<CurvedLine> expectedCurvedLines = new List<CurvedLine>
            {
                new CurvedLine(new Point(82, 45), new Point(65, 73), centerPoint, angle),
                new CurvedLine(new Point(65, 73), new Point(5, 17), centerPoint, angle),
                new CurvedLine(new Point(5, 17), new Point(40, 86), centerPoint, angle),
                new CurvedLine(new Point(40, 86), new Point(95, 94), centerPoint, angle)
            };

            // act
            List<CurvedLine> actualCurvedLines = sortPointsRepository.SortPointsToCurvedLine(points, angle);

            // assert
            CollectionAssert.AreEqual(expectedCurvedLines, actualCurvedLines);
        }
    }
}
