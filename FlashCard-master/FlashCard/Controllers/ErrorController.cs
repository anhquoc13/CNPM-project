using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LearningWeb.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            ViewData["User.Username"]="Tuấn Vũ";
            ViewData["User.Avatar"]="resources/images/user/avt_1.jpg";
            ViewData["User.Email"]="abc@gmail.com";
            ViewData["User.Role"]="Quản trị viên";

            ViewData["Page.Title"]="Page Not Found";
            ViewData["Page.Target"]=ViewData["Page.Title"];
            return View();
        }
    }
}
