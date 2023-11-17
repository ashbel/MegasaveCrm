using Megasave.Application.Contracts.Persistence;
using Megasave.Application.Features.BatchFeatures.Commands;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Megasave.ApplicationUnitTests.FeaturesTest.BatchesTest
{
    public class DeleteBatchCommandHandlerTests
    {
        private readonly Mock<IBatchRepository> _batchRepositoryMock;
        private readonly Mock<IHttpContextAccessor> _contextAccessorMock;
        private readonly Mock<IBatchHistoryRepository> _historyRepositoryMock;
        private readonly DeleteBatchCommandHandler _handler;

        public DeleteBatchCommandHandlerTests(DeleteBatchCommandHandler handler,
            Mock<IBatchHistoryRepository> historyRepositoryMock,
            Mock<IHttpContextAccessor> contextAccessorMock,
            Mock<IBatchRepository> batchRepositoryMock)
        {
            _handler = handler;
            _historyRepositoryMock = historyRepositoryMock;
            _contextAccessorMock = contextAccessorMock;
            _batchRepositoryMock = batchRepositoryMock;
        }



    }
}