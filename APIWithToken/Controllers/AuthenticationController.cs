﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIWithToken.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}