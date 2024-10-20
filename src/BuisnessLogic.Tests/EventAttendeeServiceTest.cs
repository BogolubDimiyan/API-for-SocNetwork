using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Tests
{
    public class EventAttendeeServiceTest
    {
        private readonly EventAttendeeService service;
        private readonly Mock<IEventAttendeeRepository> eaRepositoryMock;

        public EventAttendeeServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            eaRepositoryMock = new Mock<IEventAttendeeRepository>();

            repositoryWrapperMoq.Setup(x => x.Ea)
                .Returns(eaRepositoryMock.Object);

            service = new EventAttendeeService(repositoryWrapperMoq.Object);
        }
        
        [Theory]
        [MemberData(nameof(GetIncorrectEventAttendees))]
        public async Task CreateAsync_NewUserShouldNotCreateNewUser(EventAttendee eventas)
        {
            // arrange
            var newEventa = eventas;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newEventa));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            eaRepositoryMock.Verify(x => x.Create(It.IsAny<EventAttendee>()), Times.Never);

        }

        public static IEnumerable<object[]> GetIncorrectEventAttendees()
        {
            return new List<object[]>
            {
                new object[] { new EventAttendee { Id = 0, EventId = 0, UserId =0, Status = "", JoinedAt = DateTime.MaxValue } },
                new object[] { new EventAttendee { Id = 1, EventId = 0, UserId =0, Status = "", JoinedAt = DateTime.MaxValue } },
                new object[] { new EventAttendee { Id = 0, EventId = 0, UserId =1, Status = "", JoinedAt = DateTime.MaxValue } },
                new object[] { new EventAttendee { Id = 0, EventId = 0, UserId =0, Status = "Test", JoinedAt = DateTime.MaxValue } },
                new object[] { new EventAttendee { Id = 0, EventId = 1, UserId =0, Status = "", JoinedAt = DateTime.MaxValue } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewEventShouldCreateNewEvent()
        {
            var newEventa = new EventAttendee
            {
                Id = 1,
                EventId = 1,
                UserId = 1,
                Status = "Test",
                JoinedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newEventa);

            // aseert
            eaRepositoryMock.Verify(x => x.Create(It.IsAny<EventAttendee>()), Times.Once);
        }
    }
}