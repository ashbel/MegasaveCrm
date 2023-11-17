using MediatR;
using Megasave.Application.Features.DepartmentFeatures.Commands;
using Megasave.Application.Features.DepartmentFeatures.Queries;
using Megasave.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Megasave.Web.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var all = await _mediator
                .Send(new GetDepartmentsRequest());
            return View(all);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var Branch = await _mediator.Send(
                new GetDepartmentRequest()
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
        public async Task<IActionResult> Create(CreateDepartmentDto create)
        {
            await _mediator
                .Send(new CreateDepartmentCommand
                {
                    CreateDepartmentDto = create
                });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var Branch = await _mediator.Send(
                new GetDepartmentRequest
                {
                    Id = Id,
                });
            return View(Branch);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentDto update)
        {
            await _mediator
                .Send(new UpdateDepartmentCommand
                {
                    Department = update
                });
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(Guid Id)
        {
            var Branch = await _mediator.Send(
                new GetDepartmentRequest
                {
                    Id = Id,
                });
            return View(Branch);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentDto delete)
        {
            await _mediator
                .Send(new DeleteDepartmentCommand
                {
                    Id = delete.Id
                });
            return RedirectToAction("Index");
        }
    }
}

