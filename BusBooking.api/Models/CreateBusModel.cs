namespace BusBooking.api.Models
{
    public class CreateBusModel
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }

        public int Seats { get; set; }

        public int BookedBy { get; set; }
       
    }
}
