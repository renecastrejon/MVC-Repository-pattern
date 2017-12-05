using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.IBLL;
using MyProject.Model;
using MyProject.Model.ViewModels;
using MyProject.IBLL.Service;

namespace MyProject.BLL.Service
{
    public class UserServiceRepository : IUserService
    {
        private readonly IRepository<User> _useRepository;

        public UserServiceRepository(IRepository<User> userRepository)
        {
            _useRepository = userRepository;
        }
        public IEnumerable<UserViewModel> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetBy(Guid userid)
        {
            throw new NotImplementedException();
        }
    }
}
