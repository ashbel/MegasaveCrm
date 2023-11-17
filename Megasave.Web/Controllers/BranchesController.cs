using MediatR;
using Megasave.Application.Features.BranchFeatures.Commands;
using Megasave.Application.Features.BranchFeatures.Queries;
using Megasave.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Megasave.Web.Controllers
{
    [Authorize]
    public class BranchesController : Controller
    {
        private readonly IMediator _mediator;

        public BranchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var all = await _mediator
                .Send(new GetBranchesRequest());
            return View(all);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var Branch = await _mediator.Send(
                new GetBranchRequest
                {
                    Id = Id,
                });
            return View(Branch);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBranchDto create)
        {
            await _mediator
                .Send(new CreateBranchCommand
                {
                    CreateBranchDto = create
                });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var Branch = await _mediator.Send(
                new GetBranchRequest
                {
                    Id = Id,
                });
            return View(Branch);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BranchDto update)
        {
            await _mediator
                .Send(new UpdateBranchCommand
                {
                    branch = update
                });
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(Guid Id)
        {
            var Branch = await _mediator.Send(
                new GetBranchRequest
                {
                    Id = Id,
                });
            return View(Branch);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BranchDto delete)
        {
            await _mediator
                .Send(new UpdateBranchCommand
                {
                    branch = delete
                });
            return RedirectToAction("Index");
        }
    }
}
