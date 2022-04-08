using Bus.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.DataAccess.Repository
{
    public class UserRepository
    {
        private readonly BusBookingContext _dataContext;

        public UserRepository()
        {
            _dataContext = new BusBookingContext();
        }
        public IEnumerable<User> GetALL()
        {
            return _dataContext.Users.ToList();
        }
        public User GetById(int id)
        {
            return _dataContext.Users.FirstOrDefault(a => a.Id == id);
        }

        async public Task<int> CreateAsync(User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return user.Id;
        }

        async public Task<int> Update(User user)
        {
            var existingUser = _dataContext.Users.FirstOrDefault(a => a.Id == user.Id);
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;
            await _dataContext.SaveChangesAsync();
            return user.Id;
        }

        async public System.Threading.Tasks.Task Delete(int id)
        {
            var existingUser = _dataContext.Users.FirstOrDefault(a => a.Id == id);
            _dataContext.Users.Remove(existingUser);
            await _dataContext.SaveChangesAsync();
        }
    }
}
