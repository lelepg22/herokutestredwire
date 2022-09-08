using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    public class HomeController : ControllerBase
    {

        private readonly ApplicationsContext _context;
        public HomeController(ApplicationsContext context)
        {
            _context = context;
        }


#pragma warning disable CS0169 // Le champ 'HomeController._logger' n'est jamais utilisé
        private readonly ILogger<HomeController> _logger;
#pragma warning restore CS0169 // Le champ 'HomeController._logger' n'est jamais utilisé

        /* public HomeController(ILogger<HomeController> logger)
         {
             _logger = logger;
         }*/ 

        [HttpGet]
        public async Task<IEnumerable<ApplicationModel>> Get()
        {         

            await _context.SaveChangesAsync();

            var res = _context.Application.Include(s => s.Entreprise).ToListAsync();                



            return await res;

        }

        [HttpGet("entreprise/")]
        public async Task<IEnumerable<ApplicationModel>> GetEntreprise(int id)
        {
            var res = _context.Application.Where(e=> e.EntrepriseId == id)                
                .Include(s=> s.Entreprise)
                
                .ToListAsync();

            return await res; 
       
        }
        [HttpGet("docs/")]
        public async Task<IEnumerable<DocumentModel>> GetDocuments()
        {
            var res = _context.Document.ToListAsync();

            return await res;

        }
        [HttpGet("documentsent/")]
        public async Task<IEnumerable<DocumentSentModel>> GetDocumentSent(int id)
        {
            var res = _context.DocumentsSent.Where(e => e.ApplicationId == id)          
                .ToListAsync();

            return await res;

        }
        [HttpGet("application/")]
        public async Task<IEnumerable<ApplicationModel>> GetApplication(int id)
        {
           
        var res = await _context.Application.Include(p=> p.PersonSent)
                .Include(d=> d.DocumentSent).Where(x => x.ApplicationId == id).ToListAsync();          
                
            
        return res;
        }

            

        
        [HttpGet("form/")]
        public async Task<IEnumerable<IEnumerable>> GetForm()
        {
            IEnumerable[] resu;

            resu = new IEnumerable[] { await _context.Entreprise.ToListAsync().ConfigureAwait(false), 
                await _context.Person.ToListAsync().ConfigureAwait(false), await _context.Document.ToListAsync().ConfigureAwait(false), 
                await _context.Statut.ToListAsync().ConfigureAwait(false) };

            return resu;

        }
        [HttpDelete("delete/")]
        public async Task<ActionResult<ApplicationModel>> DeleteApplication(int id)
        {
            var applications = await _context.Application.FindAsync(id);
            if (applications == null)
            {
                return NotFound();
            }
            var personSent = await _context.PersonSent.FindAsync(id);
            if (personSent != null)
            {
                _context.PersonSent.Remove(personSent);
            }

            _context.Application.Remove(applications);
            await _context.SaveChangesAsync();

            return applications;

        }
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<ApplicationModel>> PostApplication(ApplicationModel data)

        {

            _context.Application.Add(data);
           
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.ApplicationId }, data);
         
        }

        [HttpPut]
        public async Task<ActionResult<ApplicationModel>> UpdateApplication(ApplicationModel data)

        {

            _context.Entry(data).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.ApplicationId }, data);

        }

    }
}
