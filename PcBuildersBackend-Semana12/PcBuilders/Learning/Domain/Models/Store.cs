namespace PcBuilders.Learning.Domain.Model;

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; }
    //Linking
    public IList<Product> Products { get; set; } = new List<Product>();
}