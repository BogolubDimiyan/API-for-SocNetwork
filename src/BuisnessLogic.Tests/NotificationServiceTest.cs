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
    public class NotificationServiceTest
    {
        private readonly NotificationService service;
        private readonly Mock<INotificationRepository> notiRepositoryMock;

        public NotificationServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            notiRepositoryMock = new Mock<INotificationRepository>();

            repositoryWrapperMoq.Setup(x => x.Noti)
                .Returns(notiRepositoryMock.Object);

            service = new NotificationService(repositoryWrapperMoq.Object);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsync_NewNotiShouldNotCreateNewNoti(Notification noti)
        {
            // arrange
            var newNoti = noti;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newNoti));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            notiRepositoryMock.Verify(x => x.Create(It.IsAny<Notification>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new Notification { UserId = 0, Message = "", CreatedAt = DateTime.MaxValue } },
                new object[] { new Notification { UserId = 1, Message = "Test", CreatedAt = DateTime.MaxValue } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewNotiShouldCreateNewNoti()
        {
            var newUser = new Notification
            {
                UserId = 1,
                Message = "Test",
                Type = "Test",
                IsRead = true,
                CreatedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newUser);

            // aseert
            notiRepositoryMock.Verify(x => x.Create(It.IsAny<Notification>()), Times.Once);
        }
    }
}