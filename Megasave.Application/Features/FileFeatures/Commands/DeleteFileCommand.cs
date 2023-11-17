using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Microsoft.Extensions.Hosting;

namespace Megasave.Application.Features.FileFeatures.Commands
{
    public class DeleteFileCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, bool>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _env;

        public DeleteFileCommandHandler(IFileRepository fileRepository, IMapper mapper, IHostEnvironment env)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<bool> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetById(request.Id);
            if (file == null) return false;
            var path = Path.Combine(_env.ContentRootPath, "Uploads");
            var filePath = Path.Combine(path, file.Name);
            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) return false;
            fileInfo.Delete();
            await _fileRepository.Delete(file);
            return true;
        }
    }
}
