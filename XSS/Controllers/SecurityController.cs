using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XSS.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            //Reflected XSS
            //Stored XSS
            // General Cookie Ready
            //Clean script

            return View();
        }
        public IActionResult CommentAdd()
        {
            //Reflected XSS
            HttpContext.Response.Cookies.Append("email", "hsyn@hotmail.com");
            HttpContext.Response.Cookies.Append("password", "1234");
            return View();
        }
        [HttpPost]
        public IActionResult CommentAdd(string name,string comment)
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();
            var sanitized = sanitizer.Sanitize(comment, "https://www.example.com");
            //Clean html(success)
            ViewBag.Name = name;
            ViewBag.Comment = sanitized;
            return View();
        }
        public IActionResult StoredXSS()
        {
            //Malicious Code write in Database(All Users Cookie Ready)
            HttpContext.Response.Cookies.Append("email", "hsyn@hotmail.com");
            HttpContext.Response.Cookies.Append("password", "1234");
            if (System.IO.File.Exists("comment.txt"))
            {
                ViewBag.comments = System.IO.File.ReadAllLines("comment.txt");
            }
            return View();
        }
        [HttpPost]
        public IActionResult StoredXSS(string name,string comment)
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();
            var sanitized = sanitizer.Sanitize(comment, "https://www.example.com");
            System.IO.File.AppendAllText("comment.txt", $"{name}---{sanitized}\n");

            return RedirectToAction("StoredXSS");
        }
    }
}
