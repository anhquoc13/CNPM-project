using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ViewModels;

namespace LearningWeb.Controllers
{
    public class FoldersController : Controller
    {
        private readonly IUserManager _userManager;
        public FoldersController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            FoldersViewModel model = new FoldersViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);

            ViewData["Page.Title"]="Tiếng anh viết và đọc";
            ViewData["Page.Target"]="Học phần";
            return View(model);
        }
    }
}
