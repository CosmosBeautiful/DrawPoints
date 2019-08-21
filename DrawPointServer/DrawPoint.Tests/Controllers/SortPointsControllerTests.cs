using DrawPoint.Controllers;
using DrawPoint.Models;
using DrawPoint.Models.Get;
using DrawPoint.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DrawPoint.Tests.Controllers
{
    [TestClass]
    public class SortPointsControllerTests
    {
        [TestMethod]
        public void GetLine_WasCalled()
        {
            // arrange
            Mock<ISortPointsRepository> mockSortPointsRepo = new Mock<ISortPointsRepository>();
            mockSortPointsRepo
                .Setup(repo => repo.CreateListPointMass(It.IsAny<GetArrayPoints[]>()))
                .Returns(new List<PointMass>());
            mockSortPointsRepo
               .Setup(repo => repo.SortPointsToLine(It.IsAny<List<PointMass>>()))
               .Returns(new List<PointMass>());

            SortPointsController controller = new SortPointsController(mockSortPointsRepo.Object);

            // act
            controller.GetLine(It.IsAny<GetArrayPoints[]>());

            // assert
            mockSortPointsRepo.VerifyAll();
        }

        [TestMethod]
        public void GetCurvedLine_WasCalled()
        {
            // arrange
            Mock<ISortPointsRepository> mockSortPointsRepo = new Mock<ISortPointsRepository>();
            mockSortPointsRepo
                .Setup(repo => repo.CreateListPointMass(It.IsAny<GetArrayPoints[]>()))
                .Returns(new List<PointMass>());
            mockSortPointsRepo
               .Setup(repo => repo.SortPointsToCurvedLine(It.IsAny<List<PointMass>>(), It.IsAny<double>()))
               .Returns(new List<CurvedLine>());

            SortPointsController controller = new SortPointsController(mockSortPointsRepo.Object);

            // act
            var result = controller.GetCurvedLine(It.IsAny<double>(), It.IsAny<GetArrayPoints[]>());

            // assert
            mockSortPointsRepo.VerifyAll();
        }
    }
}
