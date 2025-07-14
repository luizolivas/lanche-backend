using Lanche.Domain.Shared.Entities;

namespace Lanche.Domain.Entities
{
    public class CustomizationOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }


        public ICollection<FoodCustomizationOption> FoodCustomizationOptions { get; set; } = new List<FoodCustomizationOption>();
    }
}
