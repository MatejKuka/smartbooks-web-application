using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int CourseId { get; set; }
    
    [ForeignKey("CourseId")]
    public Course course { get; set; }
}