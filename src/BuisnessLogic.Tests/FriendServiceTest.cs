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
    public class FriendServiceTest
    {
        private readonly FriendService service;
        private readonly Mock<IFriendRepository> FreindRepositoryMock;

        public FriendServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            FreindRepositoryMock = new Mock<IFriendRepository>();

            repositoryWrapperMoq.Setup(x => x.Friend)
                .Returns(FreindRepositoryMock.Object);

            service = new FriendService(repositoryWrapperMoq.Object);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectFriend))]
        public async Task CreateAsync_NewFriendShouldNotCreateNewFriend(Friend friend)
        {
            // arrange
            var newFriend = friend;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newFriend));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            FreindRepositoryMock.Verify(x => x.Create(It.IsAny<Friend>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectFriend()
        {
            return new List<object[]>
            {
                new object[] { new Friend { Id = 0, RequesterId = 0, ReceiverId = 0, Status="", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Friend { Id = 1, RequesterId = 0, ReceiverId = 0, Status="", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Friend { Id = 0, RequesterId = 1, ReceiverId = 0, Status="", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Friend { Id = 0, RequesterId = 0, ReceiverId = 1, Status="", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Friend { Id = 0, RequesterId = 0, ReceiverId = 0, Status="Test", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
            };
        }

        public async Task CreateAsyncNewGroupShouldCreateNewGroup()
        {
            var newFriend = new Friend
            {
                Id = 3,
                RequesterId = 1,
                ReceiverId = 1,
                Status = "Test",
                CreatedAt = DateTime.MaxValue,
                UpdatedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newFriend);

            // aseert
            FreindRepositoryMock.Verify(x => x.Create(It.IsAny<Friend>()), Times.Once);

        }
    }
}