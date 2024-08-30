using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myNottes.Models;
using myNottes.ViewModel;

namespace myNottes.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<User> _usermanager { get; }
        public SignInManager<User> _signinmanager { get; }

        public AccountController(UserManager<User> usermanager,SignInManager<User> signinmanager)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName
                };
                var result= await _usermanager.CreateAsync(user,model.Password!);
                if(result.Succeeded)
                {
                    await _signinmanager.PasswordSignInAsync(user, model.Password!, false, false);
                    return RedirectToAction(nameof(Index), "Home");
                }
            }
            return View(model);
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        public async Task<IActionResult>Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result=await _signinmanager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index), "Home");
                }

            }
            return View(model);
        }
    }
}
