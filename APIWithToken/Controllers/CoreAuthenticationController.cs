using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APIWithToken.Extension;
using APIWithToken.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace APIWithToken.Controllers
{

   [Route("api/[controller]")]
    public class CoreAuthenticationController : Controller
    {
        //     private UserManager<ApplicationUser> _userManager;
        //  private readonly SignInManager<ApplicationUser> _signInManager;
        //  ILoggerFactory _logger;
        //public CoreAuthenticationController(SignInManager<ApplicationUser> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;

        //    _logger = loggerFactory.CreateLogger<CoreAuthenticationController>();
        //}
        //private readonly IGoogleAuthProvider _auth;

        //public CoreAuthenticationController(IGoogleAuthProvider auth)
        //{
        //    _auth = auth;
        //}

        [TempData]
        public string ErrorMessage { get; set; }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [Route("secret")]
        public IActionResult Secret()
        {
            return View(new User(this.User));
        }

        [AllowAnonymous]
        [Route("home")]
        public async Task<IActionResult> Home()
        {
            return View("Home", await HttpContext.GetExternalProvidersAsync());
           // return View(this.User.Identities.Any(v => v.IsAuthenticated));
        }

        [HttpGet("~/signin")]
        public async Task<IActionResult> SignIn() => View("SignIn", await HttpContext.GetExternalProvidersAsync());

        [HttpPost("~/signin")]
        public async Task<IActionResult> SignIn([FromForm] string provider, string returnUrl = null)
        {
            // Note: the "provider" parameter corresponds to the external
            // authentication provider choosen by the user agent.
            if (string.IsNullOrWhiteSpace(provider))
            {
                return BadRequest();
            }

            if (!await HttpContext.IsProviderSupportedAsync(provider))
            {
                return BadRequest();
            }

            // Instruct the middleware corresponding to the requested external identity
            // provider to redirect the user agent to its own authorization endpoint.
            // Note: the authenticationScheme parameter must match the value configured in Startup.cs
         //   var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "/api/CoreAuthentication/home", new {  });

            //   var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            //    return Challenge(properties, provider);

            var authProperties = new AuthenticationProperties
            {
                RedirectUri = "api/CoreAuthentication/passed"

            };

            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { authProperties });
            //var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            //return Challenge(authProperties, provider);

           // return new ChallengeResult(provider, authProperties);

          return  Challenge(authProperties,provider);


            //return Challenge(new AuthenticationProperties { RedirectUri = "/" }, provider);
        }

     //   [Authorize]
        [Route("Passed")]
        public async Task<IActionResult> Passed()
        {
            var model = await LoadUserInfoAsync();

            return View();
        }
        private async Task<IndexModel> LoadUserInfoAsync()
        {
            var model = new IndexModel();

            if (User.Identity.IsAuthenticated)
            {
                model.UserEmail = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                model.UserName = User.Claims.SingleOrDefault(c => c.Type == "name")?.Value;

                //  model.Scopes = await _auth.GetCurrentScopesAsync();
            }

            return model;
        }
        [HttpGet("~/signout"), HttpPost("~/signout")]
        public IActionResult SignOut()
        {
            // Instruct the cookies middleware to delete the local cookie created
            // when the user agent is redirected from the external identity provider
            // after a successful authentication flow (e.g Google or Facebook).
            return SignOut(new AuthenticationProperties { RedirectUri = "/" },
                CookieAuthenticationDefaults.AuthenticationScheme);
        }


        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public IActionResult ExternalLogin(string provider, string returnUrl = null)
        //{
        //    // Request a redirect to the external login provider.
        //    var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
        //    var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        //    return Challenge(properties, provider);
        //}

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        //{
        //    if (remoteError != null)
        //    {
        //        ErrorMessage = $"Error from external provider: {remoteError}";
        //        return RedirectToAction(nameof(Home));
        //    }
        //    var info = await _signInManager.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {
        //        return RedirectToAction(nameof(Home));
        //    }

        //    // Sign in the user with this external login provider if the user already has a login.
        //    var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
        //    if (result.Succeeded)
        //    {
        //        //_logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);
        //      //  return RedirectToLocal(returnUrl);
        //      return RedirectToAction(nameof(Home));
        //    }
        //    if (result.IsLockedOut)
        //    {
        //        return RedirectToAction(nameof(Home));
        //    }
        //    else
        //    {
        //        // If the user does not have an account, then ask the user to create an account.
        //        ViewData["ReturnUrl"] = returnUrl;
        //        ViewData["LoginProvider"] = info.LoginProvider;
        //        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        //        return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
        //    }
        //}

        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        //{
        //    return View("ExternalLogin", new ExternalLoginViewModel { Email = "" });
        //}

            [HttpGet]
        [AllowAnonymous]
      //  [HttpGet(nameof(ExternalLoginCallback))]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            //Here we can retrieve the claims
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return null;
        }

        
    }
    public class IndexModel
    {
      //  public IList<CourseModel> Courses { get; set; }
      //  public IReadOnlyList<string> Scopes { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
    }
}