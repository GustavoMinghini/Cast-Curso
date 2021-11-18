using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CastCurso.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriasId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CategoriasNome { get; set; }
    }
}
