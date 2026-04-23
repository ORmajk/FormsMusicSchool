using System;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class ClassSchedule
    {
        public int Id { get; set; }

        [Display(Name = "Группа")]
        public int? GroupId { get; set; }

        [Required(ErrorMessage = "День недели обязателен")]
        [Range(0, 6, ErrorMessage = "День недели должен быть от 0 до 6")]
        [Display(Name = "День недели")]
        public int? DayOfWeek { get; set; }

        [Required(ErrorMessage = "Время начала обязательно")]
        [DataType(DataType.Time)]
        [Display(Name = "Время начала")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "Время окончания обязательно")]
        [DataType(DataType.Time)]
        [Display(Name = "Время окончания")]
        public TimeSpan EndTime { get; set; }

        [Required(ErrorMessage = "Аудитория обязательна")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Аудитория должна быть от 1 до 20 символов")]
        [Display(Name = "Аудитория")]
        public string Classroom { get; set; }

        [Display(Name = "Преподаватель")]
        public int? TeacherId { get; set; }

        // Навигационные свойства
        public virtual StudyGroup Group { get; set; }
        public virtual User Teacher { get; set; }
        public virtual Course Course => Group?.Course;

        // Вспомогательное свойство для отображения дня недели
        public string DayOfWeekName
        {
            get
            {
                string[] days = { "Понедельник", "Вторник", "Среда", "Четверг",
                                  "Пятница", "Суббота", "Воскресенье" };
                return DayOfWeek.HasValue && DayOfWeek >= 0 && DayOfWeek <= 6
                    ? days[DayOfWeek.Value] : "";
            }
        }
    }
}