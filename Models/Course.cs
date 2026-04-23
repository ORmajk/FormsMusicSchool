using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название курса обязательно")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название курса должно быть от 3 до 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Цена обязательна")]
        [Range(0, 1000000, ErrorMessage = "Цена должна быть от 0 до 10000")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Преподаватель обязателен")]
        [Display(Name = "Преподаватель")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Минимальный возраст обязателен")]
        [Range(3, 100, ErrorMessage = "Минимальный возраст должен быть от 3 до 100 лет")]
        [Display(Name = "Минимальный возраст")]
        public int MinAge { get; set; }

        [Range(3, 100, ErrorMessage = "Максимальный возраст должен быть от 3 до 100 лет")]
        [Display(Name = "Максимальный возраст")]
        public int? MaxAge { get; set; }

        [Required(ErrorMessage = "Длительность занятия обязательна")]
        [Range(15, 480, ErrorMessage = "Длительность должна быть от 15 до 480 минут")]
        [Display(Name = "Длительность (минут)")]
        public int DurationMinutes { get; set; }

        [Required(ErrorMessage = "Тип курса обязателен")]
        [Display(Name = "Тип курса")]
        public int CourseTypeId { get; set; }

        // Navigation properties
        public virtual User Teacher { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public virtual ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
        public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
    }
}