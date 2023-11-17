using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.BranchFeatures.Commands
{
    public class CreateBranchCommand : IRequest<BranchDto>
    {
        public CreateBranchDto CreateBranchDto { get; set; }
    }

    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, BranchDto>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public CreateBranchCommandHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }


        public async Task<BranchDto> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = _mapper.Map<Branches>(request.CreateBranchDto);
            var inserted = await _branchRepository.Add(branch);
            return _mapper.Map<BranchDto>(inserted);
        }
    }
}