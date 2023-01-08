using Application.Interfaces.repositories;
using Domain;

namespace Infrastructure;

public class LessonRepository : ILessonRepository
{ 
    private readonly DatabaseContext _context;

    public LessonRepository(DatabaseContext context)
    {
        _context = context;
    }
    

    public List<Lesson> GetAllLessonsByCourseId(int idCourse)
    {
        return _context.LessonTable.ToList().FindAll(lesson => lesson.CourseId == idCourse);
    }

    public Lesson CreateLesson(Lesson lesson)
    {
        _context.LessonTable.Add(lesson);
        _context.SaveChanges();
        return lesson;
    }

    public Lesson DeleteLesson(int idLesson)
    {
        var lessonToDelete = _context.LessonTable.Find(idLesson) ?? throw new KeyNotFoundException();
        _context.LessonTable.Remove(lessonToDelete);
        _context.SaveChanges();
        return lessonToDelete;
    }
    
    
}