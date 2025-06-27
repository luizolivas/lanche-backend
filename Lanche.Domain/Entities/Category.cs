using Lanche.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<Food> Products { get; set; } = new List<Food>();
    }
}
