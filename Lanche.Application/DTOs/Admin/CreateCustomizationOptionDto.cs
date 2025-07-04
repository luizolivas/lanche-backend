using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.DTOs.Admin
{
    public class CreateCustomizationOptionDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
