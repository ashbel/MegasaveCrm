using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.DepartmentFeatures.Commands
{
    public class UpdateDepartmentCommand : IRequest<DepartmentDto>
    {
        public DepartmentDto Department { get; set; }
    }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentDto>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<DepartmentDto> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Departments>(request.Department);
            var updated = await _repository.Update(department);
            return _mapper.Map<DepartmentDto>(updated);
        }
    }
}