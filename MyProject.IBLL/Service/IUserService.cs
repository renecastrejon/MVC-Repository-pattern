using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Model.ViewModels;


namespace MyProject.IBLL.Service
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();
        UserViewModel GetBy(Guid userid);
    }
}
