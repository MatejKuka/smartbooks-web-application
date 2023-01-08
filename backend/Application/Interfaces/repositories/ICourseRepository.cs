using Application.DTOs;
using Domain;

namespace Application.Interfaces.repositories;

public interface ICourseRepository
{
    public List<Course> GetAllCoursesWithoutLessons();
    public Course CreateNewCourse(Course course);
    public Course DeleteCourse(int idCourse);
}