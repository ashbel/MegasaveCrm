using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;

namespace Megasave.Application.Features.SupplierFeatures.Queries
{
    public class GetSuppliersRequest : IRequest<List<SupplierDto>>
    {

    }

    public class GetSuppliersRequestHandler : IRequestHandler<GetSuppliersRequest, List<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSuppliersRequestHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<List<SupplierDto>> Handle(GetSuppliersRequest request, CancellationToken cancellationToken)
        {
            var all = await _supplierRepository.GetAll();
            return _mapper.Map<List<SupplierDto>>(all);
        }
    }
}