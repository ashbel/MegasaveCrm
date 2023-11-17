using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;

namespace Megasave.Application.Features.CategoryFeatures.Queries
{
    public class GetCategoriesRequest : IRequest<List<CategoryDto>>
    {

    }


    public class GetCategoriesRequestHandler : IRequestHandler<GetCategoriesRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<List<CategoryDto>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var all = await _categoryRepository.GetAll();

            return _mapper.Map<List<CategoryDto>>(all);
        }
    }
}