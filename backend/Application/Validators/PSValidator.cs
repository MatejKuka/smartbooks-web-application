using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class PostPSValidator : AbstractValidator<PostPSDTO>
{
    public PostPSValidator()
    {
        RuleFor(ps => ps.Progress).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(ps => ps.Score).NotEmpty().GreaterThanOrEqualTo(0);
    }
}