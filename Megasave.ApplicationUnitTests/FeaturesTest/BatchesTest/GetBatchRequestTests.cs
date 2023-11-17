using AutoMapper;
using Megasave.Application.Contracts.Persistence;
using Megasave.Application.Features.BatchFeatures.Queries;
using Megasave.Application.Profiles;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;
using Megasave.Domain.Enums;
using Megasave.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace Megasave.ApplicationUnitTests.FeaturesTest.BatchesTest
{
    public class GetBatchRequestTests
    {
        private readonly Mock<IBatchRepository> _batchRepositoryMock;
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly Mock<IFileRepository> _fileRepositoryMock;
        private readonly Mock<UserManager<Users>> _userManagerMock;
        private readonly Mock<IBatchHistoryRepository> _batchHistoryRepositoryMock;
        private readonly GetBatchRequestHandler _handler;
        private List<Batches> _batches = new();

        public GetBatchRequestTests()
        {
            _batchRepositoryMock = new Mock<IBatchRepository>();
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _fileRepositoryMock = new Mock<IFileRepository>();
            _batchHistoryRepositoryMock = new Mock<IBatchHistoryRepository>();
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            IMapper mapperMock = new Mapper(configuration);
            _userManagerMock = new Mock<UserManager<Users>>(
                Mock.Of<IUserStore<Users>>(), null, null, null, null, null, null, null, null);
            _batchHistoryRepositoryMock = new Mock<IBatchHistoryRepository>();
            _handler = new GetBatchRequestHandler(
                _batchRepositoryMock.Object,
                mapperMock,
                _transactionRepositoryMock.Object,
                _fileRepositoryMock.Object,
                _userManagerMock.Object,
                _batchHistoryRepositoryMock.Object
                );
            Arrange();
        }

        [Fact]
        public async Task Handle_GetBatchRequest_WhenValidRequest()
        {
            //Arrange
            var getBatchRequest = new GetBatchRequest()
            {
                Id = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DC")
            };

            //Act
            var result = await _handler.Handle(getBatchRequest, CancellationToken.None);

            //Assert
            Assert.IsType<BatchDto>(result);
            Assert.Equal(_batches[0].Id, result.Id);
        }


        private void Arrange()
        {
            _batches.Add(
                new Batches()
                {
                    Id = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DC"),
                    BranchId = Guid.NewGuid(),
                    DocumentNumber = "100001",
                    UserId = new string("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Purchase Order One",
                    Status = Status.Draft,
                    Date = DateTime.Now.AddDays(-2)
                });
            _batches.Add(new Batches()
            {
                Id = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                BranchId = Guid.NewGuid(),
                DocumentNumber = "100002",
                UserId = new string("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                Name = "Purchase Order Two",
                Status = Status.Draft,
                Date = DateTime.Now.AddDays(-1)
            });
            _batches.Add(new Batches()
            {
                Id = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DB"),
                BranchId = Guid.NewGuid(),
                DocumentNumber = "100003",
                UserId = new string("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                Name = "Purchase Order Three",
                Status = Status.Draft,
                Date = DateTime.Now
            }
            );
            var user = new Users()
            {
                Id = new string("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                BranchId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                FullName = "Mock User",
                FirstName = "Mock",
                LastName = "User",
            };

            _batchRepositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(_batches[0]);
            _userManagerMock.Setup(r => r.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
        }
    }
}