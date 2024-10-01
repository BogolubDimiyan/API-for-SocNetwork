using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMock;
        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMock = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User)
                .Returns(userRepositoryMock.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrownNullArgumentExceprion()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }
    }
}
