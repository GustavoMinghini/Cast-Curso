using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CastCurso.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string NomeUsuario { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Login { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Senha { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Cargo { get; set; }
    }
}
