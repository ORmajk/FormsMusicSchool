using System.Collections.Generic;

namespace MusicSchoolApp.Models
{
    public class Benefit
    {
        public int Id { get; set; }
        public string BenefitName { get; set; } // поле benefit

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}