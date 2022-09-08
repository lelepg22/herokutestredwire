using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetRedLineAG.Data;
using ProjetRedLineAG.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetRedLineAG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {

        private readonly ApplicationsContext _context;
        public ContactsController(ApplicationsContext context)
        {
            _context = context;
        }


#pragma warning disable CS0169 // Le champ 'ContactsController._logger' n'est jamais utilisé
        private readonly ILogger<ContactsController> _logger;
#pragma warning restore CS0169 // Le champ 'ContactsController._logger' n'est jamais utilisé


        [HttpPost]
        public async Task<ActionResult<EntrepriseModel>> PostPerson(PersonModel data)

        {
            _context.Person.Add(data);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.Id }, data);
            

        }

        [HttpPost("sent")]
        public async Task<ActionResult<PersonSentModel>> PostPersonSent(PersonSentModel data)
        {
            _context.PersonSent.Add(data);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.ApplicationId }, data);


        }
        [HttpPost("statut")]
        public async Task<ActionResult<PersonSentModel>> PostStatut(StatutModel data)
        {
            _context.Statut.Add(data);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data }, data);


        }

        [HttpGet]
        public async Task<IEnumerable<PersonModel>> GetContacts()
        {
            var res = _context.Person.Include(e=> e.Entreprise).ToListAsync();

            return await res;

        }
        [HttpGet("person/")]
        public async Task<IEnumerable<PersonModel>> GetContactsPure()
        {
            var res = _context.Person.ToListAsync();

            return await res;

        }
        [HttpGet("personsent/")]
        public async Task<IEnumerable<PersonSentModel>> GetContactsApplication(int id)
        {
            var res = _context.PersonSent.Where(p => p.ApplicationId == id)               
                .ToListAsync();

            return await res;

        }
        [HttpPut("update/")]
        public async Task<ActionResult<PersonModel>> UpdatePerson(PersonModel data)

        {

            _context.Entry(data).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.ApplicationId }, data);

        }


        [HttpPut("edit/")]
        public async Task<ActionResult<PersonSentModel>> UpdatePersonSent(PersonSentModel data)

        {

            _context.Entry(data).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.ApplicationId }, data);

        }


        [HttpGet("get/")]
        public async Task<IEnumerable<PersonModel>> GetContact(int id)
        {
            var res = _context.Person.Where(e => e.EntrepriseId == id).ToListAsync();

            return await res;

        }
        [HttpGet("statut/")]
        public async Task<IEnumerable<StatutModel>> GetStatut(int id)
        {
            var res = _context.Statut.Where(e => e.StatutId == id).ToListAsync();

            return await res;

        }
        [HttpGet("statuts/")]
        public async Task<IEnumerable<StatutModel>> GetStatuts(int id)
        {
            var res = _context.Statut.ToListAsync();

            return await res;

        }

        [HttpGet("persons/")]
        public async Task<IEnumerable<PersonModel>> GetPerson(int id)
        {
            var res = _context.Person.Where(e => e.Id == id).ToListAsync();

            return await res;

        }

        [HttpDelete("sent/delete/")]
        public async Task<ActionResult<PersonSentModel>> DeletePersonSent(int id)
        {
            var personSent = await _context.PersonSent.FindAsync(id);
            if (personSent == null)
            {
                return NotFound();
            }
            
            if (personSent != null)
            {
                _context.PersonSent.Remove(personSent);
            }
            
            await _context.SaveChangesAsync();

            return personSent;

        }
       
        [HttpDelete("statut/delete/")]

        public async Task<ActionResult<StatutModel>> DeleteStatut(int id)
        {
                     

            var stat = await _context.Statut.FindAsync(id);
            if (stat == null)
            {
                return NotFound();
            }


            _context.Statut.Remove(stat);
            await _context.SaveChangesAsync();

            return stat;

        }

        [HttpDelete("delete/")]
        public async Task<ActionResult<PersonModel>> DeletePerson(int id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            if (person != null)
            {
                _context.Person.Remove(person);
            }

            await _context.SaveChangesAsync();

            return person;

        }


        /*[HttpPost("personSent/")]
        public async Task<ActionResult<EntrepriseModel>> PostPersonSent(PersonSentModel data)

        {

            _context.PersonSent.Add(data);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.Id }, data);
            ;

        }
        */
        /*public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }
        *//*
        
        [HttpGet]

        public async Task<IEnumerable<PersonModel>> Get()
        {
            var res = _context.Person.ToListAsync();
            return await res;
        }
        */
    }
}
