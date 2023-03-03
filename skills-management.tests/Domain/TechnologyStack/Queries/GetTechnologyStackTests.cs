using AutoMapper;
using Moq;
using skills_management.api.Domain.TechnologyStack.Queries;
using skills_management.api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_management.tests.Domain.TechnologyStack.Queries
{
    [TestFixture]
    public class GetTechnologyStackTests
    {

        private readonly Mock<ITechnologyStackRepository> _mockRepo = new Mock<ITechnologyStackRepository>();

        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [Test]
        public void Verify_GetTechnologyStack_Execute_Call()
        {


            // Arrange
            _mockRepo.Setup(x => x.GetTechnologyByCategoryId(It.IsAny<int>()));

            var sut = new GetTechnologyStack(_mockMapper.Object, _mockRepo.Object);
            // Act
            sut.ExecuteByCategoryId(It.IsAny<int>());

            // Assert
            // Assert
            _mockRepo.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}
