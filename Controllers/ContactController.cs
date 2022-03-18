using ContactAppBackend.Database.Models;
using ContactAppBackend.Dto;
using ContactAppBackend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly ContactService contactService;

        public ContactController()
        {
                this.contactService = new ContactService();
        }

        // GET: api/<ContactController>
        /*[HttpGet]
        public ActionResult<IEnumerable<ContactDto>> Getcontact()
        {
            return contactService.GetContact();
        }*/

        
        // GET api/<ContactController>
        [HttpGet("{id}")]
        public ActionResult<Contact> GetContactById(int id)
        {
          
            return contactService.GetContactsById(id);
        }

        // POST api/<ContactController>

        [HttpPost]
        public ActionResult<APIResult> Post([FromBody] CreateContactDto dto)
        {
            return this.contactService.CrateContact(dto);
        }


        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
   

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public ActionResult<APIResult> Delete(int id)
        {
            return contactService.DeleteContact(id);
        }
    }
}
