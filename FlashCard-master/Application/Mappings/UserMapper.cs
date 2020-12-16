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
                Id = user.Id,
                ID = user.ID,
                tagname = user.tagname,
                avatar = user.avatar
            };
        }

        public static User MappingUser(this UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                ID = userDto.ID,
                tagname = userDto.tagname,
                avatar = userDto.avatar
            };
        }

        public static void MappingUser(this UserDto userDto, User user)
        {
            user.Id = userDto.Id;
            user.ID = userDto.ID;
            user.tagname = userDto.tagname;
            user.avatar = userDto.avatar;
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
