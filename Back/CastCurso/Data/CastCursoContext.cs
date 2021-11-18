using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CastCurso.Models;

namespace CastCurso.Data
{
    public class CastCursoContext : DbContext
    {
        public CastCursoContext (DbContextOptions<CastCursoContext> options)
            : base(options)
        {
        }

        public DbSet<CastCurso.Models.Curso> Curso { get; set; }

        public DbSet<CastCurso.Models.Categorias> Categorias { get; set; }

        public DbSet<CastCurso.Models.Usuarios> Usuarios { get; set; }

        public DbSet<CastCurso.Models.TabelaLog> TabelaLog { get; set; }
    }
}
