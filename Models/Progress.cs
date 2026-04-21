using System;

namespace MusicSchoolApp.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? EvaluationDate { get; set; }
        public string SkillLevel { get; set; }
        public string TeacherComment { get; set; }
        public int? TeacherId { get; set; }

        public virtual User Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual User Teacher { get; set; }
    }
}