using System;
using System.Net;
using System.Web.Http;
using static MyProject.DAL.Database.DatabaseAccess;
using static MyProject.Common.Http.HttpResponses;

namespace MyProject.Service.Controllers
{
    public class UserServiceController : ApiController
    {
        [HttpGet]
        [ActionName("GetUsers")]
        public IHttpActionResult GetUsers()
        {
            try
            {
                var users = GetUsersDb();
                if (users != null)
                    return Ok(users);
                return ResponseMessage(CreateResponse(HttpStatusCode.NotFound, FailedResponse));
            }
            catch (Exception ex)
            {
                return ResponseMessage(CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}
