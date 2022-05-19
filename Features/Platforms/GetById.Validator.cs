using FluentValidation;

namespace PlatformService.Features.Platforms.GetById;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(query => query.PlatformId).NotEmpty();
    }
}
