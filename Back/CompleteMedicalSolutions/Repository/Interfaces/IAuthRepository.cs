using System.Threading.Tasks;
using Repository.Enums;

namespace Repository.Interfaces
{
    public interface IAuthRepository<T> where T: class
    {
        Task<ResponseType> AuthorizeAsync(T credentials);
    }
}