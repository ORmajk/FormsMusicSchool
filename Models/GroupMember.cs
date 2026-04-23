using System;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class GroupMember
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Группа обязательна")]
        [Display(Name = "Группа")]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Ученик обязателен")]
        [Display(Name = "Ученик")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Дата зачисления обязательна")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата зачисления")]
        public DateTime JoinDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual StudyGroup Group { get; set; }
        public virtual User Student { get; set; }
    }
}