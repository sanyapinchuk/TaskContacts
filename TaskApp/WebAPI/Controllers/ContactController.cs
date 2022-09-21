using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactRepository repository;

        public ContactController(IContactRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<Contact>> GetContact(Guid id)
        {
            var contact =  await repository.GetContactByIdAsync(id);
            if(contact == null)
            {
                return StatusCode(404);
            }
            return Ok(contact);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<ActionResult> UpdateContact([FromForm] Contact contact)
        {
            var contactDb = await repository.GetContactByIdAsync(contact.Id);
            if (contactDb == null)
                return StatusCode(404);

            await Task.Run(() => repository.Update(contact));
            await repository.SaveChangesAsync();

            return StatusCode(204);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> DeleteContact(Guid id)
        {
            var contactDb = await repository.GetContactByIdAsync(id);

            if (contactDb == null)
                return StatusCode(404);

            repository.Delete(contactDb);
            await repository.SaveChangesAsync();

            return StatusCode(204);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateContact([FromForm] Contact contact)
        {
            contact.Id = Guid.NewGuid();
            repository.CreateAsync(contact);
            await repository.SaveChangesAsync();
            return StatusCode(201);
        }
    }
}
