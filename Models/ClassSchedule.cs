using System;

namespace MusicSchoolApp.Models
{
    public class ClassSchedule
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Classroom { get; set; }
        public int? TeacherId { get; set; }

        public virtual StudyGroup Group { get; set; }
        public virtual User Teacher { get; set; }
    }
}