using Domain;

namespace Application.DTOs;

public class PSExistDTO
{
    public int Id { get; set; }
    public int Progress { get; set; }
    public int Score { get; set; }
    public LessonExistDTO lesson { get; set; }
}