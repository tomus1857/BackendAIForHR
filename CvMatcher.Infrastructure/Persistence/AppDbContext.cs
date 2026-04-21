using CvMatcher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace CvMatcher.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cv> Cvs { get; set; }
}