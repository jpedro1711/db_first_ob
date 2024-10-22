using System.ComponentModel.DataAnnotations;

namespace efcore_dbfirst.Models;

public partial class Emprestimo
{
    [Key]
    public int Id { get; set; }

    public int ReservaId { get; set; }

    public DateTime DataDevolucao { get; set; }

    public int StatusEmprestimo { get; set; }

    public virtual Reserva Reserva { get; set; } = null!;
}
