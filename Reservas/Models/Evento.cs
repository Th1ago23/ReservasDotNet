using System.ComponentModel.DataAnnotations;

namespace Reservas.Models
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }
        [Required] 
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public decimal PrecoIngresso { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Atividade> Atividades { get; set; }
    }
}
