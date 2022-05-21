using AutoMapper;
using MediatR;
using PlatformService.Data;
using PlatformService.Entities;
using PlatformService.Services.Http;

namespace PlatformService.Features.Platforms.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    private readonly ICommandDataClient _commandDataClient;

    public Handler(AppDbContext db, IMapper mapper, ICommandDataClient commandDataClient)
    {
        _db = db;
        _mapper = mapper;
        _commandDataClient = commandDataClient;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var platform = _mapper.Map<Platform> (request);

        await _db.AddAsync(platform);
        await _db.SaveChangesAsync();

        var response = _mapper.Map<Response>(platform);

        try
        {
            await _commandDataClient.SendPlatformToCommand(response);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
        }


        return response;
    }
}
