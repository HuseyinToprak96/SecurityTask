using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace HttpOnlyCookie.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    [ApiController]
    public class OnlyCookieController : ControllerBase
    {
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IHttpActionResult Get()
        {
            var mvc = new NameValueCollection();
            mvc["some-unique-key"] = "hsyn@hotmail.com";
            var cookie = new CookieHeaderValue("email", mvc)
            {
                HttpOnly = true,
                Domain = "",
                Path = "/api"
            };
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Headers.AddCookies(new[] { cookie });
            return new ResponseMessageResult(response);
        }
    }
}
