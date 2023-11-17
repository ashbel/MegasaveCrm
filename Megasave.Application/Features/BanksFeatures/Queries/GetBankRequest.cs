using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;

namespace Megasave.Application.Features.BanksFeatures.Queries
{
    public class GetBankRequest : IRequest<BankDto>
    {
        public Guid Id { get; set; }
    }


    public class GetBankRequestHandler : IRequestHandler<GetBankRequest, BankDto>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public GetBankRequestHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }


        public async Task<BankDto> Handle(GetBankRequest request, CancellationToken cancellationToken)
        {
            var bank = await _bankRepository.GetById(request.Id);
            return _mapper.Map<BankDto>(bank);
        }
    }
}