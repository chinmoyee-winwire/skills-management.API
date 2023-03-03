using Microsoft.AspNetCore.Mvc;
using Moq;
using skills_management.api.Controllers;
using skills_management.api.Domain.Interfaces.Queries;
using System.Net;

namespace skills_management.tests.Controllers
{
    [TestFixture]
    public class TechnologyStackControllerTests
    {

        private readonly Mock<ITechnologyStack> _mockRepo = new Mock<ITechnologyStack>();

        private TechnologyStackController _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new TechnologyStackController(_mockRepo.Object);

        }

        [Test]
        public void TechnologyStackController_Get_Success()
        {

            // Arrange
            _mockRepo.Setup(x => x.ExecuteByCategoryId(It.IsAny<int>()));

            // Act
            var results = _sut.GetTechnology(It.IsAny<int>()).Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(200, results?.StatusCode);
        }

        [Test]
        public void TechnologyStackController_Get_With_Exception_500()
        {

            // Arrange
            _mockRepo.Setup(x => x.ExecuteByCategoryId(It.IsAny<int>())).Throws(new Exception());

            // Act
            var results = _sut.GetTechnology(It.IsAny<int>()).Result as StatusCodeResult;

            // Assert
            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, results.StatusCode);
        }
    }
}
