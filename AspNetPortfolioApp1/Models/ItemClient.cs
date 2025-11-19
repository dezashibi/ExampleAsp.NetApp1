namespace AspNetPortfolioApp1.Models;

public class ItemClient
{
    public int Id { get; set; }

    public required int ItemId { get; set; }
    public required Item Item { get; set; }

    public required int ClientId { get; set; }
    public required Client Client { get; set; }
}
