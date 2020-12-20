using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ViewModels;
using Application.DTO;

namespace LearningWeb.Controllers
{
    public class SetsController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly ICourseServices _courseServices;
        public SetsController(IUserManager userManager, ICourseServices courseServices)
        {
            _userManager = userManager;
            _courseServices = courseServices;
        }
        public IActionResult Index(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            SetsViewModel model = new SetsViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            model.question = _courseServices.GetVocalbulary(id);

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
            model.question = _courseServices.GetVocalbulary(id);
            model.answer = model.question;
            foreach (var answer in model.answer)
            {
                answer.explain = "Nhập đáp án ...";
            }

            ViewData["Page.Title"]="Kiểm tra học phần";
            ViewData["Page.Target"]="Kiểm tra";
            return View(model);
        }

        [HttpPost]
        public IActionResult TestOfSet(int id, SetsViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            SetsViewModel result = new SetsViewModel();
            result.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            result.question = _courseServices.GetVocalbulary(id);
            result.answer = model.answer;
            result.IsFinish = true;
            result.CorrectCount = 0;
            result.QuestionCount = 0;
            foreach (var question in result.question)
            {
                if (model.answer.FirstOrDefault(a => a.ID == question.ID).explain == question.explain)
                {
                    question.result = "true";
                    result.CorrectCount++;
                }
                else question.result = "false";
                result.QuestionCount++;
            }
            result.Point = result.CorrectCount/result.QuestionCount;
            ViewData["Page.Title"]="Kiểm tra học phần";
            ViewData["Page.Target"]="Kiểm tra";
            return View(result);
        }
    }
}
