using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Hosting;

namespace Megasave.Application.Features.FileFeatures.Queries
{
    public class GetFileRequest : IRequest<(FileStream, string, string)>
    {
        public Guid Id { get; set; }
    }

    public class GetFileRequestHandler : IRequestHandler<GetFileRequest, (FileStream, string, string)>
    {
        private readonly IFileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _env;

        public GetFileRequestHandler(IFileRepository repository, IMapper mapper, IHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<(FileStream, string, string)> Handle(GetFileRequest request, CancellationToken cancellationToken)
        {
            var file = await _repository.GetById(request.Id);
            var path = Path.Combine(_env.ContentRootPath, "Uploads");
            var filePath = Path.Combine(path, file.Name);
            var fileName = file.Description;
            new FileExtensionContentTypeProvider().TryGetContentType(file.Name, out var contentType);
            return (new FileStream(filePath, FileMode.Open), contentType, fileName);
        }
    }
}
