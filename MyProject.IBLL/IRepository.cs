using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.IBLL
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        T Get();
        string Add(T entity);
        string Update(T entity);
        string Delete(int id);
    }
}
