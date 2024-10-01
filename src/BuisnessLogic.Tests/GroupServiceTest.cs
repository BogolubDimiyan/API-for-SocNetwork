using BusinessLogic.Services;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuisnessLogic.Tests
{
    public class GroupServiceTest
    {
        private readonly GroupService service;
        private readonly Mock<IGroupRepository> GRepositoryMock;

        public GroupServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            GRepositoryMock = new Mock<IGroupRepository>();

            repositoryWrapperMoq.Setup(x => x.G)
                .Returns(GRepositoryMock.Object);

            service = new GroupService(repositoryWrapperMoq.Object);
        }
        [Fact]
        public async Task CreateAsync_NullGroup_ShouldThrownNullArgumentExceprion()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            GRepositoryMock.Verify(x => x.Create(It.IsAny<Group>()), Times.Never);
        }
    }
}