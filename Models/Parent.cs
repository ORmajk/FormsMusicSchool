using System.Collections.Generic;

namespace MusicSchoolApp.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }

        public virtual ICollection<User> Children { get; set; } = new List<User>();
    }
}