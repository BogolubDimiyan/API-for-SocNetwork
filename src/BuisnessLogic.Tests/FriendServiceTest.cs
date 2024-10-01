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
    public class FriendServiceTest
    {
        private readonly FriendService service;
        private readonly Mock<IFriendRepository> eaRepositoryMock;

        public FriendServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            eaRepositoryMock = new Mock<IFriendRepository>();

            repositoryWrapperMoq.Setup(x => x.Friend)
                .Returns(eaRepositoryMock.Object);

            service = new FriendService(repositoryWrapperMoq.Object);
        }
    }
}