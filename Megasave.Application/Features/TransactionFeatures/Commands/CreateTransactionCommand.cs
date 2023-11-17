using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.TransactionFeatures.Commands
{
    public class CreateTransactionCommand : IRequest<TransactionDto>
    {
        public CreateTransactionDto transactionDto { get; set; }
    }


    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper, IBatchRepository batchRepository, IHttpContextAccessor contextAccessor)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _batchRepository = batchRepository;
            _contextAccessor = contextAccessor;
        }


        public async Task<TransactionDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transactions>(request.transactionDto);
            var value = _contextAccessor.HttpContext?.User?.Identities.FirstOrDefault()
                ?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (value != null)
                transaction.User = new Guid(value);
            var inserted = await _transactionRepository.Add(transaction);
            var batch = await _batchRepository.GetById(transaction.BatchId);
            if (batch != null)
            {
                var transactions = await _transactionRepository.GetAll(c => c.BatchId == transaction.BatchId);
                var sum = transactions.Sum(c => c.Amount);
                batch.Total = sum;
                batch.Count = transactions.Count;
                batch.Name = request.transactionDto.DocumentName;
                await _batchRepository.Update(batch);
            }
            return _mapper.Map<TransactionDto>(inserted);
        }
    }
}