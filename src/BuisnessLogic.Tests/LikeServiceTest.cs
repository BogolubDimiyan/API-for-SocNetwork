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
    public class LikeServiceTest
    {
        private readonly LikeService service;
        private readonly Mock<ILikeRepository> likeRepositoryMock;

        public LikeServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            likeRepositoryMock = new Mock<ILikeRepository>();

            repositoryWrapperMoq.Setup(x => x.Like)
                .Returns(likeRepositoryMock.Object);

            service = new LikeService(repositoryWrapperMoq.Object);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsync_NewLikeShouldNotCreateNewLike(Like like)
        {
            // arrange
            var newLike = like;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newLike));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            likeRepositoryMock.Verify(x => x.Create(It.IsAny<Like>()), Times.Never);

        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new Like { PostId = 0, UserId = 0, CreatedAt = DateTime.MaxValue } },
                new object[] { new Like { PostId = 0, UserId = 1, CreatedAt = DateTime.MaxValue } },
                new object[] { new Like { PostId = 1, UserId = 0, CreatedAt = DateTime.MaxValue } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newLike = new Like
            {
                PostId = 1,
                UserId = 1,
                CreatedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newLike);

            // aseert
            likeRepositoryMock.Verify(x => x.Create(It.IsAny<Like>()), Times.Once);
        }
    }
}