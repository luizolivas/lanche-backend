using Lanche.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Domain.Entities
{
    public class FoodCustomizationOption
    {
        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int CustomizationOptionId { get; set; }
        public CustomizationOption CustomizationOption { get; set; }
    }
}
