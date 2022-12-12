using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpOnlyCookie.Controllers
{
    public class HttpOnlyController : Controller
    {
        public IActionResult Only()
        {
            HttpContext.Response.Cookies.Append("email", "hsyn@hotmail.com");
            HttpContext.Response.Cookies.Append("password", "1234");
            return View();
        }


    }
}
