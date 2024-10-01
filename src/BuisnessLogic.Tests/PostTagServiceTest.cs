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
    public class PostTagServiceTest
    {
        private readonly PostTagService service;
        private readonly Mock<IPostTagRepository> posttgRepositoryMock;

        public PostTagServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            posttgRepositoryMock = new Mock<IPostTagRepository>();

            repositoryWrapperMoq.Setup(x => x.PostTg)
                .Returns(posttgRepositoryMock.Object);

            service = new PostTagService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullPostTag_ShouldThrownNullArgumentExceprion()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            posttgRepositoryMock.Verify(x => x.Create(It.IsAny<PostTag>()), Times.Never);
        }
    }
}