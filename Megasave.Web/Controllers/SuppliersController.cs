using MediatR;
using Megasave.Application.Features.SupplierFeatures.Commands;
using Megasave.Application.Features.SupplierFeatures.Queries;
using Megasave.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Megasave.Web.Controllers
{
    [Authorize]
    public class SuppliersController : Controller
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var all = await _mediator
                .Send(new GetSuppliersRequest());
            return View(all);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var supplier = await _mediator.Send(
                new GetSupplierRequest
                {
                    Id = Id,
                });
            return View(supplier);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSupplierDto supplies)
        {
            await _mediator
                .Send(new CreateSupplierCommand
                {
                    Supplies = supplies
                });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var supplier = await _mediator.Send(
                new GetSupplierRequest
                {
                    Id = Id,
                });
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SupplierDto supplies)
        {
            await _mediator
                .Send(new UpdateSupplierCommand
                {
                    supplies = supplies
                });
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(Guid Id)
        {
            var supplier = await _mediator.Send(
                new GetSupplierRequest
                {
                    Id = Id,
                });
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SupplierDto batchDto)
        {
            await _mediator
                .Send(new DeleteSupplierCommand
                {
                    Id = batchDto.Id
                });
            return RedirectToAction("Index");
        }

    }
}
