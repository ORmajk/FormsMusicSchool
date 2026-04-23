using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class Benefit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название льготы обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название льготы должно быть от 2 до 100 символов")]
        [Display(Name = "Название льготы")]
        public string BenefitName { get; set; }


        // Navigation property
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}