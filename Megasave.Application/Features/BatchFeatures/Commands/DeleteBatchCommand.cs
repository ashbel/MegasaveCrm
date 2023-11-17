using MediatR;

namespace Megasave.Application.Features.BatchFeatures.Commands
{
    public class DeleteBatchCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteBatchCommandHandler : IRequestHandler<DeleteBatchCommand>
    {
        public Task<Unit> Handle(DeleteBatchCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}