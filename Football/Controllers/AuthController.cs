using BLL.Helper;
using BLL.IService;
using BLL.Service;
using DAL.Entities;
using Football.Models.AuthVM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sendmail.NewFolder;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;
        private readonly ISendMailService _sendMailService;
        
        public AuthController(UserManager<ApplicationUser> userManager,IAuthService authService, ISendMailService sendMailService)
        {
            _userManager = userManager;
            _authService = authService;
            _sendMailService = sendMailService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(registerModel);
            return Ok(result);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var result = await _authService.LoginAsync(loginUser);
            return Ok(result);
        }
        //[HttpPost]
        //public async Task<IActionResult> sendMail(MailVM mailVM)
        //{
        //    await _sendMailService.sendEmailAsync(mailVM.ToMail,mailVM.subject,mailVM.body);
        //    return Ok("send");
        //}
        //[HttpPost]
        //[Route("SendSMS")]
        //public IActionResult sendSMS()
        //{
        //    SMS.sendSMS("+201280369080","Welcome to Egypt");
        //    return Ok("send");
        //}
        //[HttpPost]
        //[Route("send whatsapp")]
        //public IActionResult sendSMS()
        //{
        //    Whatsapp.SendMessage( "Welcome to Egypt","any phone Number");
        //    return Ok("send");
        //}
        //[HttpGet("login")]
        //public IActionResult Login()
        //{
        //    var properties = new AuthenticationProperties
        //    {
        //        RedirectUri = Url.Action(nameof(Callback)),
        //        Items = { { "scheme", "Google" } }
        //    };

        //    return Challenge(properties, "Google");
        //}

        //[HttpGet("callback")]
        //public async Task<IActionResult> Callback()
        //{
        //    var info = await HttpContext.AuthenticateAsync("Google");
        //    // Handle user login or registration based on 'info'

        //    return Ok(info);
        //}
        //[HttpPost("register")]
        //public async Task<IActionResult> Register2(RegisterModel model)
        //{
        //    // Check if the user with this email already exists in your database
        //    var existingUser = await _userManager.FindByEmailAsync(model.Email);
        //    if (existingUser != null)
        //    {
        //        return BadRequest("User with this email already exists.");
        //    }

        //    // Create a new IdentityUser (or your custom user entity) based on the registration information
        //    var newUser = new IdentityUser
        //    {
        //        UserName = model.Email,
        //        Email = model.Email,
        //    };

        //    var result = await _userManager.CreateAsync((ApplicationUser)newUser);
        //    if (result.Succeeded)
        //    {
        //        // Add claims, roles, or any additional user-specific data here
        //        await _userManager.AddToRoleAsync((ApplicationUser)newUser, "User");
        //        // Sign in the user if needed
        //        // You can use SignInManager to sign in the user

        //        return Ok("User registered successfully.");
        //    }
        //    else
        //    {
        //        return BadRequest("Registration failed.");
        //    }
        //}
    }
}
