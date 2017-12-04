using MyProject.BLL.HTTP;
using MyProject.IBLL;
using MyProject.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.BLL
{

    public class UserRepository : IRepository<User>
    {
        private HttpMethods _httpMethods;
        public async Task<IEnumerable<User>> GetAll()
        {
            _httpMethods = new HttpMethods();
            var users = await _httpMethods.GET<List<User>>(); //APIRootAddress.Root, "GetMachine"
            return users;
        }

        public string Add(User entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get()
        {
            throw new NotImplementedException();
        }        

        public string Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}