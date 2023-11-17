using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Application.Exceptions;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.BranchFeatures.Commands
{
    public class DeleteBranchCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand>
    {
        private readonly IBranchRepository _branchRepository;

        public DeleteBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }


        public async Task<Unit> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var getOne = await _branchRepository.GetById(request.Id);
            if (getOne == null)
            {
                throw new NotFoundException(nameof(Branches), request.Id);
            }

            await _branchRepository.Delete(getOne);
            return Unit.Value;
        }
    }
}