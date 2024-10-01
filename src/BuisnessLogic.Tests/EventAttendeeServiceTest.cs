using BusinessLogic.Services;
using Domain.Interfaces;
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
        private readonly Mock<IEventAttendeeRepository> friendRepositoryMock;

        public EventAttendeeServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            friendRepositoryMock = new Mock<IEventAttendeeRepository>();

            repositoryWrapperMoq.Setup(x => x.Ea)
                .Returns(friendRepositoryMock.Object);

            service = new EventAttendeeService(repositoryWrapperMoq.Object);
        }
    }
}