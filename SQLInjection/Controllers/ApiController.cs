using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SQLInjection.APIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SQLInjection.Controllers
{
    public class ApiController : Controller
    {
        private readonly IApiHandler _apiHandler;

        public ApiController(IApiHandler apiHandler)
        {
            _apiHandler = apiHandler;
        }

        public IActionResult Index()
        {
            using (WebClient client = new WebClient())
            {
                ViewBag.Screen = client.UploadString("http://testasp.vulnweb.com", WebRequestMethods.Http.Get);
            }
            return View();
        }
        public IActionResult Search()
        {
            using (WebClient client = new WebClient())
            {
                ViewBag.Screen = client.UploadString("http://rest.vulnweb.com", WebRequestMethods.Http.Get);
            }
            return View();
        }
    }
}
