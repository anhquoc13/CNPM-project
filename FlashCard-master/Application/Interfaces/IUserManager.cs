using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserManager
    {
        User Register(UserDto user, string email, string password);
        void Create(User user);
        UserDto GetBy(string id);
        User GetBy(string id, string accessID);
        UserDto GetOwner(string id);
        IEnumerable<UserDto> GetAll();
        IEnumerable<User> GetAll(string accessID, string sortOrder, string userRole, string searchString, int pageIndex, int pageSize, out int count);
        IEnumerable<string> GetRoles();
        void UpdateUser(User user);
        void DeleteUser(string id);
        bool UserExists(string id);
        bool IsAdmin(string id);
        bool IsActive(string id);
        void ChangeRole(string id);
        void ChangeStatus(string id);
    }
}