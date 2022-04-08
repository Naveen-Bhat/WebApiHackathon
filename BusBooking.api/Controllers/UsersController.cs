using Bus.DataAccess.Entities;
using Bus.DataAccess.Repository;
using BusBooking.api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusBooking.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserRepository _userRepository;

        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            var users = _userRepository.GetALL();

            return users.Select(a => new UserModel { Id = a.Id, Name = a.Name, Email = a.Email });
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            var user = _userRepository.GetById(id);
            return new UserModel { Id = user.Id, Name = user.Name, Email = user.Email };
        }

        // POST api/<UsersController>
        [HttpPost]
        async public Task<ActionResult> Post([FromBody] CreateUserModel user)
        {
            var id = await _userRepository.CreateAsync(new User { Name = user.Name, Email = user.Email, Password = user.Password });

            return Ok(id);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        async public System.Threading.Tasks.Task Put(int id, [FromBody] UpdateUserModel user)
        {
            var usr = new User { Id = id, Name = user.Name, Email = user.Email, Password = user.Password };
            await _userRepository.Update(usr);
        }
        

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        async public System.Threading.Tasks.Task Delete(int id)
        {
        await _userRepository.Delete(id);
        }
    }
}
