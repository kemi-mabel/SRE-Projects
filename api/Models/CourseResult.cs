namespace api.Models
{
    public class CourseResult
    {
       public int Id { get; set; }
       public int? StudentId { get; set; } // navigation property - allows us to access navigate within our models 
       public string CourseName { get; set; } = string.Empty;
      
       public int? Grade { get; set; }
       public Student? Student { get; set; }
       public DateTime CreatedOm { get; set; } = DateTime.Now;
      
    }
}