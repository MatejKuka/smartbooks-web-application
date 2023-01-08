using Application.DTOs;
using Domain;

namespace Application.Interfaces.services;

public interface ICourseService
{
    public List<CourseExistDTO> GetAllCoursesWithoutLessons();
    public CourseExistDTO CreateNewCourse(PostCourseDTO postCourseDto);
    public Course DeleteCourse(int idCourse);
}