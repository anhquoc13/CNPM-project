using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Application.Interfaces;
using Domain.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class SignInManager : ISignInManager
    {
        private readonly HttpContext _httpContext;
        private readonly IUserRepository _userRepository;

        public SignInManager(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<bool> PasswordSignInAsync(string id, string password, bool isPersistent)
        {
            var user = _userRepository.GetBy(id);

            if (user != null && user.status == 1)
            {
                if (user.passwd == password)
                {
                    await SignInAsync(user, isPersistent);
                    return true;
                }
            }

            return false;
        }

        public async Task SignInAsync(User user, bool isPersistent)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.ID)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = isPersistent
            };

            await _httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );
        }
    }
}