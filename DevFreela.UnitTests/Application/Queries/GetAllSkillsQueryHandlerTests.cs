using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetAllskills;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeSkillsExist_Executed_ReturnThreeSkillViewModels()
        {
            // Arrange
            var skills = new List<SkillDto>
            {
                new SkillDto(1, "Skill de teste 1"),
                new SkillDto(2, "Skill de teste 2"),
                new SkillDto(3, "Skill de teste 3"),
            };

            var skillRepositoryMock = new Mock<ISkillRepository>();
            skillRepositoryMock.Setup(s => s.GetAllAsync().Result).Returns(skills);

            var getAllSkillsQuery = new GetAllSkillsQuery();
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            // Act
            var skillViewModelList = await getAllSkillsQueryHandler.Handle(getAllSkillsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(skillViewModelList);
            Assert.NotEmpty(skillViewModelList);
            Assert.Equal(skills.Count, skillViewModelList.Count);

            skillRepositoryMock.Verify(s => s.GetAllAsync().Result, Times.Once);
        }
    }
}