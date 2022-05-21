using PlatformService.Features.Platforms.Create;

namespace PlatformService.Services.Http;

public interface ICommandDataClient
{
    Task SendPlatformToCommand(Response platform);
}
