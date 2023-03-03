using AutoMapper;
using Moq;
using skills_management.api.Domain.Practices.Queries;
using skills_management.api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_management.tests.Domain.Practices.Queries
{
    [TestFixture]
    public class GetPracticesTests
    {

        private readonly Mock<IPracticesRepository> _mockRepo = new Mock<IPracticesRepository>();

        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [Test]
        public void Verify_GetPractices_Execute_Call()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetAllPractices());

            var sut = new GetPractices(_mockMapper.Object, _mockRepo.Object);
            // Act
            sut.Execute();

            // Assert
            // Assert
            _mockRepo.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}
