using FluentValidation;
using Application.DTOs;
using Domain;

namespace Application.Validators;

public class PostCourseValidator : AbstractValidator<PostCourseDTO>
{
    public PostCourseValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
    }
}

public class CourseValidator : AbstractValidator<Course>
{
    public CourseValidator()
    {
        RuleFor(c => c.Id).GreaterThan(0);
        RuleFor(c => c.Title).NotEmpty();
    }
}