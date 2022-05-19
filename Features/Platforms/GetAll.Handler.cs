using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

namespace PlatformService.Features.Platforms.GetAll;

public class Handler : IRequestHandler<Query, IEnumerable<Response>>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public Handler(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Response>> Handle(Query query, CancellationToken cancellationToken)
    {
        var platforms = await _db.Platforms.ToListAsync();
        return _mapper.Map<IEnumerable<Response>>(platforms);
    }
}
