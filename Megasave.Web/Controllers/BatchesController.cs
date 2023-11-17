using MediatR;
using Megasave.Application.Features.BatchFeatures.Commands;
using Megasave.Application.Features.BatchFeatures.Queries;
using Megasave.Application.Features.CategoryFeatures.Queries;
using Megasave.Application.Features.FileFeatures.Commands;
using Megasave.Application.Features.FileFeatures.Queries;
using Megasave.Application.Features.SupplierFeatures.Queries;
using Megasave.Application.Features.TransactionFeatures.Commands;
using Megasave.Application.Features.TransactionFeatures.Queries;
using Megasave.Domain.DTOs;
using Megasave.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Megasave.Web.Controllers
{
    [Authorize]
    public class BatchesController : Controller
    {
        private readonly IMediator _mediator;

        public BatchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var batches = await _mediator.Send(new GetBatchesRequest());
            return View(batches);
        }

        public async Task<IActionResult> Create()
        {
            var batch = (await _mediator.Send(new CreateBatchCommand
            {
                Batch = new CreateBatchDto()
            }));
            return RedirectToAction("Edit", new { Id = batch.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Create(BatchDto batchDto)
        {
            return View(await _mediator.Send(new UpdateBatchCommand
            {
                BatchDto = batchDto
            }));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _mediator.Send(new GetBatchRequest
            {
                Id = id
            }));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _mediator.Send(new GetBatchRequest
            {
                Id = id
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BatchDto batchDto)
        {
            return View(await _mediator.Send(new UpdateBatchCommand
            {
                BatchDto = batchDto
            }));
        }

        public async Task<IActionResult> GetSuppliers()
        {
            return Ok(await _mediator.Send(new GetSuppliersRequest()));
        }

        public async Task<IActionResult> GetCategory()
        {
            return Ok(await _mediator.Send(new GetCategoriesRequest()));
        }

        public async Task<IActionResult> GetData(Guid batchId)
        {
            return Ok(await _mediator.Send(new GetBatchTransactionsRequest
            {
                Id = batchId
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTransactionDto createTransactionDto)
        {
            return Ok(await _mediator.Send(new CreateTransactionCommand
            {
                transactionDto = createTransactionDto
            }));
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(CreateFileDto createFileDto)
        {
            return Ok(await _mediator.Send(new CreateFileCommand
            {
                File = createFileDto
            }));
        }

        public async Task<FileResult> DownloadFile(Guid id)
        {
            var result = (await _mediator.Send(new GetFileRequest
            {
                Id = id
            }));
            return File(result.Item1, result.Item2, result.Item3);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFile([FromBody] Guid id)
        {
            var response = await _mediator.Send(new DeleteFileCommand
            {
                Id = id
            });
            return Ok(response);
        }

        //[HttpPost]
        public async Task<IActionResult> Submit(BatchDto batchDto)
        {
            batchDto.Status = Status.Pending;
            batchDto.hasStatusChanged = true;
            return RedirectToAction("Details", await _mediator.Send(new UpdateBatchCommand
            {
                BatchDto = batchDto
            }));
        }

        public async Task<IActionResult> Reject(BatchDto batchDto)
        {
            batchDto.Status = Status.Declined;
            batchDto.hasStatusChanged = true;
            return RedirectToAction("Details", await _mediator.Send(new UpdateBatchCommand
            {
                BatchDto = batchDto
            }));
        }

        public async Task<IActionResult> Approve(BatchDto batchDto)
        {
            batchDto.Status = Status.Approved;
            batchDto.hasStatusChanged = true;
            return RedirectToAction("Details", await _mediator.Send(new UpdateBatchCommand
            {
                BatchDto = batchDto
            }));
        }

    }
}
