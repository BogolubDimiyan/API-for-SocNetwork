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
    }
}