namespace CvMatcher.Domain.Entities;
public class Cv
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public string ExtractedText { get; set; } = string.Empty;
    public string ParsedData { get; set; } = string.Empty;
    public DateTime UploadedAt { get; set; }
}