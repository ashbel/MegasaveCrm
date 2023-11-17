using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Application.Exceptions;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.SupplierFeatures.Queries
{
    public class GetSupplierRequest : IRequest<SupplierDto>
    {
        public Guid Id { get; set; }
    }

    public class GetSupplierRequestHandler : IRequestHandler<GetSupplierRequest, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierRequestHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }


        public async Task<SupplierDto> Handle(GetSupplierRequest request, CancellationToken cancellationToken)
        {
            var getOne = await _supplierRepository.GetById(request.Id);
            if (getOne == null)
            {
                throw new NotFoundException(nameof(Supplies), request.Id);
            }

            return _mapper.Map<SupplierDto>(getOne);
        }
    }
}