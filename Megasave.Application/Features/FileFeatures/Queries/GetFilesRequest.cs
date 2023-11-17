using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;

namespace Megasave.Application.Features.FileFeatures.Queries
{
    public class GetFilesRequest : IRequest<List<FileDto>>
    {
    }

    public class GetFilesRequestHandler : IRequestHandler<GetFilesRequest, List<FileDto>>
    {
        private readonly IFileRepository _repository;
        private readonly IMapper _mapper;

        public GetFilesRequestHandler(IFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<FileDto>> Handle(GetFilesRequest request, CancellationToken cancellationToken)
        {
            var file = await _repository.GetAll();
            return _mapper.Map<List<FileDto>>(file);
        }
    }
}
