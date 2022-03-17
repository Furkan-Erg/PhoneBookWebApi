using ContactAppBackend.Database.Models;
using ContactAppBackend.Dto;
using ContactAppBackend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// api/user/324

namespace ContactAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        private readonly ContactService contactService;

        public UserController()
        {
            this.contactService = new ContactService();
            this.userService = new UserService();
        }



        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return this.userService.GetUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return this.userService.FindUserById(id);
        }

        [HttpGet("{id}/contacts")]
        public ActionResult<IEnumerable<ContactDto>> GetContacts(int id)
        {
            return this.contactService.GetContactsByOwnerId(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<APIResult> Post([FromBody] CreateUserDto value)
        {
            return this.userService.CreateUser(value);

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
