using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;

namespace LearningWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            UserViewModel model = new UserViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);

            ViewData["User.SetCount"]="117";
            ViewData["User.FolderCount"]="57";
            ViewData["User.ClassCount"]="7";

            ViewData["Page.Title"]=model.user.ID;
            ViewData["Page.Target"]="Hồ sơ";
            return View(model);
        }

        public IActionResult Edit(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            UserViewModel model = new UserViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            model.edit = _userManager.GetBy(id, User.Identity.Name); 
            
            ViewData["Page.Title"]=model.user.ID;
            ViewData["Page.Target"]="Hồ sơ";
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            if (!User.Identity.IsAuthenticated || !_userManager.IsAdmin(User.Identity.Name))
            {
                return RedirectToAction("Index", "Intro");
            }
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            ViewData["Page.Title"]=model.user.ID;
            ViewData["Page.Target"]="Hồ sơ";
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    model.edit = _userManager.GetBy(model.Id, User.Identity.Name);
                    ModelState.AddModelError(string.Empty, "Mật khẩu không khớp");
                    return View(model);
                }
                User userToUpdate = new User();
                userToUpdate.ID = model.Id;
                userToUpdate.tagname = model.Tagname;
                userToUpdate.email = model.Email;
                userToUpdate.passwd = model.Password;
                if (model.userRole == "Quản trị viên" || model.userRole == "Thành viên")
                {
                    userToUpdate.role = model.userRole;
                }
                if (model.userStatus == "Hoạt động")
                {
                    userToUpdate.status = 1;
                }
                else userToUpdate.status = 0;
                _userManager.UpdateUser(userToUpdate);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
                model.edit = _userManager.GetBy(model.Id, User.Identity.Name); 
            }
            return View(model);  
        }

        public IActionResult Sets(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            if(id == null || (!_userManager.IsActive(id) && !_userManager.IsAdmin(User.Identity.Name)))
            {
                id = User.Identity.Name;
            }
            UserViewModel model = new UserViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            model.owner = _userManager.GetBy(id);

            ViewData["Owner.SetCount"]="117";
            ViewData["Owner.FolderCount"]="57";
            ViewData["Owner.ClassCount"]="7";

            ViewData["Set.ID1.Name"]="Tiếng anh nhập môn";
            ViewData["Set.ID1.Count"]="2";
            ViewData["Set.ID2.Name"]="Tiếng trung cơ bản";
            ViewData["Set.ID2.Count"]="8";
            ViewData["Set.ID3.Name"]="Tiếng anh viết và đọc";
            ViewData["Set.ID3.Count"]="13";
            ViewData["Set.ID4.Name"]="TA chuyên nghành IT";
            ViewData["Set.ID4.Count"]="72";
            ViewData["Set.ID5.Name"]="Thư viện học thuật";
            ViewData["Set.ID5.Count"]="102";

            ViewData["Page.Title"]=model.user.ID;
            ViewData["Page.Target"]="Học phần";
            return View(model);
        }

        public IActionResult Folders(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            if(id == null || (!_userManager.IsActive(id) && !_userManager.IsAdmin(User.Identity.Name)))
            {
                id = User.Identity.Name;
            }
            UserViewModel model = new UserViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            model.owner = _userManager.GetBy(id);

            ViewData["Owner.SetCount"]="117";
            ViewData["Owner.FolderCount"]="57";
            ViewData["Owner.ClassCount"]="7";

            ViewData["Folder.ID1.Name"]="Tiếng trung cơ bản";
            ViewData["Folder.ID1.Count"]="2";
            ViewData["Folder.ID2.Name"]="Tiếng anh viết và đọc";
            ViewData["Folder.ID2.Count"]="11";

            ViewData["Page.Title"]=model.user.ID;
            ViewData["Page.Target"]="Thư mục";
            return View(model);
        }

        public IActionResult Classes(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            if(id == null || (!_userManager.IsActive(id) && !_userManager.IsAdmin(User.Identity.Name)))
            {
                id = User.Identity.Name;
            }
            UserViewModel model = new UserViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            model.owner = _userManager.GetBy(id);

            ViewData["Owner.SetCount"]="117";
            ViewData["Owner.FolderCount"]="57";
            ViewData["Owner.ClassCount"]="7";

            ViewData["Class.ID1.Name"]="Lớp tiếng trung cơ bản";
            ViewData["Class.ID1.setID.Count"]="2";
            ViewData["Class.ID1.userID.Count"]="11";
            ViewData["Class.ID1.School"]="SGUL • Ho Chi Minh City, Viet Nam";
            ViewData["Class.ID2.Name"]="Lớp tiếng anh viết và đọc thầy Huy";
            ViewData["Class.ID2.setID.Count"]="1";
            ViewData["Class.ID2.userID.Count"]="3";
            ViewData["Class.ID2.School"]="SGUL • Ho Chi Minh City, Viet Nam";
            ViewData["Class.ID3.Name"]="Lớp 116A - Đại học Sài Gòn SGU";
            ViewData["Class.ID3.setID.Count"]="87";
            ViewData["Class.ID3.userID.Count"]="110";
            ViewData["Class.ID3.School"]="SGUL • Ho Chi Minh City, Viet Nam";

            ViewData["Page.Title"]=model.user.ID;
            ViewData["Page.Target"]="Lớp";
            return View(model);
        }

        public IActionResult AddSet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            UserViewModel model = new UserViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);

            ViewData["Page.Title"]=model.user.ID;
            ViewData["Page.Target"]="Tạo học phần";
            return View(model);
        }

        public IActionResult AddClass()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            UserViewModel model = new UserViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);

            ViewData["Page.Title"]=model.user.ID;
            ViewData["Page.Target"]="Tạo học phần";
            return View(model);
        }
    }
}
