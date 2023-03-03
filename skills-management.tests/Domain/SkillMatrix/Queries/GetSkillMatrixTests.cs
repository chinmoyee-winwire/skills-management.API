using AutoMapper;
using Moq;
using skills_management.api.Domain.SkillMatrix.Queries;
using skills_management.api.Models;
using skills_management.api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_management.tests.Domain.SkillMatrix.Queries
{
    [TestFixture]
    public class GetSkillMatrixTests
    {

        private readonly Mock<ISkillMatrixRepository> _mockRepo = new Mock<ISkillMatrixRepository>();

        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [Test]
        public void Verify_GetSkillMatrix_Execute_Call()
        {
            List<SkillsMatrixResults> result = new List<SkillsMatrixResults>();

            SkillsMatrixResults skillmatrix = new SkillsMatrixResults();
            skillmatrix.PracticeId = 1;
            skillmatrix.TechnologyName = "Test";
            skillmatrix.PracticesName = "Test";
            skillmatrix.SelectedProficiencyLevel = 1;
            skillmatrix.EmployeeName = "Test";
            skillmatrix.Selected = 1;
            skillmatrix.CategoryId = 1;
            skillmatrix.CategoryName = "Test";
            result.Add(skillmatrix);


            SkillsMatrixResults skillmatrix1 = new SkillsMatrixResults();
            skillmatrix1.PracticeId = 1;
            skillmatrix1.TechnologyName = "Test1";
            skillmatrix1.PracticesName = "Test1";
            skillmatrix1.SelectedProficiencyLevel = 1;
            skillmatrix1.EmployeeName = "Test1";
            skillmatrix1.Selected = 1;
            skillmatrix1.CategoryId = 0;
            skillmatrix1.CategoryName = "Test2";
            result.Add(skillmatrix1);

            // Arrange
            _mockRepo.Setup(x => x.GetAllSkills(It.IsAny<string>())).Returns(Task.FromResult<IEnumerable<SkillsMatrixResults>>(result));

            var sut = new GetSkillMatrix(_mockMapper.Object, _mockRepo.Object);
            // Act
            sut.Execute(It.IsAny<string>());

            // Assert
            // Assert
            _mockRepo.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}
