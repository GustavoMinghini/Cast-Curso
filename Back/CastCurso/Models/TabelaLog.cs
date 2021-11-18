using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CastCurso.Models
{
    public class TabelaLog
    {
        [Key]
        public int TabelaLogId { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? DtInclusao { get; set; }

        [Column(TypeName = "DateTime")]
        
        public DateTime? dtUltimaAtt { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string UsuarioResponsavel { get; set; }

        [ForeignKey("CursoId")]
        public int CursoId { get; set; }
    }
}
