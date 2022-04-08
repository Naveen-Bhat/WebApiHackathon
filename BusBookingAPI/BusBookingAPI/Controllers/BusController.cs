using Microsoft.AspNetCore.Mvc;
using BusBookingAPI.DbContext;

namespace BusBookingAPI.Controllers
{
    [Route("BusBooking")]
    public class BusController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        [HttpPost]
        [Route("AddBus")]
        public void AddBus(BusBooking busBooking)
        {
            dbContext.busbooking.Add(busBooking);
            dbContext.SaveChanges();
        }

        [HttpGet]
        [Route("GetBus")]
        public List<BusBooking> GetBus()
        {
            return dbContext.busbooking.ToList();
        }

        [HttpGet]
        [Route("GetAvailableBus")]
        public BusBooking GetAvailableBus()
        {
             foreach(var bus in dbContext.busbooking)
            {
                if(bus.IsavailableForBooking == 'Y')
                {
                    return bus;
                }
            }
             return null;
        }

        [HttpDelete]
        [Route("DeleteBus")]
        public List<BusBooking> DeleteBus(string Number)
        {
            var bus = dbContext.busbooking.Where(a => a.Number == Number).FirstOrDefault();
            dbContext.busbooking.Remove(bus);
            dbContext.SaveChanges();
            return dbContext.busbooking.ToList();
        }

        [HttpPut]
        [Route("UpdateBus")]
        public List<BusBooking> UpdateBus(string Number, string type, int seats)
        {
            foreach(var bus in dbContext.busbooking)
            {
                if(bus.Number == Number)
                {
                    bus.Type = type;
                    bus.Seats = seats;
                    dbContext.busbooking.Update(bus);
                }
            }
            //var bus = dbContext.busbooking.Where(a => a.Number == Number).FirstOrDefault();
            //dbContext.busbooking.Update(bus);
            return dbContext.busbooking.ToList();
        }

        [HttpPut]
        [Route("BookBusSeat")]
        public List<BusBooking> BookBusSeat(string Number, int seats)
        {
            foreach (var bus in dbContext.busbooking)
            {
                if (bus.Number == Number)
                {
                    
                    bus.Seats -= seats;
                    dbContext.busbooking.Update(bus);
                }
            }
            dbContext.SaveChanges();
            return dbContext.busbooking.ToList();
        }
    }
}
