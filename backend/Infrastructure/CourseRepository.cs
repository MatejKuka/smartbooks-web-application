using Application.Interfaces.repositories;
using Domain;

namespace Infrastructure;

public class CourseRepository : ICourseRepository
{
    private readonly DatabaseContext _context;

    public CourseRepository(DatabaseContext context)
    {
        _context = context;
    }
    

    public List<Course> GetAllCoursesWithoutLessons()
    {
        return _context.CourseTable.ToList();
    }

    public Course CreateNewCourse(Course course)
    {
        _context.CourseTable.Add(course);
        _context.SaveChanges();
        return course;
    }

    public Course DeleteCourse(int idCourse)
    {
        var courseToDelete = _context.CourseTable.Find(idCourse) ?? throw new KeyNotFoundException();
        _context.CourseTable.Remove(courseToDelete);
        _context.SaveChanges();
        return courseToDelete;
    }
}