using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reservas.Models
{
    public class Atividade
    {
        [Key]
        public int IdAtividade { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeAtividade { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public ICollection<ParticipanteAtividade> ParticipanteAtividades { get; set; }
    }
}
