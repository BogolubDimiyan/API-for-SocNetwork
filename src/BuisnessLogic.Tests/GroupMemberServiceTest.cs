using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        [Theory]
        [MemberData(nameof(GetIncorrectGroupMember))]
        public async Task CreateAsync_NewGroepMemberShouldNotCreateNewGroupMember(GroupMember group)
        {
            // arrange
            var newGroupM = group;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newGroupM));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            GmRepositoryMock.Verify(x => x.Create(It.IsAny<GroupMember>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectGroupMember()
        {
            return new List<object[]>
            {
                new object[] { new GroupMember { GroupId = 0, UserId = 0, Role = "", JoinedAt = DateTime.MaxValue } },
                new object[] { new GroupMember { GroupId = 1, UserId = 0, Role = "", JoinedAt = DateTime.MaxValue } },
                new object[] { new GroupMember { GroupId = 0, UserId = 0, Role = "Test", JoinedAt = DateTime.MaxValue } },
                new object[] { new GroupMember { GroupId = 0, UserId = 1, Role = "", JoinedAt = DateTime.MaxValue } }
            };
        }

        public async Task CreateAsyncNewGroupShouldCreateNewGroup()
        {
            var newGroupM = new GroupMember
            {
                GroupId = 1,
                UserId = 2,
                Role = "Test",
                JoinedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newGroupM);

            // aseert
            GmRepositoryMock.Verify(x => x.Create(It.IsAny<GroupMember>()), Times.Once);

        }
    }
}