using Application.Validators;
using Domain;
using FluentValidation.TestHelper;

namespace UnitTests;

public class UnitTest1
{
    private readonly CourseValidator _courseValidator;

    
    public UnitTest1()
    {
        _courseValidator = new CourseValidator();
    }

    [Theory]
    [InlineData(16, "Biology")]
    [InlineData(45, "Geography")]
    [InlineData(1, "History")]
    public void Should_return_validated_object(int id, string title)
    {
        var model = new Course { Id = id, Title = title} ;
        var result = _courseValidator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(course => course.Title);
        result.ShouldNotHaveValidationErrorFor(course => course.Id);
    }
    
    [Theory]
    [InlineData(16, "")]
    [InlineData(0, "Geography")]
    [InlineData(-1, "History")]
    public void Should_return_not_validated_object(int id, string title)
    {
        var model = new Course { Id = id, Title = title} ;
        var result = _courseValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(course => course.Title);
        result.ShouldHaveValidationErrorFor(course => course.Id);
    }
}