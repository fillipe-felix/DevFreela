using System;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetUserQueryHandlerTests
    {
        [Fact]
        public async Task OneUserExist_Executed_ReturnOneUserViewModel()
        {
            // Arrange
            var user = new User("Fillipe", "fillipe@gmail.com", DateTime.Now, "Teste@123", "client");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(u => u.GetByIdAsync(1).Result).Returns(user);

            var getUserQuery = new GetUserQuery(1);
            var getUserQueryHandler = new GetUserQueryHandler(userRepositoryMock.Object);
            
            // Act
            var userViewModel = await getUserQueryHandler.Handle(getUserQuery, new CancellationToken());
            
            // Assert
            Assert.NotNull(userViewModel);
            Assert.Equal(user.FullName, userViewModel.FullName);
            
            userRepositoryMock.Verify(u => u.GetByIdAsync(1).Result, Times.Once);
        }
    }
}