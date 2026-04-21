using System.Collections.Generic;

namespace MusicSchoolApp.Models
{
    public class StudyGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }
        public int? MaxStudents { get; set; }
        public int? CurrentStudents { get; set; }
        public bool? IsActive { get; set; }

        public virtual Course Course { get; set; }
        public virtual User Teacher { get; set; }
        public virtual ICollection<ClassSchedule> Schedules { get; set; } = new List<ClassSchedule>();
        public virtual ICollection<GroupMember> Members { get; set; } = new List<GroupMember>();
    }
}