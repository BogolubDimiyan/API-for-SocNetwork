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
    public class GroupMemberServiceTest
    {
        private readonly GroupMemberService service;
        private readonly Mock<IGroupMemberRepository> GmRepositoryMock;

        public GroupMemberServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            GmRepositoryMock = new Mock<IGroupMemberRepository>();

            repositoryWrapperMoq.Setup(x => x.Gm)
                .Returns(GmRepositoryMock.Object);

            service = new GroupMemberService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullGroupMember_ShouldThrownNullArgumentExceprion()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            GmRepositoryMock.Verify(x => x.Create(It.IsAny<GroupMember>()), Times.Never);
        }
    }
}