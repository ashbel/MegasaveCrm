using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Application.Exceptions;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.SupplierFeatures.Commands
{
    public class DeleteSupplierCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;

        public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }


        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _supplierRepository.GetById(request.Id);
            if (toDelete == null)
            {
                throw new NotFoundException(nameof(Supplies), request.Id);
            }
            await _supplierRepository.Delete(toDelete);
            return Unit.Value;
        }
    }
}