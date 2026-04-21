using System.Collections.Generic;

namespace MusicSchoolApp.Models
{
    public class CourseType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } // course_type

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}