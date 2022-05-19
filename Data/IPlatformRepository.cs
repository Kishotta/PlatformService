using PlatformService.Entities;

namespace PlatformService.Data;

public interface IPlatformRepository
{
    bool SaveChanges();
    Task<bool> SaveChangesAsync();
    IEnumerable<Platform> Find(Specification<Platform> specification);
    Task<IEnumerable<Platform>> FindAsync(Specification<Platform> specification);
    Platform? FindOne(Specification<Platform> specification);
    Task<Platform?> FindOneAsync(Specification<Platform> specification);
    void Create(Platform platform);
    Task CreateAsync(Platform platform);
}
