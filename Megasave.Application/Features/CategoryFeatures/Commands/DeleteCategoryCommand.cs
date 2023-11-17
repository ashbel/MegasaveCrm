using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Application.Exceptions;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.CategoryFeatures.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }


    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _categoryRepository.GetById(request.Id);
            if (toDelete == null)
            {
                throw new NotFoundException(nameof(Categories), request.Id);
            }

            await _categoryRepository.Delete(toDelete);
            return Unit.Value;
        }
    }
}