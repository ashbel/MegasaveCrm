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
    public class GetBatchesRequestTests
    {
        private readonly Mock<IBatchRepository> _batchRepositoryMock;
        private readonly GetBatchesRequestHandler _handler;
        private readonly Mock<UserManager<Users>> _userManager;

        public GetBatchesRequestTests()
        {
            _userManager = new Mock<UserManager<Users>>(
                Mock.Of<IUserStore<Users>>(), null, null, null, null, null, null, null, null);
            _batchRepositoryMock = new Mock<IBatchRepository>();
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            IMapper mapperMock = new Mapper(configuration);
            _handler = new GetBatchesRequestHandler(
                _batchRepositoryMock.Object,
                mapperMock,
                _userManager.Object);

            Arrange();
        }

        [Fact]
        public async Task Handle_GetBatchesRequest_WhenValidRequest()
        {
            //Arrange
            var getBatchesRequest = new GetBatchesRequest();

            //Act
            var result = await _handler.Handle(getBatchesRequest, CancellationToken.None);

            //Assert
            Assert.IsType<List<BatchDto>>(result);
        }

        private void Arrange()
        {
            var batches = new List<Batches>()
        {
            new Batches()
            {
                Id = Guid.NewGuid(),
                BranchId = Guid.NewGuid(),
                DocumentNumber = "100001",
                UserId = new string("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                Name = "Purchase Order One",
                Status = Status.Draft,
                Date = DateTime.Now.AddDays(-2)
            },
            new Batches()
            {
                Id = Guid.NewGuid(),
                BranchId = Guid.NewGuid(),
                DocumentNumber = "100002",
                UserId = new string("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                Name = "Purchase Order Two",
                Status = Status.Draft,
                Date = DateTime.Now.AddDays(-1)
            },
            new Batches()
            {
                Id = Guid.NewGuid(),
                BranchId = Guid.NewGuid(),
                DocumentNumber = "100003",
                UserId = new string("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                Name = "Purchase Order Three",
                Status = Status.Draft,
                Date = DateTime.Now
            }
        };
            var user = new Users()
            {
                Id = new string("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                BranchId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                FullName = "Mock User",
                FirstName = "Mock",
                LastName = "User",
            };

            _batchRepositoryMock.Setup(r => r.GetAll()).ReturnsAsync(batches);
            _userManager.Setup(r => r.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
        }
    }
}