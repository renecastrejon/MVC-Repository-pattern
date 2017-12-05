using MyProject.IBLL;
using MyProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyProject.BLL;
using AutoMapper;
using MyProject.Model.ViewModels;

namespace MVC_Dependency_Injection.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _user = null;

        //CONSTRUCTOR
        public UserController(IRepository<User> user)
        {
            this._user = user;
        }
        
        // GET: User
        public async Task<ActionResult> Index()
        {
            
            var viewModel = Mapper.Map<IEnumerable<UserViewModel>>(await _user.GetAll());
            return View(viewModel);
        }
    }
}