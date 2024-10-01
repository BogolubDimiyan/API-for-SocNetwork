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
    }
}