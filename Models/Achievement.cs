using System;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class Achievement
    {
        public int Id { get; set; }

        [Display(Name = "Ученик")]
        public int? UserId { get; set; }

        [Display(Name = "Курс")]
        public int? CourseId { get; set; }

        [Display(Name = "Тип достижения")]
        public int? AchievementTypeId { get; set; }

        [Display(Name = "Дата получения")]
        [DataType(DataType.Date)]
        public DateTime? AchievementDate { get; set; }

        [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
        public virtual AchievementType AchievementType { get; set; }
    }
}