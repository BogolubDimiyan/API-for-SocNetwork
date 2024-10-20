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
    public class PostServiceTest
    {
        private readonly PostService service;
        private readonly Mock<IPostRepository> postRepositoryMock;

        public PostServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            postRepositoryMock = new Mock<IPostRepository>();

            repositoryWrapperMoq.Setup(x => x.Post)
                .Returns(postRepositoryMock.Object);

            service = new PostService(repositoryWrapperMoq.Object);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsync_NewUserShouldNotCreateNewUser(Post post)
        {
            // arrange
            var newPost = post;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newPost));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            postRepositoryMock.Verify(x => x.Create(It.IsAny<Post>()), Times.Never);

        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new Post { UserId = 0, Content = "", ImageUrl = "", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Post { UserId = 0, Content = "Test", ImageUrl = "", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Post { UserId = 0, Content = "", ImageUrl = "Test", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Post { UserId = 1, Content = "", ImageUrl = "", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newPost = new Post
            {
                UserId = 1,
                Content = "Test",
                ImageUrl = "Test",
                CreatedAt = DateTime.MaxValue,
                UpdatedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newPost);

            // aseert
            postRepositoryMock.Verify(x => x.Create(It.IsAny<Post>()), Times.Once);
        }
    }
}