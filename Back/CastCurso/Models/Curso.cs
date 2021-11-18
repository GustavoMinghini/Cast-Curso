using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CastCurso.Models
{
    public class Curso
    {
      
        [Key]
        public int CursoId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CursoNome { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string DescricaoCurso { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime DtInicio { get; set; }
        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime DtTermino { get; set; }

        public int QtdAlunos { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriasId { get; set; }
    }
}
