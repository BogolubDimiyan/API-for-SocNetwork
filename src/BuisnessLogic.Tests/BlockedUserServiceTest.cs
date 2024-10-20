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
    public class BlockedUserServiceTest
    {
        private readonly BlockedUserService service;
        private readonly Mock<IBlockedUserRepository> BlockedRepositoryMock;

        public BlockedUserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            BlockedRepositoryMock = new Mock<IBlockedUserRepository>();

            repositoryWrapperMoq.Setup(x => x.Bu)
                .Returns(BlockedRepositoryMock.Object);

            service = new BlockedUserService(repositoryWrapperMoq.Object);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectBlocks))]
        public async Task CreateAsync_NewBlockShouldNotCreateNewBlock(BlockedUser block)
        {
            // arrange
            var newBlock = block;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newBlock));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            BlockedRepositoryMock.Verify(x => x.Create(It.IsAny<BlockedUser>()), Times.Never);

        }

        public static IEnumerable<object[]> GetIncorrectBlocks()
        {
            return new List<object[]>
            {
                new object[] { new BlockedUser { Id = 0, BlockedId = 0, BlockerId = 0, CreatedAt = DateTime.MaxValue, } },
                new object[] { new BlockedUser { Id = 1, BlockedId = 0, BlockerId = 0, CreatedAt = DateTime.MaxValue, } },
                new object[] { new BlockedUser { Id = 0, BlockedId = 1, BlockerId = 0, CreatedAt = DateTime.MaxValue, } },
                new object[] { new BlockedUser { Id = 0, BlockedId = 0, BlockerId = 1, CreatedAt = DateTime.MaxValue, } },

            };
        }

        [Fact]
        public async Task CreateAsyncNewBlockShouldCreateNewBlock()
        {
            var newBlock = new BlockedUser
            {
                Id = 1,
                BlockedId = 1,
                BlockerId = 1,
                CreatedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newBlock);

            // aseert
            BlockedRepositoryMock.Verify(x => x.Create(It.IsAny<BlockedUser>()), Times.Once);
        }
    }
}