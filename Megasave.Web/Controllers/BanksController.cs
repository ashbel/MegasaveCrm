using MediatR;
using Megasave.Application.Features.BanksFeatures.Commands;
using Megasave.Application.Features.BanksFeatures.Queries;
using Megasave.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Megasave.Web.Controllers
{
    [Authorize]
    public class BanksController : Controller
    {
        private readonly IMediator _mediator;

        public BanksController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IActionResult> Index()
        {
            var banks = await _mediator
                .Send(new GetBanksRequest());
            return View(banks);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBankDto banks)
        {
            await _mediator
                .Send(new CreateBankCommand
                {
                    banks = banks
                });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var Branch = await _mediator.Send(
                new GetBankRequest
                {
                    Id = Id,
                });
            return View(Branch);
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var Branch = await _mediator.Send(
                new GetBankRequest
                {
                    Id = Id,
                });
            return View(Branch);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BankDto update)
        {
            await _mediator
                .Send(new UpdateBankCommand
                {
                    banks = update
                });
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(Guid Id)
        {
            var Branch = await _mediator.Send(
                new GetBankRequest
                {
                    Id = Id,
                });
            return View(Branch);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BankDto delete)
        {
            await _mediator
                .Send(new DeleteBankCommand
                {
                    Id = delete
                });
            return RedirectToAction("Index");
        }
    }
}
