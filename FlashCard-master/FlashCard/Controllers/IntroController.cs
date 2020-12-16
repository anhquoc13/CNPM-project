using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTO;
using Application.ViewModels;

namespace FlashCard.Controllers
{
    public class IntroController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly ISignInManager _signInManager;

        public IntroController(IUserManager userManager, ISignInManager signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.UserExists(model.id))
                {
                    ModelState.AddModelError(string.Empty, "Tài khoản đã tồn tại");
                    return View();
                }
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Mật khẩu không khớp");
                    return View();
                }
                var userToCreate = new UserDto() { ID = model.id, tagname = model.Tagname };
                var user = _userManager.Register(userToCreate, model.Email, model.Password);

                _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            return View();  
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var succeed = await _signInManager.PasswordSignInAsync(model.id, model.Password, model.RememberMe);

                if (succeed)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Sai tài khoản hoặc mật khẩu");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Intro");
        }
    }
}