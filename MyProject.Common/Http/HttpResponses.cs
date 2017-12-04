using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Http
{
    public static class HttpResponses
    {
        public static readonly string FailedResponse = "Failed Response";
        public static HttpResponseMessage CreateResponse(HttpStatusCode httpStatusCode, string message)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.ReasonPhrase = message;
            response.StatusCode = httpStatusCode;
            return response;
        }
    }
}
