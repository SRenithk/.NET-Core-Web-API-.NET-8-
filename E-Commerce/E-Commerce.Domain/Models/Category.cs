using E_Commerce.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
    public class Category : BaseModel
    {
        //Id from BaseModel

        [Required]
        public string Name { get; set; }
    }
}
