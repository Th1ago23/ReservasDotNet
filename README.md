# 🎉 Sistema de Reserva de Eventos 🎉

Bem-vindo ao sistema definitivo para gerenciamento de eventos! Com funcionalidades inovadoras e uma interface amigável, organizar e participar de eventos nunca foi tão fácil e divertido.

## 🌟 Funcionalidades

### 📅 Gestão de Eventos
- Crie, edite e exclua eventos com facilidade.
- Categorize seus eventos para uma organização perfeita.
- Configure horários e locais para manter tudo sob controle.

### 🎟️ Reserva de Ingressos
- Venda e reserve ingressos online de forma prática.
- Emita bilhetes eletrônicos com QR codes para validação rápida.
- Gerencie lotes de ingressos com diferentes preços e promoções.

### 👥 Gestão de Participantes
- Registre e controle participantes para cada evento.
- Envie convites e confirme presença com um clique.
- Atribua atividades específicas aos participantes.

### 🛠️ Atividades Adicionais
- Crie atividades dentro dos eventos (workshops, palestras, etc.).
- Gerencie inscrições para atividades específicas.
- Controle a presença nas atividades com precisão.

## 🏗️ Estrutura do Projeto

### Models
- Evento.cs
- Reserva.cs
- Participante.cs
- Local.cs
- EventoParticipante.cs

### Data
- Context.cs


## 🛠️ Tecnologias Utilizadas
- .NET Core 6
- Entity Framework Core
- SQL Server
- ASP.NET Core

## 🚀 Configuração do Ambiente

### Instalação
Clone este repositório:

```bash
git clone https://github.com/seuusuario/seurepositorio.git
```
## 📂 Navegue até o diretório do projeto:
```bash
cd seurepositorio
```
## 🔄 Restaure as dependências:
```bash
dotnet restore
```

## 🛠️ Configuração do Banco de Dados
### Adicione a string de conexão no arquivo appsettings.json:
```bash
{
  "ConnectionStrings": {
    "DbConnection": "Server=seu_servidor;Database=sua_base_de_dados;User Id=seu_usuario;Password=sua_senha;"
  }
}
```
## Aplique as migrações para criar o banco de dados:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## ▶️ Execução
### Execute o projeto:

```bash
dotnet run
```
## 🔧 Estrutura de Classes e Relacionamentos
### Modelo de Dados
#### Evento
```bash
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

```
#### Reserva
```bash
public class Reserva
{
    [Key]
    public int ReservaId { get; set; }
    [ForeignKey("Evento")]
    public int EventoId { get; set; }
    public Evento Evento { get; set; }
    [ForeignKey("Participante")]
    public int ParticipanteId { get; set; }
    public Participante Participante { get; set; }
}
```
#### Participante
```bash
public class Participante
{
    public int IdParticipante { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public TipoParticipante Tipo { get; set; }
    public ICollection<Reserva> Reservas { get; set; }
    public ICollection<ParticipanteAtividade> ParticipanteAtividades { get; set; }
}
```
#### TipoParticipante
``` bash
public enum TipoParticipante
{
    Palestrante,
    Participante,
    Colaborador
}
```
#### Atividade
```bash
public class Atividade
{
    public int IdActivity { get; set; }
    public string NameActivity { get; set; }
    public DateTime Date { get; set; }
    public ICollection<ParticipanteAtividade> ParticipanteAtividades { get; set; }
}
```
#### ParticipanteAtividade
```bash
public class ParticipanteAtividade
{
    public int IdParticipante { get; set; }
    public Participante Participante { get; set; }
    public int IdActivity { get; set; }
    public Atividade Atividade { get; set; }
}
```
#### Contexto do Banco de Dados
``` bash
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) {}

    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Participante> Participantes { get; set; }
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<ParticipanteAtividade> ParticipanteAtividades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParticipanteAtividade>()
            .HasKey(pa => new { pa.IdParticipante, pa.IdActivity });

        modelBuilder.Entity<ParticipanteAtividade>()
            .HasOne(pa => pa.Participante)
            .WithMany(p => p.ParticipanteAtividades)
            .HasForeignKey(pa => pa.IdParticipante);

        modelBuilder.Entity<ParticipanteAtividade>()
            .HasOne(pa => pa.Atividade)
            .WithMany(a => a.ParticipanteAtividades)
            .HasForeignKey(pa => pa.IdActivity);
    }
}
```
## 🤝 Contribuição
### Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.
