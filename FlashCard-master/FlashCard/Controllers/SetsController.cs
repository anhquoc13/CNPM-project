using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ViewModels;
using Application.DTO;
using System;

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
            TestOfSetsViewModel model = new TestOfSetsViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            model.course = _courseServices.GetBy(id);
            model.question = _courseServices.GetVocabulary(id);
            
            ViewData["Page.Title"]= model.name;
            ViewData["Page.Target"]="Học phần";
            return View(model);
        }

        public IActionResult LearnOfSet(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            TestOfSetsViewModel model = new TestOfSetsViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            model.name = _courseServices.GetBy(id).name;
            model.question = _courseServices.GetVocabulary(id);

            ViewData["Page.Title"] = "Ôn tập học phần";
            ViewData["Page.Target"] = "Ôn tập";
            return View(model);
        }

        [HttpPost]
        public IActionResult LearnOfSet(int id, TestOfSetsViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            if (model.answer == null)
            {
                return RedirectToAction("TestOfSet", "Sets");
            }
            TestOfSetsViewModel result = new TestOfSetsViewModel();
            result.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            result.name = model.name;
            result.question = _courseServices.GetVocabulary(id);
            result.result = new List<bool>();
            foreach (var q in result.question)
                result.result.Add(false);
            result.IsFinish = true;
            result.CorrectCount = 0;
            result.answer = model.answer;
            for (int i = 0; i < result.question.Count(); i++)
            {
                if (model.answer[i] == result.question.ElementAt(i).explain)
                {
                    result.result[i] = true;
                    result.CorrectCount++;
                }
                else result.result[i] = false;
            }
            ViewData["Page.Title"] = "Ôn tập học phần";
            ViewData["Page.Target"] = "Ôn tập";
            return View(result);
        }

        public IActionResult TestOfSet(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            TestOfSetsViewModel model = new TestOfSetsViewModel();
            model.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            model.name = _courseServices.GetBy(id).name;
            model.question = _courseServices.GetVocabulary(id);

            ViewData["Page.Title"]="Kiểm tra học phần";
            ViewData["Page.Target"]="Kiểm tra";
            return View(model);
        }

        [HttpPost]
        public IActionResult TestOfSet(int id, TestOfSetsViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Intro");
            }
            if (model.answer == null)
            {
                return RedirectToAction("TestOfSet", "Sets");
            }
            TestOfSetsViewModel result = new TestOfSetsViewModel();
            result.user = _userManager.GetBy(User.Identity.Name, User.Identity.Name);
            result.name = model.name;
            result.question = _courseServices.GetVocabulary(id);
            result.result = new List<bool>();
            foreach(var q in result.question)
                result.result.Add(false);
            result.IsFinish = true;
            result.CorrectCount = 0;
            result.answer = model.answer;
            result.QuestionCount = result.question.Count();
            for(int i = 0; i < result.question.Count(); i++)
            {
                if(model.answer[i] == result.question.ElementAt(i).explain)
                {
                    result.result[i] = true;
                    result.CorrectCount++;
                }
                else result.result[i] = false;
            }
            result.Point = (float) (result.CorrectCount/result.QuestionCount)*10;
            ViewData["Page.Title"]="Kiểm tra học phần";
            ViewData["Page.Target"]="Kiểm tra";
            return View(result);
        }
    }
}
