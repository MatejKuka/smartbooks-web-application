using Domain;

namespace Application.Interfaces.repositories;

public interface IPersonalStatisticsRepository
{
    public List<PersonalStatistics> GetAllPersonalStatisticsByLessonId(int idLesson);
    public List<PersonalStatistics> GetAllPersonalStatisticsWithLessonByLessonId(int idLesson);
    public PersonalStatistics CreatePersonalStatistics(PersonalStatistics personalStatistics);
    public PersonalStatistics DeletePersonalStatistics(int idPS);
}