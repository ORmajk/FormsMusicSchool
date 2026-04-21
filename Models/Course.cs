using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace MusicSchoolApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int TeacherId { get; set; } // id_user
        public int MinAge { get; set; }
        public int? MaxAge { get; set; }
        public int DurationMinutes { get; set; } // duration_course
        public int CourseTypeId { get; set; }

        // Navigation properties
        public virtual User Teacher { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public virtual ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
        public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
    }
}