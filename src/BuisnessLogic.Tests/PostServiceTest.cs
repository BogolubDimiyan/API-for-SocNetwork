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

        [Fact]
        public async Task CreateAsync_NullPost_ShouldThrownNullArgumentExceprion()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            postRepositoryMock.Verify(x => x.Create(It.IsAny<Post>()), Times.Never);
        }
    }
}