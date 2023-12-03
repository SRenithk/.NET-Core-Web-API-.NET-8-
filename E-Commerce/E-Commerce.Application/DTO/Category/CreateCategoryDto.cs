using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO.Category
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
