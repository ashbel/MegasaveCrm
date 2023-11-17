using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Megasave.Application.Features.BatchFeatures.Queries
{
    public class GetBatchRequest : IRequest<BatchDto>
    {
        public Guid Id { get; set; }
    }

    public class GetBatchRequestHandler : IRequestHandler<GetBatchRequest, BatchDto>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<Users> _userManager;
        private readonly IBatchHistoryRepository _batchHistoryRepository;

        public GetBatchRequestHandler(IBatchRepository batchRepository,
            IMapper mapper,
            ITransactionRepository transactionRepository,
            IFileRepository fileRepository,
            UserManager<Users> userManager, IBatchHistoryRepository batchHistoryRepository)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _fileRepository = fileRepository;
            _userManager = userManager;
            _batchHistoryRepository = batchHistoryRepository;
        }

        public async Task<BatchDto> Handle(GetBatchRequest request, CancellationToken cancellationToken)
        {
            var batch = await _batchRepository.GetById(request.Id);
            var batchDto = _mapper.Map<BatchDto>(batch);
            batchDto.User = (await _userManager.FindByIdAsync(batch.UserId)).FullName;
            batchDto.FileList = _mapper.Map<List<FileDto>>(await _fileRepository.GetAll(c => c.BatchId == request.Id));
            batchDto.TransactionList = _mapper.Map<List<TransactionDto>>(await _transactionRepository.GetAll(c => c.BatchId == request.Id));
            batchDto.BatchesHistory =
                _mapper.Map<List<BatchHistoryDto>>(
                    await _batchHistoryRepository.GetAll(c => c.BatchesId == request.Id));
            return batchDto;
        }
    }
}