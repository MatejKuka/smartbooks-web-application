using Application.DTOs;
using Application.Interfaces.repositories;
using Application.Interfaces.services;
using AutoMapper;
using Domain;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class LessonService : ILessonService
{
    private readonly IValidator<PostLessonDTO> _postLessonValidator;
    //private readonly IValidator<Lesson> _lessonValidator;
    private readonly ILessonRepository _lessonRepository;
    private readonly IMapper _mapper;
    public LessonService(
        ILessonRepository repository,
        IValidator<PostLessonDTO> postLessonValidator,
        //IValidator<Lesson> lessonValidator,
        IMapper mapper
        )
    {
        _mapper = mapper;
        _lessonRepository = repository;
        //_lessonValidator = lessonValidator;
        _postLessonValidator = postLessonValidator;
    }

    public List<LessonExistDTO> GetAllLessonsByCourseId(int idCourse)
    {
        var lessonListByCourseId = _lessonRepository.GetAllLessonsByCourseId(idCourse);
        return _mapper.Map<List<LessonExistDTO>>(lessonListByCourseId);
    }

    public LessonExistDTO CreateLesson(PostLessonDTO postLessonDto)
    {
        var validationOfPostLessonDto = _postLessonValidator.Validate(postLessonDto);
        if(!validationOfPostLessonDto.IsValid)
            throw new ValidationException(validationOfPostLessonDto.ToString());

        var newLesson = _lessonRepository.CreateLesson(_mapper.Map<Lesson>(postLessonDto));
        return _mapper.Map<LessonExistDTO>(newLesson);
    }

    public Lesson DeleteLesson(int idLesson)
    {
        return _lessonRepository.DeleteLesson(idLesson);
    }
    
    
}