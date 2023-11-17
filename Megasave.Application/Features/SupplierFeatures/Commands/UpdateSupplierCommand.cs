using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.SupplierFeatures.Commands
{
    public class UpdateSupplierCommand : IRequest<SupplierDto>
    {
        public SupplierDto supplies { get; set; }
    }

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<SupplierDto> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Supplies>(request.supplies);
            var updated = await _supplierRepository.Update(supplier);

            return _mapper.Map<SupplierDto>(updated);
        }
    }
}