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

        [Fact]
        public async Task CreateAsync_NullTag_ShouldThrownNullArgumentExceprion()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            tagRepositoryMock.Verify(x => x.Create(It.IsAny<Tag>()), Times.Never);
        }
    }
}
