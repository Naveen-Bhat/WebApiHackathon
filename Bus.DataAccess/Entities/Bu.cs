using System;
using System.Collections.Generic;

namespace Bus.DataAccess.Entities
{
    public partial class Bu
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Number { get; set; }
        public string Type { get; set; } = null!;
        public int Seats { get; set; }
        public bool IsAvailableForBooking { get; set; }
        public int BookedBy { get; set; }

        public virtual User BookedByNavigation { get; set; } = null!;
    }
}
