using Bus.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.DataAccess.Repository
{
    public class BusRepository
    {
        private readonly BusBookingContext _dataContext;

        public BusRepository()
        {
            _dataContext = new BusBookingContext();
        }

        public IEnumerable<Entities.Bu> GetAll()
        {
            return _dataContext.buses.Include(a => a.BookedByNavigation).ToList();
        }

        public Entities.Bu GetById(int id)
        {
            return _dataContext.buses.FirstOrDefault(a => a.Id == id);
        }

        async public Task<int> CreateAsync(Entities.Bu bus)
        {
            _dataContext.buses.Add(bus);
            await _dataContext.SaveChangesAsync();
            return bus.Id;
        }

        async public Task<int> Update(Entities.Bu bus)
        {
            var existingTask = _dataContext.buses.Where(a => a.Id == bus.Id).FirstOrDefault();
            existingTask.Type = bus.Type;
            existingTask.Seats = bus.Seats;
            await _dataContext.SaveChangesAsync();
            return bus.Id;
        }
        async public System.Threading.Tasks.Task Delete(int id)
        {
         
            var existingTask = _dataContext.buses.FirstOrDefault(a => a.Id == id);
            _dataContext.buses.Remove(existingTask);
            await _dataContext.SaveChangesAsync();
            
        }

    }
}
