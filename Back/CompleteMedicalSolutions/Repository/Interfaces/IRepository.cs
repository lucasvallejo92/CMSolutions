using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Enums;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAllAsync();
        Task<T> GetAsync(int identifier);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(int identifier, T entity);
        Task<ResponseType> DeleteAsync(int identifier);
    }
}