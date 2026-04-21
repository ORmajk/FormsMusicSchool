using System;

namespace MusicSchoolApp.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public int? AchievementTypeId { get; set; }
        public DateTime? AchievementDate { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
        public virtual AchievementType AchievementType { get; set; }
    }
}