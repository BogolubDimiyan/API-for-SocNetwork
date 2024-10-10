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

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsync_NewUserShouldNotCreateNewUser(User user)
        {
            // arrange
            var newUser = user;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newUser));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new User { Username = "", Email = "", PasswordHash = "", FirstName = "", LastName = "", Birthdate = DateTime.MaxValue, Gender = "", ProfilePicture = "", Bio = "", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new User { Username = "Test", Email = "", PasswordHash = "", FirstName = "", LastName = "Test", Birthdate = DateTime.MaxValue, Gender = "", ProfilePicture = "", Bio = "", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new User { Username = "", Email = "", PasswordHash = "", FirstName = "", LastName = "Test", Birthdate = DateTime.MaxValue, Gender = "", ProfilePicture = "", Bio = "", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new User
            {
                Username = "Test",
                Email = "Test",
                PasswordHash = "Test",
                FirstName = "Test",
                LastName = "Test",
                Birthdate = DateTime.MaxValue,
                Gender = "Test",
                ProfilePicture = "Test",
                Bio = "Test",
                CreatedAt = DateTime.MaxValue,
                UpdatedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newUser);

            // aseert
            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }
    } 
}
