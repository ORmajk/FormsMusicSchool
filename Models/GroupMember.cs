using System;

namespace MusicSchoolApp.Models
{
    public class GroupMember
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public DateTime JoinDate { get; set; }

        public virtual StudyGroup Group { get; set; }
        public virtual User Student { get; set; }
    }
}