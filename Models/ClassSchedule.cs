using System;

namespace MusicSchoolApp.Models
{
    public class ClassSchedule
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? DayOfWeek { get; set; }  // Храним как int (0-6)
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Classroom { get; set; }
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