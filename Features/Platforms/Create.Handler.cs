using AutoMapper;
using MediatR;
using PlatformService.Data;
using PlatformService.Entities;

namespace PlatformService.Features.Platforms.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public Handler(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var platform = _mapper.Map<Platform> (request);

        await _db.AddAsync(platform);
        await _db.SaveChangesAsync();

        return _mapper.Map<Response>(platform);
    }
}
