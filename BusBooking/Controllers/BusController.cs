using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusBooking.DataAccess;
using BusBooking.DataAccess.Entities;


namespace BusBooking.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BusController : ControllerBase
    {
        private readonly BusBooking.DataAccess.BusBookingRepository busRepo;
        public BusController()
        {
            this.busRepo = new BusBookingRepository();
        }
        [HttpGet(Name = "GetBusList")]
        public IActionResult GetBusList()
        {
            var buses = busRepo.GetBusList();
            return Ok(buses);

        }
        [HttpGet(Name = "GetAvailableBusList")]
        public IActionResult GetAvailableBusList()
        {
            var availableBuses = busRepo.GetAvailable();
            return Ok(availableBuses);

        }

        [HttpPost(Name = "AddBus")]
        public async Task<IActionResult> AddBus(string Name, int seats, bool isAvailableForBooking, string type)
        {
            await busRepo.Create(new BusBooking.DataAccess.Entities.BusBooking { Name = Name, Seats = seats, IsAvailableBooking = isAvailableForBooking == true ? 1 : 0,Type = type });

            return Ok();
        }

        [HttpPut(Name = "BookTheBus")]
        public async Task<IActionResult> BookTheBus(int Number)
        {
           
   
            var bus = busRepo.Update(new DataAccess.Entities.BusBooking() { Number = Number });
            return Ok("Bus Booked");
        }

        [HttpPut(Name = "UpdateBus")]
        public IActionResult UpdateBus( int Number,string Name, string type, int Seats)
        {
            var bus = busRepo.UpdateBusDetail(new DataAccess.Entities.BusBooking() { Number = Number,Name = Name, Type = type, Seats = Seats });
            return Ok("Bus Updated");


        }

        [HttpDelete(Name = "DeleteBus")]
        public IActionResult DeleteToy(int Number)
        {
            var bus = busRepo.Delete(Number);
            return Ok("Bus Deleted");
        }

    }
}

