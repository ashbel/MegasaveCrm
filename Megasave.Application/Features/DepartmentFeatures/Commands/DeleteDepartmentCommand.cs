using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;

namespace Megasave.Application.Features.DepartmentFeatures.Commands
{
    public class DeleteDepartmentCommand : IRequest
    {
        public Guid Id { get; set; }
    }


    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DeleteDepartmentCommandHandler(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetById(request.Id);
            await _repository.Delete(department);

            return Unit.Value;
        }
    }
}