using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;

namespace Megasave.Application.Features.TransactionFeatures.Queries
{
    public class GetBatchTransactionsRequest : IRequest<List<TransactionDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetBatchTransactionsRequestHandler : IRequestHandler<GetBatchTransactionsRequest, List<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetBatchTransactionsRequestHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }


        public async Task<List<TransactionDto>> Handle(GetBatchTransactionsRequest request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetAll(c => c.BatchId == request.Id);
            return _mapper.Map<List<TransactionDto>>(transactions);
        }
    }
}