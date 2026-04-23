using System;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class Progress
    {
        public int Id { get; set; }

        [Display(Name = "Ученик")]
        public int? StudentId { get; set; }

        [Display(Name = "Курс")]
        public int? CourseId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата оценки")]
        public DateTime? EvaluationDate { get; set; } = DateTime.Now;

        [StringLength(50, ErrorMessage = "Уровень не должен превышать 50 символов")]
        [Display(Name = "Уровень")]
        public string SkillLevel { get; set; }

        [StringLength(500, ErrorMessage = "Комментарий не должен превышать 500 символов")]
        [Display(Name = "Комментарий")]
        public string TeacherComment { get; set; }

        [Display(Name = "Преподаватель")]
        public int? TeacherId { get; set; }

        // Navigation properties
        public virtual User Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual User Teacher { get; set; }
    }
}