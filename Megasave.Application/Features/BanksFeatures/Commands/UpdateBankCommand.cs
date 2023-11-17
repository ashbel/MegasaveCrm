using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.BanksFeatures.Commands
{
    public class UpdateBankCommand : IRequest<BankDto>
    {
        public BankDto banks { get; set; }
    }

    public class UpdateBankCommandHandler : IRequestHandler<UpdateBankCommand, BankDto>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public UpdateBankCommandHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task<BankDto> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = _mapper.Map<Banks>(request.banks);
            await _bankRepository.Update(bank);
            return request.banks;
        }
    }
}