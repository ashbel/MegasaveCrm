using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Linq.Expressions;
using System.Security.Claims;
using Megasave.Application.Contracts.Persistence;
using Megasave.Application.Features.BatchFeatures.Commands;
using Megasave.Application.Profiles;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;
using Megasave.Domain.Enums;

namespace Megasave.ApplicationUnitTests.FeaturesTest.BatchesTest
{
    public class UpdateBatchCommandHandlerTests
    {
        private readonly Mock<IBatchRepository> _batchRepositoryMock;
        private readonly Mock<IHttpContextAccessor> _contextAccessorMock;
        private readonly Mock<IBatchHistoryRepository> _historyRepositoryMock;
        private readonly Mock<UpdateBatchCommandHandler> _handler;
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly Mock<IFileRepository> _fileRepositoryMock;

        public UpdateBatchCommandHandlerTests()
        {
            _batchRepositoryMock = new Mock<IBatchRepository>();
            _contextAccessorMock = new Mock<IHttpContextAccessor>();
            _historyRepositoryMock = new Mock<IBatchHistoryRepository>();
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _fileRepositoryMock = new Mock<IFileRepository>();
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            IMapper mapperMock = new Mapper(configuration);
            _handler = new Mock<UpdateBatchCommandHandler>(
                _batchRepositoryMock.Object,
                mapperMock,
                _transactionRepositoryMock.Object,
                _fileRepositoryMock.Object,
                _historyRepositoryMock.Object,
                _contextAccessorMock.Object);
            Arrange();
        }

        [Fact]
        public async Task Handle_ShouldMapBatchAndUpdateRepository_WhenValidRequest()
        {
            // Arrange
            var updateBatchCommand = new UpdateBatchCommand
            {
                BatchDto = new BatchDto()
                {
                    Id = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    BranchId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    DocumentNumber = "123456",
                    UserId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Updated New Purchase Order",
                    Status = Status.Draft,
                    TransactionList = new List<TransactionDto>()
                {
                    new()
                    {
                        BatchId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                        CategoryId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                        Description = "Item One",
                        Amount = 2.54M,
                        Quantity = 2,
                        Id = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                        SupplierId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    },
                    new()
                    {
                        BatchId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                        CategoryId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                        Description = "Item Two",
                        Amount = 12.50M,
                        Quantity = 2,
                        Id = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DE"),
                        SupplierId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    }
                },
                    Total = 15.04m,
                    Count = 4,
                    FileList = new List<FileDto>(),
                    BatchesHistory = new List<BatchHistoryDto>()
                }
            };

            // Act
            var result = await _handler.Object.Handle(updateBatchCommand, CancellationToken.None);

            // Assert
            _batchRepositoryMock.Verify(r => r.Update(It.IsAny<Batches>()), Times.Once);
            _transactionRepositoryMock.Verify(r => r.GetAll(It.IsAny<Expression<Func<Transactions, bool>>>()), Times.Once);
            _fileRepositoryMock.Verify(r => r.GetAll(It.IsAny<Expression<Func<Files, bool>>>()), Times.Once);
            _historyRepositoryMock.Verify(r => r.GetAll(It.IsAny<Expression<Func<BatchesHistory, bool>>>()), Times.Once);
            _historyRepositoryMock.Verify(r => r.Add(It.IsAny<BatchesHistory>()), Times.Never);
            Assert.Equal("Updated New Purchase Order", result.Name);
            Assert.Equal(new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"), result.Id);
            Assert.Equal(Status.Draft, result.Status);
        }

        [Fact]
        public async Task Handle_ShouldLog_IfStatusHasChanged()
        {
            //Arrange
            var updateBatchCommand = new UpdateBatchCommand
            {
                BatchDto = new BatchDto()
                {
                    Id = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    BranchId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    DocumentNumber = "123456",
                    UserId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Updated New Purchase Order",
                    Status = Status.Draft,
                    TransactionList = new List<TransactionDto>(),
                    FileList = new List<FileDto>(),
                    BatchesHistory = new List<BatchHistoryDto>(),
                    hasStatusChanged = true
                }
            };

            //Act
            var result = await _handler.Object.Handle(updateBatchCommand, CancellationToken.None);

            //Assert
            _historyRepositoryMock.Verify(r => r.Add(It.IsAny<BatchesHistory>()), Times.Once);
        }

        private void Arrange()
        {
            _contextAccessorMock.SetupGet(c => c.HttpContext.User.Identities)
                .Returns(new List<ClaimsIdentity>
                {
                new ClaimsIdentity(new[]
                    { new Claim(ClaimTypes.NameIdentifier, "6B29FC40-CA47-1067-B31D-00DD010662DA") })
                });
            _batchRepositoryMock.Setup(r => r.Update(It.IsAny<Batches>())).ReturnsAsync((Batches batch) => batch);

        }

    }
}