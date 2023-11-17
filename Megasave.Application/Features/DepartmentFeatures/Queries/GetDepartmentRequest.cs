using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;

namespace Megasave.Application.Features.DepartmentFeatures.Queries
{
    public class GetDepartmentRequest : IRequest<DepartmentDto>
    {
        public Guid Id { get; set; }
    }

    public class GetDepartmentRequestHandler : IRequestHandler<GetDepartmentRequest, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentsRepository;
        private readonly IMapper _mapper;

        public GetDepartmentRequestHandler(IDepartmentRepository departmentsRepository, IMapper mapper)
        {
            _departmentsRepository = departmentsRepository;
            _mapper = mapper;
        }


        public async Task<DepartmentDto> Handle(GetDepartmentRequest request, CancellationToken cancellationToken)
        {
            var departments = await _departmentsRepository.GetById(request.Id);
            return _mapper.Map<DepartmentDto>(departments);
        }
    }
}