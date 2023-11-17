using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.BranchFeatures.Commands
{
    public class UpdateBranchCommand : IRequest<BranchDto>
    {
        public BranchDto branch { get; set; }
    }


    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, BranchDto>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public UpdateBranchCommandHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }


        public async Task<BranchDto> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = _mapper.Map<Branches>(request.branch);
            var inserted = await _branchRepository.Update(branch);
            return _mapper.Map<BranchDto>(inserted);
        }
    }
}