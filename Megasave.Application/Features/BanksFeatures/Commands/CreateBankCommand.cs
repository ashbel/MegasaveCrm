using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.BanksFeatures.Commands
{
    public class CreateBankCommand : IRequest<BankDto>
    {
        public CreateBankDto banks { get; set; }
    }

    public class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, BankDto>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public CreateBankCommandHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task<BankDto> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = _mapper.Map<Banks>(request.banks);
            var inserted = await _bankRepository.Add(bank);

            return _mapper.Map<BankDto>(inserted);
        }
    }
}