using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO.Product
{
    public class CreateProductDto
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int BrandId{ get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Specification { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
