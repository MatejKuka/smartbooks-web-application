using Application.DTOs;
using Domain;

namespace Application.Interfaces.services;

public interface ILessonService
{
    public List<LessonExistDTO> GetAllLessonsByCourseId(int idCourse);
    public LessonExistDTO CreateLesson(PostLessonDTO postLessonDto);
    public Lesson DeleteLesson(int idLesson);
}