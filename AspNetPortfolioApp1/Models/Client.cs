namespace AspNetPortfolioApp1.Models;

public class Client
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<ItemClient>? ItemClients { get; set; }
}
