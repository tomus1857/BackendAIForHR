using Microsoft.AspNetCore.Http;
public interface ICvParserService
{
    Task<string> ParseCvAsync(string extractedText);
    Task<string> ExtractTextAsync(IFormFile file);
}