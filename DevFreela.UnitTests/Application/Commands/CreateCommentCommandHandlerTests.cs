using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnVoid()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var createCommentCommand = new CreateCommentCommand()
            {
                Content = "Comentario teste",
                IdProject = 1,
                IdUser = 1
            };

            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepositoryMock.Object);

            // Act
            await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());

            // Assert
            projectRepositoryMock.Verify(c => c.AddCommentAsync(It.IsAny<ProjectComment>()), Times.Once);
        }
    }
}