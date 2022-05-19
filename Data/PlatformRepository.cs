using Microsoft.EntityFrameworkCore;
using PlatformService.Entities;

namespace PlatformService.Data;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(Platform platform)
    {
        if(platform == null)
        {
            throw new ArgumentNullException(nameof(platform));
        }

        _context.Platforms.Add(platform);
    }

    public async Task CreateAsync(Platform platform)
    {
        if(platform == null)
        {
            throw new ArgumentNullException(nameof(platform));
        }

        await _context.Platforms.AddAsync(platform);
    }

     public IEnumerable<Platform> Find(Specification<Platform> specification)
    {
        return _context
            .Platforms
            .Where(specification.ToExpression())
            .ToList();
    }

    public async Task<IEnumerable<Platform>> FindAsync(Specification<Platform> specification)
    {
        return await _context
            .Platforms
            .Where(specification.ToExpression())
            .ToListAsync();
    }

    public Platform? FindOne(Specification<Platform> specification)
    {
        return _context
            .Platforms
            .Where(specification.ToExpression())
            .FirstOrDefault();
    }

    public async Task<Platform?> FindOneAsync(Specification<Platform> specification)
    {
        return await _context
            .Platforms
            .Where(specification.ToExpression())
            .FirstOrDefaultAsync();
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
