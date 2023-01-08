using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class PersonalStatistics
{
    public int Id { get; set; }
    public int Progress { get; set; }
    public int Score { get; set; }
    public int LessonId { get; set; }
    
    [ForeignKey("LessonId")]
    public Lesson lesson { get; set; }
}