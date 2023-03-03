﻿using AutoMapper;
using Moq;
using skills_management.api.Contracts.DTO;
using skills_management.api.Domain.SkillMatrix.Commands;
using skills_management.api.Models;
using skills_management.api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_management.tests.Domain.SkillMatrix.Commands
{
    [TestFixture]
    public class UpdateSkillMatrixTests
    {

        private readonly Mock<ISkillMatrixRepository> _mockRepo = new Mock<ISkillMatrixRepository>();

        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [Test]
        public void Verify_UpdateSkillMatrix_Execute_Call()
        {

            List<TechnologyStackDto> technologyStacklist = new List<TechnologyStackDto>();

            TechnologyStackDto technologyStack = new TechnologyStackDto();
            technologyStack.TechnologyName = "Test";
            technologyStack.SelectedProficiencyLevel = 1;
            technologyStack.Selected = true;
            technologyStack.CategoryId = 1;
            technologyStack.Id = 1;
            technologyStacklist.Add(technologyStack);

            // Arrange
            _mockRepo.Setup(x => x.CreateSkill(It.IsAny<List<TechnologySkillsMatrix>>())).Returns(Task.FromResult(1));

            var sut = new UpdateSkillMatrix(_mockMapper.Object, _mockRepo.Object);
            // Act
            sut.Execute(technologyStacklist);

            // Assert
            // Assert
            _mockRepo.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}
