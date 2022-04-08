using System.ComponentModel.DataAnnotations;

namespace BusBookingAPI
{
    public class BusBooking
    {
        public string Name { get; set; }
        [Key]
        public string Number { get; set; }
        public string Type { get; set; }
        public int Seats { get; set; }
        public char IsavailableForBooking { get; set; }


    }
}
