using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CastCurso.Data;
using CastCurso.Models;

namespace CastCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaLogsController : ControllerBase
    {
        private readonly CastCursoContext _context;

        public TabelaLogsController(CastCursoContext context)
        {
            _context = context;
        }

        // GET: api/TabelaLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TabelaLog>>> GetTabelaLog()
        {
            return await _context.TabelaLog.ToListAsync();
        }

        // GET: api/TabelaLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TabelaLog>> GetTabelaLog(int id)
        {
            var tabelaLog = await _context.TabelaLog.FindAsync(id);

            if (tabelaLog == null)
            {
                return NotFound();
            }

            return tabelaLog;
        }

        // PUT: api/TabelaLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTabelaLog(int id, TabelaLog tabelaLog)
        {
            if (id != tabelaLog.TabelaLogId)
            {
                return BadRequest();
            }

            _context.Entry(tabelaLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TabelaLogExists(id))
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

        // POST: api/TabelaLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TabelaLog>> PostTabelaLog(TabelaLog tabelaLog)
        {
            _context.TabelaLog.Add(tabelaLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTabelaLog", new { id = tabelaLog.TabelaLogId }, tabelaLog);
        }

        // DELETE: api/TabelaLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTabelaLog(int id)
        {
            var tabelaLog = await _context.TabelaLog.FindAsync(id);
            if (tabelaLog == null)
            {
                return NotFound();
            }

            _context.TabelaLog.Remove(tabelaLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TabelaLogExists(int id)
        {
            return _context.TabelaLog.Any(e => e.TabelaLogId == id);
        }
    }
}
