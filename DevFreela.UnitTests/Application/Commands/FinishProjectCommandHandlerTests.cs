using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class FinishProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnVoid()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var paymentServiceMock = new Mock<IPaymentService>();
            
            var project = new Project("Nome de Teste 1", "Descrição de Teste 1", 1, 2, 10000);
            
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(1).Result).Returns(project);
            
            project.Start();

            var finishProjectCommand = new FinishProjectCommand(1, "12341234", "123", "10/29", "Fillipe S");
            var finishProjectCommandtHandler = new FinishProjectCommandHandler(projectRepositoryMock.Object, paymentServiceMock.Object);
            
            Assert.Equal(ProjectStatus.InProgress, project.Status);

            // Act
            await finishProjectCommandtHandler.Handle(finishProjectCommand, new CancellationToken());

            // Assert
            Assert.Equal(ProjectStatus.Finished, project.Status);
            projectRepositoryMock.Verify(f => f.FinishAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}