using AutoMapper;
using Moq;
using skills_management.api.Domain.ProficiencyLevel.Queries;
using skills_management.api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_management.tests.Domain.ProficiencyLevel.Queries
{
    [TestFixture]
    public class GetProficiencyLevelTests
    {

        private readonly Mock<IProficiencyLevelRepository> _mockRepo = new Mock<IProficiencyLevelRepository>();

        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [Test]
        public void Verify_GetProficiencyLevel_Execute_Call()
        {


            // Arrange
            _mockRepo.Setup(x => x.GetAllProficiencyLevels());

            var sut = new GetProficiencyLevel(_mockMapper.Object, _mockRepo.Object);
            // Act
            sut.Execute();

            // Assert
            _mockRepo.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}
