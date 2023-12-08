using E_Commerce.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
    public class Brand : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int EstablishedYear { get; set; }
    }
}
