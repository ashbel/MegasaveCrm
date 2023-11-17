using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;

namespace Megasave.Application.Features.BanksFeatures.Queries
{
    public class GetBanksRequest : IRequest<List<BankDto>>
    {

    }

    public class GetBanksRequestHandler : IRequestHandler<GetBanksRequest, List<BankDto>>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public GetBanksRequestHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }


        public async Task<List<BankDto>> Handle(GetBanksRequest request, CancellationToken cancellationToken)
        {
            var banks = await _bankRepository.GetAll();

            return _mapper.Map<List<BankDto>>(banks);
        }
    }
}