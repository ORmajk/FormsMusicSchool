using System.Collections.Generic;

namespace MusicSchoolApp.Models
{
    public class AchievementType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } // achievement_type

        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
    }
}