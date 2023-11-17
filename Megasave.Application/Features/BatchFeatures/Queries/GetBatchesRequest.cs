using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Megasave.Application.Features.BatchFeatures.Queries
{
    public class GetBatchesRequest : IRequest<List<BatchDto>>
    {

    }

    public class GetBatchesRequestHandler : IRequestHandler<GetBatchesRequest, List<BatchDto>>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly UserManager<Users> _userManager;
        private readonly IMapper _mapper;

        public GetBatchesRequestHandler(IBatchRepository batchRepository, IMapper mapper, UserManager<Users> userManager)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<BatchDto>> Handle(GetBatchesRequest request, CancellationToken cancellationToken)
        {
            var batches = _mapper.Map<List<BatchDto>>(await _batchRepository.GetAll());
            foreach (var batch in batches)
            {
                batch.User = (await _userManager.FindByIdAsync(batch.UserId.ToString())).FullName;
            }
            return batches.ToList();
        }
    }
}