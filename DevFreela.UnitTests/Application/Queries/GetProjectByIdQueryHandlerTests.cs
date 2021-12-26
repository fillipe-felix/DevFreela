using System;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task OneProjectExist_Executed_ReturnOneProjectDetailsViewModel()
        {
            // Arrange
            var project = new Project("Nome de Teste 1", "Descrição de Teste 1", 1, 2, 10000);
            
            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(1).Result).Returns(project);

            var getProjectByIdQuery = new GetProjectByIdQuery(1);
            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectViewDetailsViewModel =
                await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewDetailsViewModel);
            Assert.Equal(project.Title, projectViewDetailsViewModel.Title);

            projectRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(1).Result, Times.Once);
        }
    }
}