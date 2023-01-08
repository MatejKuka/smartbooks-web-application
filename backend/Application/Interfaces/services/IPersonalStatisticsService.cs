using Application.DTOs;
using Domain;

namespace Application.Interfaces.services;

public interface IPersonalStatisticsService
{
    public List<PSExistDTO> GetAllPersonalStatisticsByLessonId(int idLesson);
    public PSExistDTO CreatePersonalStatistics(PostPSDTO postPsdto);
    public PersonalStatistics DeletePersonalStatistics(int idPS);

    public List<PSExistDTO> GetAllPersonalStatisticsWithLessonsByCourseId(int idCourse);
}