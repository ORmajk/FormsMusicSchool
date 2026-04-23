using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class CourseType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название типа курса обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название должно быть от 2 до 100 символов")]
        [Display(Name = "Тип курса")]
        public string TypeName { get; set; }

        // Navigation property
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}