using System;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class AddUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new Mock<IAuthService>();

            var createUserCommand = new CreateUserCommand()
            {
                FullName = "Fillipe",
                Email = "fillipe@gmail.com",
                Password = "Teste@123",
                Role = "client",
                BirthDate = DateTime.Now
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, userService.Object);

            // Act
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);
            userRepositoryMock.Verify(u => u.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}