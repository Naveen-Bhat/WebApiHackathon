using BusBooking.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Controllers
{
    


    [ApiController]
    [Route("[controller]")]
    public class BusController : ControllerBase
    {
        ApplicationDbContext dbcontext = new ApplicationDbContext();

        [HttpPost("AddBuses")]
        
        public Bus AddBuses(Bus bus)
        {
            dbcontext.Add(bus);
            dbcontext.SaveChanges();
            return bus;
        }

        [HttpGet("GetBuses")]

        public List<Bus> GetBuses()
        {
            return dbcontext.Buses.ToList();
        }


        [HttpGet("AvailbaleBuses")]

        public List<Bus> AvailableBuses()
        {
            var availablebuses=dbcontext.Buses.Where(a=>a.AvailbaleForBoking).ToList();
            return availablebuses;
        }

        [HttpDelete("Deletingbus")]
        public ActionResult Deletingbus(int id)
        {
            var deletebus=dbcontext.Buses.Where(a=>a.Id==id).FirstOrDefault();
            dbcontext.Remove(deletebus);
            dbcontext.SaveChanges();
            return Ok();
        }

        [HttpPost("UdatingBus")]
        public Bus UpdatingBus(Bus bus)
        {
            dbcontext.Buses.Update(bus);
            dbcontext.SaveChanges();
            return bus;
        }

        [HttpPost("BookingBus")]
        public bool BookingBus(int id, int sa)
        {

            var bus = dbcontext.Buses.Where(a => a.Id ==id).FirstOrDefault();
            if (bus == null)
            {
                return false;
            }
            if (bus.Seats >= sa)
            {
                bus.Seats = bus.Seats - sa;
                dbcontext.Buses.Update(bus);
                dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
      
            
            
            
        }



    }
}