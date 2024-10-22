using System.ComponentModel.DataAnnotations;

namespace efcore_dbfirst.Models;

public partial class Reserva
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int StatusReserva { get; set; }

    public DateTime DataReserva { get; set; }

    public int UsuarioId { get; set; }

    public virtual ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
}
