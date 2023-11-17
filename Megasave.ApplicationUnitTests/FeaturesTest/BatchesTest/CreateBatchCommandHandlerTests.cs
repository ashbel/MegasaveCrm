using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json;
using System.Security.Claims;
using Megasave.Application.Contracts.Persistence;
using Megasave.Application.Features.BatchFeatures.Commands;
using Megasave.Application.Profiles;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;
using Megasave.Domain.Enums;

namespace Megasave.ApplicationUnitTests.FeaturesTest.BatchesTest
{
    public class CreateBatchCommandHandlerTests
    {
        private readonly Mock<IBatchRepository> _batchRepositoryMock;
        private readonly Mock<IHttpContextAccessor> _contextAccessorMock;
        private readonly Mock<IBatchHistoryRepository> _historyRepositoryMock;
        private readonly CreateBatchCommandHandler _handler;

        public CreateBatchCommandHandlerTests()
        {
            _historyRepositoryMock = new Mock<IBatchHistoryRepository>();
            _batchRepositoryMock = new Mock<IBatchRepository>();
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            IMapper mapperMock = new Mapper(configuration);
            _contextAccessorMock = new Mock<IHttpContextAccessor>();
            _handler = new CreateBatchCommandHandler(
                mapperMock,
                _batchRepositoryMock.Object,
                _contextAccessorMock.Object,
                _historyRepositoryMock.Object);
            Arrange();
        }

        [Fact]
        public async Task Handle_ShouldMapBatchAndAddToRepository_WhenValidRequest()
        {
            // Arrange
            var createBatchDto = new CreateBatchDto();
            var batchDto = new BatchDto()
            {
                BranchId = createBatchDto.BranchId,
                DocumentNumber = createBatchDto.DocumentNumber,
                UserId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                Name = "New Purchase Order",
                Status = Status.Draft,
                Date = createBatchDto.Date
            };

            // Act
            var result = await _handler.Handle(new CreateBatchCommand { Batch = createBatchDto }, CancellationToken.None);

            // Assert
            _batchRepositoryMock.Verify(r => r.Add(It.IsAny<Batches>()), Times.Once);
            var batchDtoStr = JsonConvert.SerializeObject(batchDto);
            var resultStr = JsonConvert.SerializeObject(result);
            Assert.Equal(batchDtoStr, resultStr);
        }

        [Fact]
        public async Task Handle_ShouldSetUserIdToClaimValue_WhenValidUserIdClaimExists()
        {
            // Arrange
            var createBatchDto = new CreateBatchDto();

            // Act
            var result =
                await _handler.Handle(new CreateBatchCommand { Batch = createBatchDto }, CancellationToken.None);

            // Assert
            Assert.Equal(result.UserId, new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"));
        }

        [Fact]
        public async Task Handle_ShouldNotSetUserId_WhenUserIdClaimDoesNotExist()
        {
            // Arrange
            var batchDto = new CreateBatchDto();
            var batch = new Batches();

            // Act
            var result = await _handler.Handle(new CreateBatchCommand { Batch = batchDto }, CancellationToken.None);

            // Assert
            Assert.Null(batch.UserId);
        }

        private void Arrange()
        {
            _contextAccessorMock.SetupGet(c => c.HttpContext.User.Identities)
                .Returns(new List<ClaimsIdentity>
                {
                    new ClaimsIdentity(new[]
                        { new Claim(ClaimTypes.NameIdentifier, "6B29FC40-CA47-1067-B31D-00DD010662DA") })
                });
            _batchRepositoryMock.Setup(r => r.Add(It.IsAny<Batches>())).ReturnsAsync((Batches batch) => batch);
            _historyRepositoryMock.Setup(r => r.Add(It.IsAny<BatchesHistory>())).ReturnsAsync((BatchesHistory batchHistory) => batchHistory);
        }
    }
}
