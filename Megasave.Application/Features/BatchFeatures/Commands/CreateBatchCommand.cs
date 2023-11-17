using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.BatchFeatures.Commands
{
    public class CreateBatchCommand : IRequest<BatchDto>
    {
        public CreateBatchDto Batch { get; set; }
    }

    public class CreateBatchCommandHandler : IRequestHandler<CreateBatchCommand, BatchDto>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IBatchHistoryRepository _batchHistoryRepository;

        public CreateBatchCommandHandler(IMapper mapper, IBatchRepository batchRepository, IHttpContextAccessor contextAccessor, IBatchHistoryRepository batchHistoryRepository)
        {
            _mapper = mapper;
            _batchRepository = batchRepository;
            _contextAccessor = contextAccessor;
            _batchHistoryRepository = batchHistoryRepository;
        }


        public async Task<BatchDto> Handle(CreateBatchCommand request, CancellationToken cancellationToken)
        {
            var batch = _mapper.Map<Batches>(request.Batch);
            var value = _contextAccessor.HttpContext?.User?.Identities.FirstOrDefault()
                ?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (value != null)
                batch.UserId = value;
            var inserted = await _batchRepository.Add(batch);
            return _mapper.Map<BatchDto>(inserted);
        }
    }
}