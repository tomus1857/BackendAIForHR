using CvMatcher.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CvMatcher.Application.Features.CvParsing.Commands;
public class UploadAndParseCvCommand : IRequest<UploadAndParseCvResponse>
{
    public IFormFile File { get; }

    public UploadAndParseCvCommand(IFormFile file)
    {
        File = file;
    }
}

public class UploadAndParseCvCommandHandler : IRequestHandler<UploadAndParseCvCommand, UploadAndParseCvResponse>
{
    private readonly ICvRepository _cvRepository;
    public UploadAndParseCvCommandHandler(ICvRepository cvRepository)
                                          //ICvParserService cvParserService)
    {
        _cvRepository = cvRepository;
        //_cvParserService = cvParserService;
    }
    public async Task<UploadAndParseCvResponse> Handle(UploadAndParseCvCommand request, CancellationToken cancellationToken)
    {
        // string extractedText = await _cvParserService.ExtractTextAsync(request.File);
        // var parsedData = await _cvParserService.ParseCvAsync(extractedText);
        var cv = new Cv
        {
            Id = Guid.NewGuid(),
            FileName = request.File.FileName,
            ContentType = request.File.ContentType,
            //ExtractedText = extractedText,
            //ParsedData = parsedData,
            UploadedAt = DateTime.UtcNow
        };
        await _cvRepository.SaveCvAsync(cv);

        return new UploadAndParseCvResponse
        {
            IsSuccess = true,
            CvId = cv.Id
        };
    }
}
