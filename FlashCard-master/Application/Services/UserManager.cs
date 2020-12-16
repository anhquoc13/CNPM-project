using System.Collections.Generic;
using Application.DTO;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Register(UserDto temp, string email, string password)
        {
            User user = temp.MappingUser();
            user.email = email;
            user.passwd = password;
            user.createdDay = System.DateTime.Today.ToString("dd-MM-yyyy");
            user.role = "Thành viên";
            user.avatar = "/resources/images/user/avt_hidden.jpg";
            user.contry = "Việt Nam";
            user.status = 1;
            _userRepository.Add(user);
            
            return user;
        }

        public void Create(User user)
        {
            _userRepository.Add(user);
        }

        public bool UserExists(string id)
        {
            var user = _userRepository.GetBy(id);

            return user != null;
        }

        public UserDto GetBy(string id)
        {
            return _userRepository.GetBy(id).MappingDto();
        }

        public User GetBy(string id, string accessID)
        {
            if (IsAdmin(accessID))
            {
                return _userRepository.GetBy(id);
            }
            return _userRepository.GetBy(accessID);
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _userRepository.GetAll().MappingDto();
        }

        public IEnumerable<User> GetAll(string accessID, string sortOrder, string userRole, string searchString, int pageIndex, int pageSize, out int count)
        {
            if (IsAdmin(accessID))
            {
                return _userRepository.Filter(sortOrder, userRole, searchString, pageIndex, pageSize, out count);
            }
            return _userRepository.Filter(sortOrder, userRole, searchString, pageIndex, pageSize, out count).MappingDto().MappingUser();
        }

        public IEnumerable<string> GetRoles()
        {
            return _userRepository.GetRoles();
        }

        public UserDto GetOwner(string id)
        {
            return _userRepository.GetBy(id).MappingDto();
        }

        public bool IsAdmin(string id)
        {
            return _userRepository.GetBy(id).role == "Quản trị viên";
        }

        public bool IsActive(string id)
        {
            return _userRepository.GetBy(id).status == 1;
        }

        public void UpdateUser(User user)
        {
            var userToUpdate = _userRepository.GetBy(user.ID);

            _userRepository.Update(userToUpdate);
        }

        public void DeleteUser(string id)
        {
            var user = _userRepository.GetBy(id);

            _userRepository.Remove(user);
        }

        public void ChangeRole(string id)
        {
            User userToChange = _userRepository.GetBy(id);
            if (userToChange.role == "Quản trị viên")
            {
                userToChange.role = "Thành viên";
            }
            else userToChange.role = "Quản trị viên";
            _userRepository.Update(userToChange);
        }

        public void ChangeStatus(string id)
        {
            User userToChange = _userRepository.GetBy(id);
            if (userToChange.status == 1)
            {
                userToChange.status = 0;
                userToChange.disableDay = System.DateTime.Today.ToString("dd-MM-yyyy");
            }
            else userToChange.status = 1;
            _userRepository.Update(userToChange);
        }
    }
}