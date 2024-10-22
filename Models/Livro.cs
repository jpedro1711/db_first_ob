namespace efcore_dbfirst.Models;

public partial class Livro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public int Status { get; set; }

    public double NotaAvaliacao { get; set; }

    public int? SomaTotalAvaliacoes { get; set; }

    public int? TotalAvaliacoes { get; set; }

    public int GeneroLivroId { get; set; }

    public virtual GeneroLivro GeneroLivro { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
