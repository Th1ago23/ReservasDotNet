using Microsoft.EntityFrameworkCore;
using Reservas.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Reservas.Data
{
    public class ReservasContext : DbContext
    {
        public ReservasContext(DbContextOptions<ReservasContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<ParticipanteAtividade> ParticipanteAtividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para o campo PrecoIngresso da entidade Evento
            modelBuilder.Entity<Evento>()
                .Property(e => e.PrecoIngresso)
                .HasColumnType("decimal(18,2)"); // Define precisão e escala

            // Configuração de chave composta para ParticipanteAtividade
            modelBuilder.Entity<ParticipanteAtividade>()
                .HasKey(pa => new { pa.IdParticipante, pa.IdAtividade });

            modelBuilder.Entity<ParticipanteAtividade>()
                .HasOne(pa => pa.Participante)
                .WithMany(p => p.ParticipanteAtividades)
                .HasForeignKey(pa => pa.IdParticipante);

            modelBuilder.Entity<ParticipanteAtividade>()
                .HasOne(pa => pa.Atividade)
                .WithMany(a => a.ParticipanteAtividades)
                .HasForeignKey(pa => pa.IdAtividade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
