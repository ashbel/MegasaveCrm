using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.SupplierFeatures.Commands
{
    public class CreateSupplierCommand : IRequest<SupplierDto>
    {
        public CreateSupplierDto Supplies { get; set; }
    }


    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }


        public async Task<SupplierDto> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Supplies>(request.Supplies);
            var inserted = await _supplierRepository.Add(supplier);

            return _mapper.Map<SupplierDto>(inserted);
        }
    }
}