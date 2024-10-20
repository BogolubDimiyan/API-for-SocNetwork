using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuisnessLogic.Tests
{
    public class GroupServiceTest
    {
        private readonly GroupService service;
        private readonly Mock<IGroupRepository> GRepositoryMock;

        public GroupServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            GRepositoryMock = new Mock<IGroupRepository>();

            repositoryWrapperMoq.Setup(x => x.G)
                .Returns(GRepositoryMock.Object);

            service = new GroupService(repositoryWrapperMoq.Object);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectGroup))]
        public async Task CreateAsync_NewUserShouldNotCreateNewUser(Domain.Models.Group group)
        {
            // arrange
            var newGroup = group;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newGroup));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            GRepositoryMock.Verify(x => x.Create(It.IsAny<Domain.Models.Group>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectGroup()
        {
            return new List<object[]>
            {
                new object[] { new Domain.Models.Group { Name = "", Description = "", CreatedBy = 0, CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Domain.Models.Group { Name = "Test", Description = "", CreatedBy = 0, CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Domain.Models.Group { Name = "", Description = "Group just for Test, and that's all", CreatedBy = 0, CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
            };
        }
        public async Task CreateAsyncNewGroupShouldCreateNewGroupr()
        {
            var newGroup = new Domain.Models.Group
            {
                Name = "Test",
                Description = "Test",
                CreatedBy = 0,
                CreatedAt = DateTime.MaxValue,
                UpdatedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newGroup);

            // aseert
            GRepositoryMock.Verify(x => x.Create(It.IsAny<Domain.Models.Group>()), Times.Once);

        }
    }
}