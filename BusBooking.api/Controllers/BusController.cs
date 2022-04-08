using Bus.DataAccess.Repository;
using BusBooking.api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusBooking.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private BusRepository _busRepository;

        public BusController()
        {
            _busRepository = new BusRepository();
        }

        // GET: api/<BusController>
        [HttpGet]
        public IEnumerable<BusModel> Get()
        {
            var bus = _busRepository.GetAll();

            return bus.Select(a => new BusModel
            {
                Seats = a.Seats,
                Type = a.Type,
                BookedBy = a.BookedByNavigation?.Name
            }
            );

        }

        // GET api/<BusController>/5
        [HttpGet("{id}")]
        public BusModel Get(int id)
        {
            var bus = _busRepository.GetById(id);
            return new BusModel
            {
                Seats = bus.Seats,
                Type = bus.Type,
                //BookedBy = bus.BookedByNavigation?.Name
            };
        }

        // POST api/<BusController>
        [HttpPost]
        async public Task<ActionResult> Post([FromBody] CreateBusModel bus)
        {
            var newBus = new Bus.DataAccess.Entities.Bu {Name = bus.Name, Number = bus.Number,Type = bus.Type, Seats = bus.Seats, IsAvailableForBooking = false, BookedBy = bus.BookedBy };
            var id = await _busRepository.CreateAsync(newBus);
            return Ok(id);
        }

        // PUT api/<BusController>/5
        [HttpPut("{id}")]
        async public Task<ActionResult> Put(int id, [FromBody] UpdateBusModel bus)
        {
            var existingBus = new Bus.DataAccess.Entities.Bu { Id = id, Type = bus.Type, Seats =bus.Seats };
            var result = await _busRepository.Update(existingBus);
            return Ok(result);
        }

        // DELETE api/<BusController>/5
        [HttpDelete("{id}")]
        async public Task<ActionResult> Delete(int id)
        {
            await _busRepository.Delete(id);
            return Ok();
        }
    }
}
