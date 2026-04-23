using System;
using System.ComponentModel.DataAnnotations;

namespace MusicSchoolApp.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Курс обязателен")]
        [Display(Name = "Курс")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Дата договора обязательна")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата договора")]
        public DateTime ContractDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Количество месяцев обязательно")]
        [StringLength(10, ErrorMessage = "Количество месяцев не должно превышать 10 символов")]
        [Display(Name = "Количество месяцев")]
        public string AmountMonth { get; set; }

        [Required(ErrorMessage = "Ученик обязателен")]
        [Display(Name = "Ученик")]
        public int UserId { get; set; }

        [Display(Name = "Скидка")]
        public bool? Discount { get; set; }

        [Range(0, 1000000, ErrorMessage = "Сумма скидки должна быть от 0 до 1 000 000")]
        [Display(Name = "Сумма скидки")]
        public int? DiscountSum { get; set; }

        // Navigation properties
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }

        // Вспомогательное свойство для отображения итоговой стоимости
        public decimal TotalPrice
        {
            get
            {
                if (Course == null) return 0;

                int months = 1;
                if (!string.IsNullOrWhiteSpace(AmountMonth) && int.TryParse(AmountMonth, out int parsedMonths))
                {
                    months = parsedMonths;
                }

                decimal total = Course.Price * months;

                if (Discount == true && DiscountSum.HasValue)
                {
                    total -= DiscountSum.Value;
                }

                return total > 0 ? total : 0;
            }
        }
    }
}