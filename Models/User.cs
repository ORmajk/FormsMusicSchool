using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия должна быть от 2 до 50 символов")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z]+$", ErrorMessage = "Фамилия должна содержать только буквы")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z]+$", ErrorMessage = "Имя должно содержать только буквы")]
        public string Name { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^[а-яА-Яa-zA-Z]*$", ErrorMessage = "Отчество должно содержать только буквы")]
        public string Patronymic { get; set; }

        public int? BenefitId { get; set; }
        public int? ParentId { get; set; }
        public int? RoleId { get; set; }

        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Телефон должен содержать от 10 до 11 цифр")]
        public string Number { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Логин обязателен")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Логин должен быть от 4 до 20 символов")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Логин должен содержать только латинские буквы и цифры")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 30 символов")]
        public string Password { get; set; }

        // Navigation properties
        public virtual Benefit Benefit { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
        public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
        public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
    }
}