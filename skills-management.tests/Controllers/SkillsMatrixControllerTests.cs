using Microsoft.AspNetCore.Mvc;
using Moq;
using skills_management.api.Controllers;
using skills_management.api.Domain.Interfaces.Commands;
using skills_management.api.Domain.Interfaces.Queries;
using System.Net;

namespace skills_management.tests.Controllers
{
    [TestFixture]
    public class SkillMatrixControllerTests
    {

        private readonly Mock<ISkillMatrix> _mockRepo = new Mock<ISkillMatrix>();
        private readonly Mock<ICreateSkillMatrix> _mockCreateSkill = new Mock<ICreateSkillMatrix>();
        private readonly Mock<IUpdateSkillMatrix> _mockUpdateSkill = new Mock<IUpdateSkillMatrix>();

        private SkillsMatrixController _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new SkillsMatrixController(_mockRepo.Object, _mockCreateSkill.Object, _mockUpdateSkill.Object);

        }

        [Test]
        public void SkillMatrixController_Get_Success()
        {

            // Arrange
            _mockRepo.Setup(x => x.Execute("Angular"));

            // Act
            var results = _sut.GetTechnologySkillMatrix("Angular").Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(200, results?.StatusCode);
        }

        [Test]
        public void SkillMatrixController_CreateSkillMatrix_Success()
        {
            List<api.Contracts.DTO.SkillsMatrixDto> lstSkillsMatrix = new List<api.Contracts.DTO.SkillsMatrixDto>();
            api.Contracts.DTO.SkillsMatrixDto skillmatrix = new api.Contracts.DTO.SkillsMatrixDto();
            lstSkillsMatrix.Add(skillmatrix);

            // Arrange
            _mockCreateSkill.Setup(x => x.Execute(lstSkillsMatrix));

            // Act
            var results = _sut.CreateSkillsMatrixOnSearch(lstSkillsMatrix).Result as NoContentResult;

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(204, results?.StatusCode);
        }

        [Test]
        public void SkillMatrixController_UpdateSkillMatrix_Success()
        {
            List<api.Contracts.DTO.TechnologyStackDto> lstSkillsMatrix = new List<api.Contracts.DTO.TechnologyStackDto>();
            api.Contracts.DTO.TechnologyStackDto skillmatrix = new api.Contracts.DTO.TechnologyStackDto();
            lstSkillsMatrix.Add(skillmatrix);

            // Arrange
            _mockUpdateSkill.Setup(x => x.Execute(lstSkillsMatrix));

            // Act
            var results = _sut.UpdateSkillsMatrix(lstSkillsMatrix).Result as NoContentResult;

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(204, results?.StatusCode);
        }
    }
}
