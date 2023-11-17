using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;
using Megasave.Domain.Enums;

namespace Megasave.Application.Features.BatchFeatures.Commands
{
    public class UpdateBatchCommand : IRequest<BatchDto>
    {
        public BatchDto BatchDto { get; set; }
    }

    public class UpdateBatchCommandHandler : IRequestHandler<UpdateBatchCommand, BatchDto>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IBatchHistoryRepository _batchHistoryRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public UpdateBatchCommandHandler(IBatchRepository batchRepository,
            IMapper mapper,
            ITransactionRepository transactionRepository,
            IFileRepository fileRepository,
            IBatchHistoryRepository batchHistoryRepository,
            IHttpContextAccessor contextAccessor)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _fileRepository = fileRepository;
            _batchHistoryRepository = batchHistoryRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<BatchDto> Handle(UpdateBatchCommand request, CancellationToken cancellationToken)
        {
            var batch = _mapper.Map<Batches>(request.BatchDto);
            var updated = await _batchRepository.Update(batch);
            var batchDto = _mapper.Map<BatchDto>(updated);
            batchDto.FileList = _mapper.Map<List<FileDto>>(await _fileRepository.GetAll(c => c.BatchId == request.BatchDto.Id));
            batchDto.TransactionList = _mapper.Map<List<TransactionDto>>(await _transactionRepository.GetAll(c => c.BatchId == request.BatchDto.Id));
            batchDto.BatchesHistory =
                _mapper.Map<List<BatchHistoryDto>>(
                    await _batchHistoryRepository.GetAll(c => c.BatchesId == request.BatchDto.Id));
            await Log(request);
            return batchDto;
        }


        private async Task Log(UpdateBatchCommand request)
        {
            var value = _contextAccessor.HttpContext?.User?.Identities.FirstOrDefault()
                ?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (request.BatchDto.hasStatusChanged)
            {
                var history = new BatchesHistory()
                {
                    BatchesId = request.BatchDto.Id,
                    UserId = value
                };
                switch (request.BatchDto.Status)
                {
                    case Status.Open:
                        break;
                    case Status.Pending:
                        history.Action = Actions.CreatedBy;
                        break;
                    case Status.Approved:
                        history.Action = Actions.ApprovedBy;
                        break;
                    case Status.Paid:
                        history.Action = Actions.PaidBy;
                        break;
                    case Status.Delivered:
                        history.Action = Actions.ReceivedBy;
                        break;
                    case Status.Declined:
                        history.Action = Actions.RejectedBy;
                        break;
                    case Status.Redo:
                        break;
                    case Status.Draft:
                        break;
                    case Status.PaymentApproved:
                        history.Action = Actions.PaymentApprovedBy;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                await _batchHistoryRepository.Add(history);
            }
        }
    }
}