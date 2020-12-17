using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ViewModels;

namespace LearningWeb.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IUserManager _userManager;
        public ClassesController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            ClassesViewModel model = new ClassesViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            ViewData["Class.Name"]="Lớp 116A - Đại học Sài Gòn SGU";
            ViewData["Class.School"]="SGUL • Ho Chi Minh City, Viet Nam";
            ViewData["Class.Link"]="https://flashcard.com/join/T7cMjJefS";
            ViewData["Class.SetCount"]="3";
            ViewData["Class.MemberCount"]="4";
            ViewData["Class.Describe"]="Mô tả lớp ...";

            ViewData["Class.Member1.Name"]="Tuấn Vũ";
            ViewData["Class.Member1.Role"]="Quản trị viên";
            ViewData["Class.Member1.Avatar"]="/resources/images/user/avt_1.jpg";
            ViewData["Class.Member2.Name"]="Hải Lương";
            ViewData["Class.Member2.Role"]="Thành viên";
            ViewData["Class.Member2.Avatar"]="/resources/images/user/avt_2.jpg";
            ViewData["Class.Member3.Name"]="Minh Thiện";
            ViewData["Class.Member3.Role"]="Thành Viên";
            ViewData["Class.Member3.Avatar"]="/resources/images/user/avt_3.jpg";
            ViewData["Class.Member4.Name"]="Lê Huy";
            ViewData["Class.Member4.Role"]="Thành Viên";
            ViewData["Class.Member4.Avatar"]="/resources/images/user/avt_4.jpg";

            ViewData["Page.Title"]=ViewData["Class.Name"];
            ViewData["Page.Target"]="Học phần";
            return View(model);
        }
    }
}
