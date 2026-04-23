using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class Parent
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Фамилия родителя обязательна")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия должна быть от 2 до 50 символов")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z]+$", ErrorMessage = "Фамилия должна содержать только буквы")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Имя родителя обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z]+$", ErrorMessage = "Имя должно содержать только буквы")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Телефон должен содержать от 10 до 11 цифр")]
        [Display(Name = "Телефон")]
        public string Number { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // Navigation property
        public virtual ICollection<User> Children { get; set; } = new List<User>();

        // Вспомогательное свойство для отображения полного имени
        public string FullName => $"{Surname} {Name}";
    }
}