using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class StudyGroup
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название группы обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название группы должно быть от 2 до 100 символов")]
        [Display(Name = "Название группы")]
        public string GroupName { get; set; }

        [Display(Name = "Курс")]
        public int? CourseId { get; set; }

        [Display(Name = "Преподаватель")]
        public int? TeacherId { get; set; }

        [Range(1, 100, ErrorMessage = "Максимальное количество учеников должно быть от 1 до 100")]
        [Display(Name = "Максимум учеников")]
        public int? MaxStudents { get; set; }

        [Range(0, 100, ErrorMessage = "Текущее количество учеников должно быть от 0 до 100")]
        [Display(Name = "Текущее количество")]
        public int? CurrentStudents { get; set; }

        [Display(Name = "Активна")]
        public bool? IsActive { get; set; } = true;

        // Navigation properties
        public virtual Course Course { get; set; }
        public virtual User Teacher { get; set; }
        public virtual ICollection<ClassSchedule> Schedules { get; set; } = new List<ClassSchedule>();
        public virtual ICollection<GroupMember> Members { get; set; } = new List<GroupMember>();

        // Вспомогательное свойство - есть ли свободные места
        public bool HasFreePlaces => !MaxStudents.HasValue || (CurrentStudents ?? 0) < MaxStudents.Value;

        // Вспомогательное свойство - количество свободных мест
        public int FreePlaces => MaxStudents.HasValue ? MaxStudents.Value - (CurrentStudents ?? 0) : int.MaxValue;
    }
}