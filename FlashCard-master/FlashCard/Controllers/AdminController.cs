using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Interfaces;
using Application.ViewModels;
using Application.Helpers;
using Application.DTO;
using Domain.Entities;

namespace LearningWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserManager _userManager;
        public AdminController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index(string sortOrder, string userRole, string searchString, int pageIndex = 1)
        {
            if (!User.Identity.IsAuthenticated || !_userManager.IsAdmin(User.Identity.Name))
            {
                return RedirectToAction("Index", "Intro");
            }
            int pageSize = 5;
            int count;
            var users = _userManager.GetAll(User.Identity.Name, sortOrder, userRole, searchString, pageIndex, pageSize, out count);
            var roles = _userManager.GetRoles();

            var model = new AdminViewModel()
            {
                user = _userManager.GetBy(User.Identity.Name, User.Identity.Name),
                userList = new PaginatedList<User>(users, count, pageIndex, pageSize),
                roles = new SelectList(roles),
                UserRole = userRole,
                SearchString = searchString,
                SortOrder = sortOrder
            };

            ViewData["Page.Title"]="Quản lí tài khoản FlashCard";
            ViewData["Page.Target"]="Tài khoản";
            return View(model);
        }
        
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated || !_userManager.IsAdmin(User.Identity.Name))
            {
                return RedirectToAction("Index", "Intro");
            }
            RegisterViewModel model = new RegisterViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);

            ViewData["Page.Title"]="Tạo tài khoản - Admin";
            ViewData["Page.Target"]="Tạo tài khoản";
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModel model)
        {
            if (!User.Identity.IsAuthenticated || !_userManager.IsAdmin(User.Identity.Name))
            {
                return RedirectToAction("Index", "Intro");
            }
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            ViewData["Page.Title"]="Tạo tài khoản - Admin";
            ViewData["Page.Target"]="Tạo tài khoản";
            if (ModelState.IsValid)
            {
                if (_userManager.UserExists(model.id))
                {
                    ModelState.AddModelError(string.Empty, "Tài khoản đã tồn tại");
                    return View(model);
                }
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Mật khẩu không khớp");
                    return View(model);
                }
                User userToCreate = new User();
                userToCreate = model.data;
                userToCreate.ID = model.id;
                userToCreate.tagname = model.Tagname;
                userToCreate.email = model.Email;
                userToCreate.passwd = model.Password;
                userToCreate.createdDay = System.DateTime.Today.ToString("dd-MM-yyyy");
                userToCreate.avatar = "/resources/images/user/avt_hidden.jpg";
                if (model.userRole == "Quản trị viên" || model.userRole == "Thành viên")
                {
                    userToCreate.role = model.userRole;
                }
                if (model.userStatus == "Hoạt động")
                {
                    userToCreate.status = 1;
                }
                else userToCreate.status = 0;
                _userManager.Create(userToCreate);
                return RedirectToAction("Index", "Admin");
            }
            ViewData["Page.Title"]="Tạo tài khoản - Admin";
            ViewData["Page.Target"]="Tạo tài khoản";
            return View(model);  
        }

        public IActionResult Delete(string id)
        {
            if (!User.Identity.IsAuthenticated || !_userManager.IsAdmin(User.Identity.Name))
            {
                return RedirectToAction("Index", "Intro");
            }
            _userManager.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeRole(string id)
        {
            if (!User.Identity.IsAuthenticated || !_userManager.IsAdmin(User.Identity.Name))
            {
                return RedirectToAction("Index", "Intro");
            }
            _userManager.ChangeRole(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(string id)
        {
            if (!User.Identity.IsAuthenticated || !_userManager.IsAdmin(User.Identity.Name))
            {
                return RedirectToAction("Index", "Intro");
            }
            _userManager.ChangeStatus(id);
            return RedirectToAction("Index");
        }
    }
}
