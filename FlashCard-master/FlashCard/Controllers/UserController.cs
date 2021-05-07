using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ViewModels;
using Application.DTO;
using Domain.Entities;
using System.Linq;
using System.Collections.Generic;

namespace LearningWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IVocabularyServices _vocabularyServices;
        private readonly ICourseServices _courseServices;
        private readonly IFolderServices _folderServices;
        private readonly IClassServices _classServices;
        public UserController(IUserManager userManager, ICourseServices courseServices, IFolderServices folderServices, IClassServices classServices, IVocabularyServices vocabularyServices)
        {
            _userManager = userManager;
            _courseServices = courseServices;
            _folderServices = folderServices;
            _classServices = classServices;
            _vocabularyServices = vocabularyServices;
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
            if (string.IsNullOrEmpty(id))
            {
                id = User.Identity.Name;
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
            model.owner.CourseCount = _courseServices.CourseCount(id);
            model.owner.FolderCount = _folderServices.FolderCount(id);
            model.owner.ClassCount = _classServices.ClassCount(id);

            model.setList = new List<SetsViewModel>();
            foreach(var course in _courseServices.GetCoureList(id))
            {
                SetsViewModel temp = new SetsViewModel();
                temp.ID = course.ID;
                temp.Name = course.name;
                temp.count = _courseServices.GetVocabulary(course.ID).Count();

                model.setList.Add(temp);
            }

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
            model.owner.CourseCount = _courseServices.CourseCount(id);
            model.owner.FolderCount = _folderServices.FolderCount(id);
            model.owner.ClassCount = _classServices.ClassCount(id);

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
            model.owner.CourseCount = _courseServices.CourseCount(id);
            model.owner.FolderCount = _folderServices.FolderCount(id);
            model.owner.ClassCount = _classServices.ClassCount(id);

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
            SetsViewModel model = new SetsViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);

            ViewData["Page.Title"]=model.user.ID;
            ViewData["Page.Target"]="Tạo học phần";
            return View(model);
        }

        [HttpPost]
        public IActionResult AddSet(SetsViewModel model)
        {
            var courseToCreate = new CourseDto()
            {
                IDuser = _userManager.GetBy(User.Identity.Name, User.Identity.Name).ID,
                name = model.Name,
                describe = model.Describe,
                link = ""
            };
            _courseServices.CreateCourse(courseToCreate);

            for(int i = 0; i < model.Term.Count(); i++)
            {
                VocabularyDto vocabularyToCreate = new VocabularyDto()
                {
                    define = model.Term.ElementAt(i),
                    explain = model.DescribeTerm.ElementAt(i),
                    image = ""
                };
                _vocabularyServices.CreateVocabulary(vocabularyToCreate);
                _vocabularyServices.CreateListVocabulary(_courseServices.GetNewestID(), _vocabularyServices.GetNewestID());
            }
            return RedirectToAction("Index", "Home");
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
