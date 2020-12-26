using System.Threading.Tasks;
using API.Domain.Dtos;

namespace API.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}
