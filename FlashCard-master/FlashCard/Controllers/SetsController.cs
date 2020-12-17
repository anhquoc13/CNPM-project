using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ViewModels;

namespace LearningWeb.Controllers
{
    public class SetsController : Controller
    {
        private readonly IUserManager _userManager;
        public SetsController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            SetsViewModel model = new SetsViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);

            ViewData["Page.Title"]="Tiếng anh nhập môn";
            ViewData["Page.Target"]="Học phần";
            return View(model);
        }

        public IActionResult TestOfSet(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            SetsViewModel model = new SetsViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);

            ViewData["Page.Title"]="Kiểm tra học phần";
            ViewData["Page.Target"]="Kiểm tra";
            return View(model);
        }

        public IActionResult TestOfSet(SetsViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);

            ViewData["Page.Title"]="Kiểm tra học phần";
            ViewData["Page.Target"]="Kiểm tra";
            return View(model);
        }
    }
}
