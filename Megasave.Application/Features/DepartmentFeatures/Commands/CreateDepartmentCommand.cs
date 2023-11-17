using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;

namespace Megasave.Application.Features.DepartmentFeatures.Commands
{
    public class CreateDepartmentCommand : IRequest<DepartmentDto>
    {
        public CreateDepartmentDto CreateDepartmentDto { get; set; }
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, DepartmentDto>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<DepartmentDto> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Departments>(request.CreateDepartmentDto);
            var inserted = await _repository.Add(department);
            return _mapper.Map<DepartmentDto>(inserted);
        }
    }
}