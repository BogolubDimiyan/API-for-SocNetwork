using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Tests
{
    public class EventServiceTest
    {
        private readonly EventService service;
        private readonly Mock<IEventRepository> eRepositoryMock;

        public EventServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            eRepositoryMock = new Mock<IEventRepository>();

            repositoryWrapperMoq.Setup(x => x.Ev)
                .Returns(eRepositoryMock.Object);

            service = new EventService(repositoryWrapperMoq.Object);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectEvents))]
        public async Task CreateAsync_NewUserShouldNotCreateNewUser(Event events)
        {
            // arrange
            var newEvent = events;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newEvent));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            eRepositoryMock.Verify(x => x.Create(It.IsAny<Event>()), Times.Never);

        }

        public static IEnumerable<object[]> GetIncorrectEvents()
        {
            return new List<object[]>
            {
                new object[] { new Event { Id = 0, Name = "", Description = "", Location = "", StartTime = DateTime.MaxValue, EndTime = DateTime.MaxValue, CreatedBy = 0, CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue, } },
                new object[] { new Event { Id = 1, Name = "", Description = "", Location = "", StartTime = DateTime.MaxValue, EndTime = DateTime.MaxValue, CreatedBy = 0, CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue, } },
                new object[] { new Event { Id = 0, Name = "Test", Description = "", Location = "", StartTime = DateTime.MaxValue, EndTime = DateTime.MaxValue, CreatedBy = 0, CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue, } },
                new object[] { new Event { Id = 0, Name = "", Description = "Test", Location = "", StartTime = DateTime.MaxValue, EndTime = DateTime.MaxValue, CreatedBy = 0, CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue, } },
                new object[] { new Event { Id = 0, Name = "", Description = "", Location = "Test", StartTime = DateTime.MaxValue, EndTime = DateTime.MaxValue, CreatedBy = 0, CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue, } },
                new object[] { new Event { Id = 0, Name = "", Description = "", Location = "", StartTime = DateTime.MaxValue, EndTime = DateTime.MaxValue, CreatedBy = 1, CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue, } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewEventShouldCreateNewEvent()
        {
            var newEvent = new Event
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Location = "Test",
                StartTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
                CreatedBy = 1,
                CreatedAt = DateTime.MaxValue,
                UpdatedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newEvent);

            // aseert
            eRepositoryMock.Verify(x => x.Create(It.IsAny<Event>()), Times.Once);
        }
    }
}