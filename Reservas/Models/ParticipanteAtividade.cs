using System.ComponentModel.DataAnnotations.Schema;

namespace Reservas.Models
{
    public class ParticipanteAtividade
    {
        [ForeignKey("Participante")]
        public int IdParticipante { get; set; }
        public Participante Participante { get; set; }
        [ForeignKey("Atividade")]
        public int IdAtividade { get; set; }
        public Atividade Atividade { get; set; }
    }
}
