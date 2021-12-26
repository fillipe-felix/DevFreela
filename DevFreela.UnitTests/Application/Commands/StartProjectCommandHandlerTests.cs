using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class StartProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnVoid()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var startProjectCommand = new StartProjectCommand(1);
            
            var project = new Project("Nome de Teste 1", "Descrição de Teste 1", 1, 2, 10000);
            
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(1).Result).Returns(project);

            var startProjectCommandHandler = new StartProjectCommandHandler(projectRepositoryMock.Object);

            // Act
            await startProjectCommandHandler.Handle(startProjectCommand, new CancellationToken());

            // Assert
            Assert.Equal(ProjectStatus.InProgress, project.Status);
            projectRepositoryMock.Verify(pr => pr.StartAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}