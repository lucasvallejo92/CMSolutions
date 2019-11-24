using System.Threading.Tasks;
using Repository.Enums;
using Repository.Models;

namespace Repository.Interfaces
{
    public interface IAuthRepository<T> where T: class
    {
        Task<T> AuthorizeAsync(UserCredentials credentials);
    }
}