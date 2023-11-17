using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Application.Exceptions;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.CategoryFeatures.Queries
{
    public class GetCategoryRequest : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
    }


    public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var getOne = await _categoryRepository.GetById(request.Id);
            if (getOne == null)
            {
                throw new NotFoundException(nameof(Categories), request.Id);
            }

            return _mapper.Map<CategoryDto>(getOne);
        }
    }
}