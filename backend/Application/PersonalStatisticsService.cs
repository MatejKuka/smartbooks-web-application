using Application.DTOs;
using Application.Interfaces.repositories;
using Application.Interfaces.services;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application;

public class PersonalStatisticsService : IPersonalStatisticsService
{
    private readonly IValidator<PostPSDTO> _postPSValidator;
    private readonly IPersonalStatisticsRepository _personalStatisticsRepository;
    private readonly ILessonService _lessonService;
    private readonly IMapper _mapper;
    

    public PersonalStatisticsService(
            IPersonalStatisticsRepository repository,
            IValidator<PostPSDTO> postPSValidator,
            IMapper mapper,
            ILessonService lessonService
        )
    {
        _mapper = mapper;
        _personalStatisticsRepository = repository;
        _postPSValidator = postPSValidator;
        _lessonService = lessonService;
    }

    public List<PSExistDTO> GetAllPersonalStatisticsByLessonId(int idLesson)
    {
        var personalStatisticsByLessonId = _personalStatisticsRepository.GetAllPersonalStatisticsByLessonId(idLesson);
        return _mapper.Map<List<PSExistDTO>>(personalStatisticsByLessonId);
    }

    public PSExistDTO CreatePersonalStatistics(PostPSDTO postPsdto)
    {
        var validationOfPostPsDto = _postPSValidator.Validate(postPsdto);
        if(!validationOfPostPsDto.IsValid)
            throw new ValidationException(validationOfPostPsDto.ToString());

        var newPersonalStatistics = _personalStatisticsRepository.CreatePersonalStatistics(_mapper.Map<PersonalStatistics>(postPsdto));
        return _mapper.Map<PSExistDTO>(newPersonalStatistics);
    }

    public PersonalStatistics DeletePersonalStatistics(int idPS)
    {
        return _personalStatisticsRepository.DeletePersonalStatistics(idPS);
    }

    public List<PSExistDTO> GetAllPersonalStatisticsWithLessonsByCourseId(int idCourse)
    {
        List<PersonalStatistics> personalStatisticsWithLessonsList = new List<PersonalStatistics>();
        var lessonListByCourseId = _lessonService.GetAllLessonsByCourseId(idCourse);
        lessonListByCourseId.ForEach(lesson =>
        {
            var personalStatisticsList = _personalStatisticsRepository.GetAllPersonalStatisticsWithLessonByLessonId(lesson.Id);
            personalStatisticsWithLessonsList.AddRange(personalStatisticsList);
        });
        return _mapper.Map<List<PSExistDTO>>(personalStatisticsWithLessonsList);
    }
} 