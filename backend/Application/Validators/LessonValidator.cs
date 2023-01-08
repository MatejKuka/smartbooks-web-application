using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class PostLessonValidator : AbstractValidator<PostLessonDTO>
{
    public PostLessonValidator()
    {
        RuleFor(l => l.Title).NotEmpty();
        RuleFor(l => l.Content).NotEmpty();
        RuleFor(l => l.CourseId).NotEmpty().GreaterThanOrEqualTo(1);
        //TODO missing validation for courses id´s
    }
}

public class LessonValidator : AbstractValidator<Lesson>
{
    public LessonValidator()
    {
        RuleFor(l => l.Id).GreaterThan(0);
        RuleFor(l => l.Title).NotEmpty();
        RuleFor(l => l.Content).NotEmpty();
    }
}