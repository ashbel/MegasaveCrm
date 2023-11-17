using MediatR;
using Megasave.Application.Features.CategoryFeatures.Commands;
using Megasave.Application.Features.CategoryFeatures.Queries;
using Megasave.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Megasave.Web.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var all = await _mediator
                .Send(new GetCategoriesRequest());
            return View(all);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var Category = await _mediator.Send(
                new GetCategoryRequest
                {
                    Id = Id,
                });
            return View(Category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto create)
        {
            await _mediator
                .Send(new CreateCategoryCommand
                {
                    categories = create
                });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var Category = await _mediator.Send(
                new GetCategoryRequest
                {
                    Id = Id,
                });
            return View(Category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDto update)
        {
            await _mediator
                .Send(new UpdateCategoryCommand
                {
                    categories = update
                });
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(Guid Id)
        {
            var Category = await _mediator.Send(
                new GetCategoryRequest
                {
                    Id = Id,
                });
            return View(Category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDto delete)
        {
            await _mediator
                .Send(new UpdateCategoryCommand
                {
                    categories = delete
                });
            return RedirectToAction("Index");
        }
    }
}
