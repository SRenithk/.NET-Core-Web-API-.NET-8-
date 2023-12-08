using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.API_Response
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = false;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<APIError> ErrorList { get; set; } = [];
        public List<APIWarning> WarningList { get; set; } = [];
        public void AddError (string errorMessage)
        {
            APIError error = new APIError(description: errorMessage);
            ErrorList.Add(error);
        }
        public void AddWarning (string warningMessage) 
        {
            APIWarning warning = new APIWarning(description: warningMessage);
            WarningList.Add(warning);
        }
    }
}
