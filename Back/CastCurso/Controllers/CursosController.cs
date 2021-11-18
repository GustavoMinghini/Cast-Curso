using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CastCurso.Data;
using CastCurso.Models;
using System.Net;

namespace CastCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly CastCursoContext _context;

        public CursosController(CastCursoContext context)
        {
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
        {
            
            return await _context.Curso.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Curso.FindAsync(id);

            

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.CursoId)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
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

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {

            if (VerificarDescricaoExistente(curso.CursoNome))
            {
                var message = string.Format("Curso ja Existente.");
                return BadRequest(message);
            }
            if (DadosInvalidos(curso))
            {
                var message = string.Format("Existe(m) curso(s) planejados(s) dentro do período informado.");
                return BadRequest(message);
            }

            if (curso.DtInicio > curso.DtTermino || curso.DtInicio < DateTime.Now)
            {
                return BadRequest("");
            }

            _context.Curso.Add(curso);
            
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Deu certo", id = curso.CursoId });
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            if (TestarDateTermino(id))
            {
                var curso = await _context.Curso.FindAsync(id);
                if (curso == null)
                {
                    return NotFound();
                }

                _context.Curso.Remove(curso);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            else
            {
                var message = string.Format("Esse curso ja foi finalizado nao é possivel a exclusão");
                return BadRequest(message);
            }
           
        }

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.CursoId == id);
        }

        private bool DadosInvalidos(Curso curso)
        {
            IQueryable<Curso> model = _context.Curso;
            
                model = model.Select(row => row);


            foreach (var item in model)
            {
               if((curso.DtInicio <= item.DtTermino)&& (item.DtInicio <= curso.DtTermino))
                {
                    return true;
                }

            }


            return false;
        }

        private bool TestarDateTermino(int id)
        {
            IQueryable<Curso> model = _context.Curso;
            
            

            if (!string.IsNullOrEmpty(id.ToString()))
            {
                model = model.Where(row => row.CursoId == id);

            }

            foreach (var item in model)
            {
                if (item.DtTermino > DateTime.Now)
                {
                    return true;
                }

            }
            return false;
        }
        private bool VerificarDescricaoExistente(string nome)
        {
            IQueryable<Curso> model = _context.Curso;



            if (!string.IsNullOrEmpty(nome))
            {
                model = model.Where(row => row.CursoNome.Equals(nome));

            }

            foreach (var item in model)
            {
               if(item.CursoNome == nome)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
