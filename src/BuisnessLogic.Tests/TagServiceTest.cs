using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BuisnessLogic.Tests
{
    public class TagServiceTest
    {
        private readonly TagService service;
        private readonly Mock<ITagRepository> tagRepositoryMock;

        public TagServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            tagRepositoryMock = new Mock<ITagRepository>();

            repositoryWrapperMoq.Setup(x => x.Tag)
                .Returns(tagRepositoryMock.Object);

            service = new TagService(repositoryWrapperMoq.Object);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectTags))]
        public async Task CreateAsync_NewTagShouldNotCreateTag(Tag tag)
        {
            // arrange
            var newTag = tag;

            //act
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(newTag));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            tagRepositoryMock.Verify(x => x.Create(It.IsAny<Tag>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectTags()
        {
            return new List<object[]>
            {
                new object[] { new Tag {Name = "" } },
                new object[] { new Tag {Name = " " } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewTagShouldCreateNewTag()
        {
            var newTag = new Tag
            {
                Name = "Test",
            };

            // act
            await service.Create(newTag);

            // assert
            tagRepositoryMock.Verify(x => x.Create(It.IsAny<Tag>()), Times.Once);
        }
    }
}