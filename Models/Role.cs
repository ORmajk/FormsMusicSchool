using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название роли обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Название роли должно быть от 2 до 50 символов")]
        [Display(Name = "Роль")]
        public string RoleName { get; set; }

        // Navigation property
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}