using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class UpdateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnVoid()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            
            var project = new Project("Nome de Teste 1", "Descrição de Teste 1", 1, 2, 10000);
            
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(1).Result).Returns(project);

            var updateProjectCommand = new UpdateProjectCommand
            {
                Id = 1,
                Description = "Teste descrição",
                Title = "Teste projeto",
                TotalCost = 1000
            };

            var updateProjectCommandHandler = new UpdateProjectCommandHandler(projectRepositoryMock.Object);

            // Act
            await updateProjectCommandHandler.Handle(updateProjectCommand, new CancellationToken());

            // Assert
            Assert.Equal(project.Title, updateProjectCommand.Title);
            projectRepositoryMock.Verify(pr => pr.SaveChangesAsync(), Times.Once);
            projectRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}