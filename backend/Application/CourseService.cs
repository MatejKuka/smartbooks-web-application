using Application.DTOs;
using Application.Interfaces.repositories;
using Application.Interfaces.services;
using AutoMapper;
using Domain;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class CourseService : ICourseService
{
    private readonly IValidator<PostCourseDTO> _postCourseValidator;
    //private readonly IValidator<Course> _courseValidator;
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseService(
        ICourseRepository repository,
        IValidator<PostCourseDTO> postCourseValidator,
        //IValidator<Course> courseValidator,
        IMapper mapper
    )
    {
        _mapper = mapper;
        _courseRepository = repository;
        //_courseValidator = courseValidator;
        _postCourseValidator = postCourseValidator;
    }


    public List<CourseExistDTO> GetAllCoursesWithoutLessons()
    {
        var coursesList = _courseRepository.GetAllCoursesWithoutLessons();
        return _mapper.Map<List<CourseExistDTO>>(coursesList);
    }

    public CourseExistDTO CreateNewCourse(PostCourseDTO postCourseDto)
    {
        var validationOfPostCourseDto = _postCourseValidator.Validate(postCourseDto);
        if(!validationOfPostCourseDto.IsValid)
            throw new ValidationException(validationOfPostCourseDto.ToString());

        var newCourse = _courseRepository.CreateNewCourse(_mapper.Map<Course>(postCourseDto));
        return _mapper.Map<CourseExistDTO>(newCourse);
    }

    public Course DeleteCourse(int idCourse)
    {
        return _courseRepository.DeleteCourse(idCourse);
    }
}