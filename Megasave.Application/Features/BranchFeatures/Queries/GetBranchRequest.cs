using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Application.Exceptions;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.BranchFeatures.Queries
{
    public class GetBranchRequest : IRequest<BranchDto>
    {
        public Guid Id { get; set; }
    }

    public class GetBranchRequestHandler : IRequestHandler<GetBranchRequest, BranchDto>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public GetBranchRequestHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }


        public async Task<BranchDto> Handle(GetBranchRequest request, CancellationToken cancellationToken)
        {
            var getOne = await _branchRepository.GetById(request.Id);
            if (getOne == null)
            {
                throw new NotFoundException(nameof(Branches), request.Id);
            }

            return _mapper.Map<BranchDto>(getOne);
        }
    }
}