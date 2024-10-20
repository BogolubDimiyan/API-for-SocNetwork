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

        [Theory]
        [MemberData(nameof(GetIncorrectPostTags))]
        public async Task CreateAsync_NewPostTagShouldNotCreateNewPostedTag(PostTag ptag)
        {
            // arrange
            var newPostTag = ptag;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newPostTag));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            posttgRepositoryMock.Verify(x => x.Create(It.IsAny<PostTag>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectPostTags()
        {
            return new List<object[]>
            {
                new object[] { new PostTag { PostId = 1, TagId = 0 } },
                new object[] { new PostTag { PostId = 0, TagId = 1 } },
                new object[] { new PostTag { PostId = 0, TagId = 0 } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newPostTag = new PostTag
            {
                PostId = 1,
                TagId = 2,
            };

            // act
            await service.Create(newPostTag);

            // aseert
            posttgRepositoryMock.Verify(x => x.Create(It.IsAny<PostTag>()), Times.Once);
        }
    }
}