using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;

namespace Megasave.Application.Features.DepartmentFeatures.Queries
{
    public class GetDepartmentsRequest : IRequest<List<DepartmentDto>>
    {

    }

    public class GetDepartmentsRequestHandler : IRequestHandler<GetDepartmentsRequest, List<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentsRepository;
        private readonly IMapper _mapper;

        public GetDepartmentsRequestHandler(IDepartmentRepository departmentsRepository, IMapper mapper)
        {
            _departmentsRepository = departmentsRepository;
            _mapper = mapper;
        }


        public async Task<List<DepartmentDto>> Handle(GetDepartmentsRequest request, CancellationToken cancellationToken)
        {
            var departments = await _departmentsRepository.GetAll();
            return _mapper.Map<List<DepartmentDto>>(departments);
        }
    }
}