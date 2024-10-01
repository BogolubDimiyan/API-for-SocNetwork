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
    public class BlockedUserServiceTest
    {
        private readonly BlockedUserService service;
        private readonly Mock<IBlockedUserRepository> friendRepositoryMock;

        public BlockedUserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            friendRepositoryMock = new Mock<IBlockedUserRepository>();

            repositoryWrapperMoq.Setup(x => x.Bu)
                .Returns(friendRepositoryMock.Object);

            service = new BlockedUserService(repositoryWrapperMoq.Object);
        }
    }
}