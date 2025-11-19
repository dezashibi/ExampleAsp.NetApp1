using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetPortfolioApp1.Models;

public class SerialNumber
{
    public int Id { get; set; }
    public required string Number { get; set; }

    public int? ItemId { get; set; }

    [ForeignKey(nameof(ItemId))]
    public Item? Item { get; set; }
}
