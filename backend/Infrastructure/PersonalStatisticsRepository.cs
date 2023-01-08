using Application.Interfaces.repositories;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class PersonalStatisticsRepository : IPersonalStatisticsRepository
{
    private readonly DatabaseContext _context;

    public PersonalStatisticsRepository(DatabaseContext context)
    {
        _context = context;
    }

    public List<PersonalStatistics> GetAllPersonalStatisticsByLessonId(int idLesson)
    {
        return _context.PersonalStatisticsTable.ToList().FindAll(ps => ps.Id == idLesson);
    }

    public PersonalStatistics CreatePersonalStatistics(PersonalStatistics personalStatistics)
    {
        _context.PersonalStatisticsTable.Add(personalStatistics);
        _context.SaveChanges();
        return personalStatistics;
    }

    public PersonalStatistics DeletePersonalStatistics(int idPS)
    {
        var personalStatisticsToDelete = _context.PersonalStatisticsTable.Find(idPS) ?? throw new KeyNotFoundException();
        _context.PersonalStatisticsTable.Remove(personalStatisticsToDelete);
        _context.SaveChanges();
        return personalStatisticsToDelete;
    }

    public List<PersonalStatistics> GetAllPersonalStatisticsWithLessonByLessonId(int idLesson)
    {
        return _context.PersonalStatisticsTable.Include("lesson").ToList().FindAll(ps => ps.Id == idLesson);
    }
}