using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISignInManager
    {
        Task SignInAsync(User user, bool isPersistent);
        Task<bool> PasswordSignInAsync(string id, string password, bool isPersistent);
    }
}