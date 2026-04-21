using CvMatcher.Domain.Entities;
public interface ICvRepository
{
    Task SaveCvAsync(Cv cv);
}