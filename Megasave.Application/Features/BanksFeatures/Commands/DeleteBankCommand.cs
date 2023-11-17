using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.BanksFeatures.Commands
{
    public class DeleteBankCommand : IRequest
    {
        public BankDto Id { get; set; }
    }

    public class DeleteBankCommandHandler : IRequestHandler<DeleteBankCommand>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public DeleteBankCommandHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var bank = _mapper.Map<Banks>(request.Id);
            await _bankRepository.Delete(bank);
            return Unit.Value;
        }
    }
}