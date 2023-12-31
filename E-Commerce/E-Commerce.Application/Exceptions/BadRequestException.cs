using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        //Exception is in a Dictionary type. So Declare one.
        public IDictionary<string, string[]> ValidationErrors { get; set; }

        public BadRequestException(string message) : base(message) { }

        //ValidationResult from FluentValidations (not from DataAnnotations)
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            //Assign the Error
            ValidationErrors = validationResult.ToDictionary();
        } 
        
    }
}
