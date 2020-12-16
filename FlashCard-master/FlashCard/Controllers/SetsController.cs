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
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            SetsViewModel model = new SetsViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            ViewData["Set.Name"]="Tiếng anh nâng cao";
            ViewData["Set.Owner.Username"]="Hải Lương";
            ViewData["Set.Owner.Avatar"]="resources/images/user/avt_2.jpg";
            ViewData["Set.Describe"]="Mô tả ...";

            ViewData["Set.Card1.Term"]="Hello";
            ViewData["Set.Card1.Definition"]="Xin chào";
            ViewData["Set.Card2.Term"]="Goodbye";
            ViewData["Set.Card2.Definition"]="Tạm biệt";
            ViewData["Set.Card3.Term"]="Apple";
            ViewData["Set.Card3.Definition"]="Quả táo";

            ViewData["Folder.SetID.Name1"]="TA IT";
            ViewData["Folder.SetID.Name2"]="Tiếng anh Basic";

            ViewData["Page.Title"]=ViewData["Set.Name"];
            ViewData["Page.Target"]="Học phần";
            return View(model);
        }
    }
}
