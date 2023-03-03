using AutoMapper;
using Moq;
using skills_management.api.Domain.Category.Queries;
using skills_management.api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_management.tests.Domain.Category.Queries
{
    [TestFixture]
    public class GetCategoriesTests
    {

        private readonly Mock<ICategoriesRepository> _mockRepo = new Mock<ICategoriesRepository>();

        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [Test]
        public void Verify_GetCategories_Execute_Call()
        {


            // Arrange
            _mockRepo.Setup(x => x.GetAllCategories(It.IsAny<int>()));

            var sut = new GetCategories(_mockMapper.Object, _mockRepo.Object);
            // Act
            sut.Execute(It.IsAny<int>());

            // Assert
            // Assert
            _mockRepo.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}
