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
    public class PrivacySettingServiceTest
    {
        private readonly PrivascySettingService service;
        private readonly Mock<IPrivacySettingRepository> prsetRepositoryMock;

        public PrivacySettingServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            prsetRepositoryMock = new Mock<IPrivacySettingRepository>();

            repositoryWrapperMoq.Setup(x => x.Priv)
                .Returns(prsetRepositoryMock.Object);

            service = new PrivascySettingService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullPrivacySetting_ShouldThrownNullArgumentExceprion()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            prsetRepositoryMock.Verify(x => x.Create(It.IsAny<PrivacySetting>()), Times.Never);
        }
    }
}