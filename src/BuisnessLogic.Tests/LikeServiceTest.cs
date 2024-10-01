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

        [Fact]
        public async Task CreateAsync_NullLike_ShouldThrownNullArgumentExceprion()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            likeRepositoryMock.Verify(x => x.Create(It.IsAny<Like>()), Times.Never);
        }
    }
}