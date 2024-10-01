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
    public class MessageServiceTest
    {
        private readonly MessageService service;
        private readonly Mock<IMessageRepository> messRepositoryMock;

        public MessageServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            messRepositoryMock = new Mock<IMessageRepository>();

            repositoryWrapperMoq.Setup(x => x.Message)
                .Returns(messRepositoryMock.Object);

            service = new MessageService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullMessage_ShouldThrownNullArgumentExceprion()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            messRepositoryMock.Verify(x => x.Create(It.IsAny<Message>()), Times.Never);
        }
    }
}