using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Interfaces;
using Application.ViewModels;
using Application.Mappings;

namespace FlashCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserManager _userManager;
        private readonly ICourseServices _courseServices;
        private readonly IFolderServices _folderServices;
        private readonly IClassServices _classServices;

        public HomeController(ILogger<HomeController> logger, IUserManager userManager, ICourseServices courseServices, IFolderServices folderServices, IClassServices classServices)
        {
            _logger = logger;
            _userManager = userManager;
            _courseServices = courseServices;
            _folderServices = folderServices;
            _classServices = classServices;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            HomeViewModel model = new HomeViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name).MappingDto();
            model.user.CourseCount = _courseServices.CourseCount(User.Identity.Name);
            model.user.FolderCount = _folderServices.FolderCount(User.Identity.Name);
            model.user.ClassCount = _classServices.ClassCount(User.Identity.Name);
            ViewData["Page.Title"] = model.user.ID;
            ViewData["Page.Target"]="Trang chủ";
            return View(model);
        }
    }
}
