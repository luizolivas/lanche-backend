using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.DTOs.Shared.DTOs
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public decimal price { get; set; }
        public string imageUrl { get; set; } = string.Empty;
        public int idCategory { get; set; }
    }

}
