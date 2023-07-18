namespace SampleLibrary;

public class Invoice : BaseModel
{
    public Customer? Customer { get; set; }
    public List<Product>? Products { get; set; }
}
