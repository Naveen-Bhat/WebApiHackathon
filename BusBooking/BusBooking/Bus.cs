namespace BusBooking
{
    public class Bus

    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Number { get; set; }
        public string Type { get; set; }

        public int Seats { get; set; }

        public bool AvailbaleForBoking { get; set; }
    }
}