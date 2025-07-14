public class CustomizationOptionDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public bool IsActive { get; set; }
}

public class CreateCustomizationOptionDTO
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}