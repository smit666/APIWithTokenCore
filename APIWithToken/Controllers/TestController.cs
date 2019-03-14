using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIWithToken.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        [Route("api/Test")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("api/Test")]
        public string GetReq()
        {
            return "1";
        }
    }
}