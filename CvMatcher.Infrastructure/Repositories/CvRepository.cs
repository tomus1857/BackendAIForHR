using CvMatcher.Domain.Entities;
using CvMatcher.Infrastructure.Persistence;

namespace CvMatcher.Infrastructure.Repositories;
public class CvRepository : ICvRepository
{
    private readonly AppDbContext _context;
    public CvRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task SaveCvAsync(Cv cv)
    {
        _context.Cvs.Add(cv);
        await _context.SaveChangesAsync();
    }
}