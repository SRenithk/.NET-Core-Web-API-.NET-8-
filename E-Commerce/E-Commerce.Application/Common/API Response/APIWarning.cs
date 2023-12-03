using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.API_Response
{
    public class APIWarning
    {
        private string _description;
        public APIWarning(string description)
        {
            _description = description;
        }
    }
}
