using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetRedLineAG.Data;
using ProjetRedLineAG.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetRedLineAG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntreprisesController : ControllerBase
    {

        private readonly ApplicationsContext _context;
        public EntreprisesController(ApplicationsContext context)
        {
            _context = context;
        }


#pragma warning disable CS0169 // Le champ 'EntreprisesController._logger' n'est jamais utilisé
        private readonly ILogger<EntreprisesController> _logger;
#pragma warning restore CS0169 // Le champ 'EntreprisesController._logger' n'est jamais utilisé

        /*public EntreprisesController(ILogger<EntreprisesController> logger)
        {
            _logger = logger;
        }*/

        [HttpGet]
        public async Task<IEnumerable<EntrepriseModel>> Get()
        {

            var res = _context.Entreprise.ToListAsync();
            return await res;
        }

        [HttpGet("get/")]
        public async Task<IEnumerable<EntrepriseModel>> GetEntreprise(int id)
        {
            var res = _context.Entreprise.Where(e => e.EntrepriseId == id) .ToListAsync();

            return await res;

        }
        [HttpDelete("delete/")]

        public async Task<ActionResult<EntrepriseModel>> DeleteEntreprise(int id)
        {            


            var entreprise = await _context.Entreprise.FindAsync(id);
            if (entreprise == null)
            {
                return NotFound();
            }

            _context.Entreprise.Remove(entreprise);
            await _context.SaveChangesAsync();

            return entreprise;

        }

        [HttpPost]
        public async Task<ActionResult<EntrepriseModel>> PostEntreprises(EntrepriseModel data)

        {
            _context.Entreprise.Add(data);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.EntrepriseId }, data);
            ;

        }

        [HttpPut("persons/")]
        public async Task<ActionResult<PersonModel>> UpdatePersonEntreprise(int id)           
        {
            var person = await _context.Person.FindAsync(id);
            person.EntrepriseId = 1;
            _context.Entry(person).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = id }, id);

        }
        [HttpPut("comment/")]
        public async Task<ActionResult<PersonModel>> UpdateCommentEntreprise(EntrepriseModel data)
        {
            var entreprise = await _context.Entreprise.FindAsync(data.EntrepriseId);
            entreprise.CommentsEntreprise = data.CommentsEntreprise;
            entreprise.TelEntreprise = data.TelEntreprise;
            entreprise.EmailEntreprise = data.EmailEntreprise;
            
            _context.Entry(entreprise).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.EntrepriseId }, data.EntrepriseId);

        }

    }

    //HttpPost
    //Sauvegarder une entreprise

    /*[HttpGet("entreprise/{id}")]
    public async Task<IEnumerable<EntrepriseModel>> GetEntreprise(int id)
    {

        var res = _context.Entreprises.Include(s => s.Person).Include(s => s.Application).Where(s=> s.EntrepriseId == id).Where(s=> s.EntrepriseId == s.Application.EntrepriseId)
            .Where(s=> s.EntrepriseId == s.Person.EntrepriseId).ToListAsync();
        return await res;
    }*/

}

