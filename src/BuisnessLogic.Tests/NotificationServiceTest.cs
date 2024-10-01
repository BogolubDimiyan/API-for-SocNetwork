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
        
        [Fact]
        public async Task CreateAsync_NullNotification_ShouldThrownNullArgumentExceprion()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            notiRepositoryMock.Verify(x => x.Create(It.IsAny<Notification>()), Times.Never);
        }
    }
}