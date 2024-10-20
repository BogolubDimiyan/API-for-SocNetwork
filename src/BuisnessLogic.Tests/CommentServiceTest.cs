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
    public class CommentServiceTest
    {
        private readonly CommentService service;
        private readonly Mock<ICommentRepository> comRepositoryMock;

        public CommentServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            comRepositoryMock = new Mock<ICommentRepository>();

            repositoryWrapperMoq.Setup(x => x.Com)
                .Returns(comRepositoryMock.Object);

            service = new CommentService(repositoryWrapperMoq.Object);
        }
       
        [Theory]
        [MemberData(nameof(GetIncorrectComments))]
        public async Task CreateAsync_NewCommentShouldNotCreateNewComment(Comment com)
        {
            // arrange
            var newCom = com;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(newCom));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            comRepositoryMock.Verify(x => x.Create(It.IsAny<Comment>()), Times.Never);

        }

        public static IEnumerable<object[]> GetIncorrectComments()
        {
            return new List<object[]>
            {
                new object[] { new Comment { Id = 0, PostId = 0, UserId =0, Content = "", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Comment { Id = 1, PostId = 0, UserId =0, Content = "", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Comment { Id = 0, PostId = 1, UserId =0, Content = "", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Comment { Id = 0, PostId = 0, UserId =1, Content = "", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
                new object[] { new Comment { Id = 0, PostId = 0, UserId =0, Content = "Test", CreatedAt = DateTime.MaxValue, UpdatedAt = DateTime.MaxValue } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewCommentShouldCreateNewComment()
        {
            var newCom = new Comment
            {
                Id = 1,
                PostId = 1,
                UserId = 1,
                Content = "Test",
                CreatedAt = DateTime.MaxValue,
                UpdatedAt = DateTime.MaxValue
            };

            // act
            await service.Create(newCom);

            // aseert
            comRepositoryMock.Verify(x => x.Create(It.IsAny<Comment>()), Times.Once);
        }
    }
}