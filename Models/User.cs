using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Contracts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MusicSchoolApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int? BenefitId { get; set; }
        public int? ParentId { get; set; }
        public int? RoleId { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // Navigation properties
        public virtual Benefit Benefit { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>(); // как преподаватель
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
        public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
        public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
    }
}