using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.CategoryFeatures.Commands
{
    public class UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public CategoryDto categories { get; set; }
    }


    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Categories>(request.categories);
            await _categoryRepository.Update(category);

            return request.categories;
        }
    }
}