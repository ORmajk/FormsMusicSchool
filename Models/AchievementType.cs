using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class AchievementType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название типа достижения обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название должно быть от 2 до 100 символов")]
        [Display(Name = "Тип достижения")]
        public string TypeName { get; set; }

        // Navigation property
        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
    }
}