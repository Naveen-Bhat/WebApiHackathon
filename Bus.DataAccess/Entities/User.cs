using System;
using System.Collections.Generic;

namespace Bus.DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            Bus = new HashSet<Bu>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Bu> Bus { get; set; }
    }
}
