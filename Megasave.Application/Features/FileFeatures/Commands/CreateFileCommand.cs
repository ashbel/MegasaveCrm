using AutoMapper;
using MediatR;
using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.DTOs;
using Megasave.Domain.Entities;
using Microsoft.Extensions.Hosting;

namespace Megasave.Application.Features.FileFeatures.Commands
{
    public class CreateFileCommand : IRequest<FileDto>
    {
        public CreateFileDto File { get; set; }
    }

    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, FileDto>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _env;
        private readonly IBatchRepository _batchRepository;

        public CreateFileCommandHandler(IMapper mapper, IFileRepository fileRepository, IHostEnvironment env, IBatchRepository batchRepository)
        {
            _mapper = mapper;
            _fileRepository = fileRepository;
            _env = env;
            _batchRepository = batchRepository;
        }


        public async Task<FileDto> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var file = request.File.InputFile;
            try
            {
                if (file.Length > 0)
                {
                    var path = Path.GetFullPath(Path.Combine(_env.ContentRootPath, "Uploads"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    await using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    var file_ = _mapper.Map<Files>(request.File);
                    file_.Name = file.FileName;
                    if (string.IsNullOrEmpty(request.File.Description))
                    {
                        file_.Description = file.FileName;
                    }
                    var inserted = await _fileRepository.Add(file_);
                    var batch = await _batchRepository.GetById(file_.BatchId);
                    if (batch != null)
                    {
                        batch.Name = request.File.DocumentName;
                        await _batchRepository.Update(batch);
                    }
                    return _mapper.Map<FileDto>(inserted);
                }
            }
            catch
            {
                throw new ArgumentNullException("No File");
            }

            return null;
        }
    }
}
