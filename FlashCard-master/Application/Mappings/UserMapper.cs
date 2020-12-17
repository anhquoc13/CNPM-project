using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Application.Mappings
{
    public static class UserMapper
    {
        public static UserDto MappingDto(this User user)
        {
            return new UserDto
            {
                ID = user.ID,
                tagname = user.tagname,
                avatar = user.avatar,
                email = user.email,
                role = user.role
            };
        }

        public static User MappingUser(this UserDto userDto)
        {
            return new User
            {
                ID = userDto.ID,
                tagname = userDto.tagname,
                avatar = userDto.avatar,
                email = userDto.email,
                role = userDto.role
            };
        }

        public static void MappingUser(this UserDto userDto, User user)
        {
            user.ID = userDto.ID;
            user.tagname = userDto.tagname;
            user.avatar = userDto.avatar;
            user.email = userDto.email;
            user.role = userDto.role;
        }

        public static IEnumerable<UserDto> MappingDto(this IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                yield return user.MappingDto();
            }
        }

        public static IEnumerable<User> MappingUser(this IEnumerable<UserDto> usersDto)
        {
            foreach (var userDto in usersDto)
            {
                yield return userDto.MappingUser();
            }
        }

    }
}
