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

        [Theory]
        [MemberData(nameof(GetIncorrectPrivacy))]
        public async Task CreateAsync_NewUserShouldNotCreateNewUser(PrivacySetting privacy)
        {
            // arrange
            var newprivacy = privacy;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newprivacy));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            prsetRepositoryMock.Verify(x => x.Create(It.IsAny<PrivacySetting>()), Times.Never);

        }

        public static IEnumerable<object[]> GetIncorrectPrivacy()
        {
            return new List<object[]>
            {
                new object[] { new PrivacySetting { UserId = 0, FriendRequests = "", PostVisibility = "", ProfileVisibility= "", UpdatedAt = DateTime.MaxValue } },
                new object[] { new PrivacySetting { UserId = 0, FriendRequests = "Test", PostVisibility = "", ProfileVisibility= "", UpdatedAt = DateTime.MaxValue } },
                new object[] { new PrivacySetting { UserId = 0, FriendRequests = "", PostVisibility = "Test", ProfileVisibility= "", UpdatedAt = DateTime.MaxValue } },
                new object[] { new PrivacySetting { UserId = 0, FriendRequests = "", PostVisibility = "", ProfileVisibility= "Test", UpdatedAt = DateTime.MaxValue } },
                new object[] { new PrivacySetting { UserId = 1, FriendRequests = "", PostVisibility = "", ProfileVisibility= "", UpdatedAt = DateTime.MaxValue } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var privacy = new PrivacySetting
            {
                UserId = 1,
                PostVisibility = "Test",
                ProfileVisibility = "Test",
                UpdatedAt = DateTime.MaxValue
            };

            // act
            await service.Create(privacy);

            // aseert
            prsetRepositoryMock.Verify(x => x.Create(It.IsAny<PrivacySetting>()), Times.Once);
        }
    }
}