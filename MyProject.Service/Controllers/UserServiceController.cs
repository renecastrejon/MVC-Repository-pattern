using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using static MyProject.DAL.Database.DatabaseAccess;
using static MyProject.Common.Http.HttpResponses;
using static MyProject.Common.Extensions.MappingExtensions;
using MyProject.Model;

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
                //To use directly with AutoMapper
                //var temp = Mapper.Map<List<UserViewModel>>(GetAllUsers());
                
                var users = GetAllUsers().MapTo<List<User>>();
                
                //var users = GetAllUsers();
                if (users != null)
                {
                    return Ok(users);
                }
                return ResponseMessage(CreateResponse(HttpStatusCode.NotFound, FailedResponse));
            }
            catch (Exception ex)
            {
                return ResponseMessage(CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}
