using Microsoft.AspNetCore.Mvc;
using DotnetAPI.Models;
using DotnetAPI.Context;

namespace DotnetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ContactsContext _context;

        public ContactController(ContactsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _context.Contacts.Find(id);
            
            if (contact == null) {
                return NotFound("Contact not found");
            }
            
            return Ok(contact);
        }

        [HttpGet("GetByName")]
        public IActionResult GetAll(string name)
        {
            var contacts = _context.Contacts.Where(x => x.Name.Contains(name));
            
            return Ok(contacts);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            var foundContact = _context.Contacts.Find(id);
            
            if (foundContact == null) {
                return NotFound("Contact not found");
            }
            
            foundContact.Name = contact.Name;
            foundContact.Phone = contact.Phone;
            foundContact.Active = contact.Active;

            _context.Contacts.Update(foundContact);
            _context.SaveChanges();

            return Ok(foundContact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var foundContact = _context.Contacts.Find(id);
            
            if (foundContact == null) {
                return NotFound("Contact not found");
            }

            _context.Contacts.Remove(foundContact);
            _context.SaveChanges();

            return NoContent();
        }
    }
}