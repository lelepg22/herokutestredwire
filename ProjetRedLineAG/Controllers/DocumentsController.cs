using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetRedLineAG.Data;
using ProjetRedLineAG.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetRedLineAG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {

        private readonly ApplicationsContext _context;
        public DocumentsController(ApplicationsContext context)
        {
            _context = context;
        }

#pragma warning disable CS0169 // Le champ 'DocumentsController._logger' n'est jamais utilisé
        private readonly ILogger<DocumentsController> _logger;
#pragma warning restore CS0169 // Le champ 'DocumentsController._logger' n'est jamais utilisé

        /*public EntreprisesController(ILogger<EntreprisesController> logger)
        {
            _logger = logger;
        }*/
        [HttpPost("sent")]
        public async Task<ActionResult<DocumentSentModel>> PostDocumentSent(DocumentSentModel data)
        {
            _context.DocumentsSent.Add(data);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.ApplicationId }, data);

        }
        [HttpPost]
        public async Task<ActionResult<DocumentSentModel>> PostDocument(DocumentModel data)
        {
            _context.Document.Add(data);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data }, data);

        }

        [HttpPut("edit/")]
        public async Task<ActionResult<DocumentSentModel>> UpdateApplication(DocumentSentModel data)

        {

            _context.Entry(data).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = data.ApplicationId }, data);

        }
        [HttpDelete("sent/delete/")]
        public async Task<ActionResult<DocumentSentModel>> DeleteDocSent(int id)
        {
            var docsSent= await _context.DocumentsSent.FindAsync(id);
            if (docsSent == null)
            {
                return NotFound();
            }
            var personSent = await _context.PersonSent.FindAsync(id);
            if (personSent != null)
            {
                _context.PersonSent.Remove(personSent);
            }

            _context.DocumentsSent.Remove(docsSent);
            await _context.SaveChangesAsync();

            return docsSent;

        }

        [HttpDelete("delete/")]

        public async Task<ActionResult<DocumentModel>> DeleteDoc(int id)
        {
            var doc = await _context.Document.FindAsync(id);
            if (doc == null)
            {
                return NotFound();
            }
            

            _context.Document.Remove(doc);
            await _context.SaveChangesAsync();

            return doc;

        }


        [HttpGet]

        public async Task<IEnumerable<DocumentModel>> Get()
        {

            var res = _context.Document.ToListAsync();
            return await res;
        }
    }
}
