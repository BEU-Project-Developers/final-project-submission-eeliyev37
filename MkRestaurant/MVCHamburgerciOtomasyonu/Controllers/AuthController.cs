using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCHamburgerciOtomasyonu.Entity.Entities;
using MVCHamburgerciOtomasyonu.Service.DTOs.Users;
using MVCHamburgerciOtomasyonu.Web.Consts;
using NToastNotify;

namespace MVCHamburgerciOtomasyonu.Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly SignInManager<AppUser> signInManager;
		private readonly IMapper _mapper;
		private readonly IToastNotification toastNotification;
		public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IToastNotification notification)
		{
			toastNotification = notification;
			this.userManager = userManager;
			this.signInManager = signInManager;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult Login()
		{

			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(UserLoginDto userLoginDto)
		{
			if (ModelState.IsValid)
			{
				var user = await userManager.FindByEmailAsync(userLoginDto.Email);
				if (user != null)
				{
					var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
					if (result.Succeeded)
					{
						var roles = await userManager.GetRolesAsync(user);
						if (roles.Contains(RoleConsts.Superadmin))
						{
							return RedirectToAction("AdminDashboard", "Dashboard");
						}
						if (roles.Contains(RoleConsts.User))
						{

							return RedirectToAction("UserDashboard", "Dashboard");
						}
					}
					else
					{
						ModelState.AddModelError("", "E-mail or password is not correct.");
						return View();
					}
				}
				else
				{
					ModelState.AddModelError("", "E-mail or password is not correct.");
					return View();
				}
			}
			else
			{
				ModelState.AddModelError("", "E-mail or password is not correct.");
				return View();
			}
			return View();
		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Register()
		{

			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Register(CreateUserDto createUserDto)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			if (createUserDto.Password != createUserDto.ConfirmPassword)
			{
				ModelState.AddModelError("", "Passwords do not match.");
				return View();
			}
			if (createUserDto.Password == createUserDto.ConfirmPassword)
			{

				var appUser =  _mapper.Map<AppUser>(createUserDto);
				appUser.UserName = createUserDto.EMail;
				appUser.ImageID = Guid.Parse("01673030-C382-45F8-84DC-A095BF6A7532");
				var result = await userManager.CreateAsync(appUser, createUserDto.Password);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(appUser, "User");

					return RedirectToAction("AdminDashboard", "Dashboard");
				}

				toastNotification.AddErrorToastMessage("Register operation failed!");
				ModelState.AddModelError("", "E-mail or password is not correct.");
			}
			return View();
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Login", "Auth");
		}
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> AccessDenied()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Error404()
		{
			return View();
		}

	}
}
