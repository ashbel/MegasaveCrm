using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;

namespace Megasave.Application.Features.BranchFeatures.Queries
{
    public class GetBranchesRequest : IRequest<List<BranchDto>>
    {

    }

    public class GetBranchesRequestHandler : IRequestHandler<GetBranchesRequest, List<BranchDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public GetBranchesRequestHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<List<BranchDto>> Handle(GetBranchesRequest request, CancellationToken cancellationToken)
        {
            var all = await _branchRepository.GetAll();
            return _mapper.Map<List<BranchDto>>(all.ToList());
        }
    }
}