using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.API_Response
{
    partial class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = false;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<APIError> ErrorList { get; set; } = new();
        public List<APIWarning> WarningList { get; set; } = new();


    }
}
