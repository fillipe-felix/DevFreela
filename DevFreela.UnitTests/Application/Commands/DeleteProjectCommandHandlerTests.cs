using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class DeleteProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnVoid()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var deleteProjectCommand = new DeleteProjectCommand(1);

            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepositoryMock.Object);
            
            var project = new Project("Nome de Teste 1", "Descrição de Teste 1", 1, 2, 10000);
            
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(1).Result).Returns(project);
            
            project.Start();

            // Act
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            // Assert
            Assert.Equal(ProjectStatus.Cancelled, project.Status);
            projectRepositoryMock.Verify(d => d.DeleteAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}