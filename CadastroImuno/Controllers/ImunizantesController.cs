using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroImuno.Data;
using CadastroImuno.Models;

namespace CadastroImuno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImunizantesController : ControllerBase
    {
        private readonly ImunizanteDbContext _context;

        public ImunizantesController(ImunizanteDbContext context)
        {
            _context = context;
        }

        // GET: api/Imunizantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imunizante>>> GetImunizantes()
        {
            return await _context.Imunizantes.ToListAsync();
        }

        // GET: api/Imunizantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imunizante>> GetImunizante(int id)
        {
            var imunizante = await _context.Imunizantes.FindAsync(id);

            if (imunizante == null)
            {
                return NotFound();
            }

            return imunizante;
        }

        // PUT: api/Imunizantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImunizante(int id, Imunizante imunizante)
        {
            if (id != imunizante.Id)
            {
                return BadRequest();
            }

            _context.Entry(imunizante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImunizanteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Imunizantes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Imunizante>> PostImunizante(Imunizante imunizante)
        {
            _context.Imunizantes.Add(imunizante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImunizante", new { id = imunizante.Id }, imunizante);
        }

        // DELETE: api/Imunizantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Imunizante>> DeleteImunizante(int id)
        {
            var imunizante = await _context.Imunizantes.FindAsync(id);
            if (imunizante == null)
            {
                return NotFound();
            }

            _context.Imunizantes.Remove(imunizante);
            await _context.SaveChangesAsync();

            return imunizante;
        }

        private bool ImunizanteExists(int id)
        {
            return _context.Imunizantes.Any(e => e.Id == id);
        }
    }
}
