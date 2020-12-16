using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Interfaces;
using Application.ViewModels;

namespace FlashCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserManager _userManager;

        public HomeController(ILogger<HomeController> logger, IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            HomeViewModel model = new HomeViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            ViewData["Page.Title"]=model.user.ID;
            ViewData["Page.Target"]="Trang chủ";
            return View(model);
        }
    }
}
