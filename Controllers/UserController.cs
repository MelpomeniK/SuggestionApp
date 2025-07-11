using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;
using SuggestionApp.Services;

namespace UserMvcApp.Controllers
{
    public class UserController : Controller
    {

        private readonly UserServices _userServices;
        public List<Error> ErrorArray { get; set; } = new();

        public UserController(UserServices userService)
        {
            _userServices = userService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            ClaimsPrincipal principal = HttpContext.User;
            if (principal.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(UserSignupDTO request)
        {
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState.Values)
                {
                    ViewData["ErrorArray"] = ErrorArray;
                }
                return View();
            }

            try
            {
                await _userServices.SignUpUserAsync(request);
            }
            catch (Exception e)
            {
                ViewData["ErrorArray"] = ErrorArray;
                return View();
            }
            return RedirectToAction("SignUp", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO credentials)
        {
            var user = await _userServices.LoginUserAsync(credentials);
            if (user == null)
            {
                ViewData["ValidateMessage"] = "Error: Username / Password invalid";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, credentials.Username!)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return View("/index");
        }
    }
}
