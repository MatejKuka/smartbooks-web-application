using Domain;

namespace Application.Interfaces.repositories;

public interface ILessonRepository
{
    public List<Lesson> GetAllLessonsByCourseId(int idCourse);
    public Lesson CreateLesson(Lesson lesson);
    public Lesson DeleteLesson(int idLesson);

}