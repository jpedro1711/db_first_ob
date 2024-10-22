namespace efcore_dbfirst.Models;

public partial class GeneroLivro
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
}
