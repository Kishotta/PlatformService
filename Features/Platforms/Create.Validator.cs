using FluentValidation;

namespace PlatformService.Features.Platforms.Create;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.Publisher).NotEmpty();
        RuleFor(request => request.Cost).NotEmpty();
    }
}
