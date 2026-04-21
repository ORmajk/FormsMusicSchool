using System;

namespace MusicSchoolApp.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime ContractDate { get; set; }
        public string AmountMonth { get; set; }
        public int UserId { get; set; }
        public bool? Discount { get; set; }
        public int? DiscountSum { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}