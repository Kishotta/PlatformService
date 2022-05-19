using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

namespace PlatformService.Features.Platforms.GetById;

public class Handler : IRequestHandler<Query, Response?>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public Handler(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response?> Handle(Query query, CancellationToken cancellationToken)
    {
        var platform = await _db.Platforms.FirstOrDefaultAsync(platform => platform.Id == query.PlatformId);
        return _mapper.Map<Response>(platform);
    }
}
