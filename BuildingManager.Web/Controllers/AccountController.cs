using System.Security.Claims;
using BuildingManager.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Web.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public ActionResult Login(string returnUrl)
    {
        var model = new LoginModel()
        {
            ReturnUrl = returnUrl
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (model.UserName.ToLower() == "admin" && model.Password == "admin")
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("username", model.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.UserName));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrinciple);
            return Redirect(model.ReturnUrl);
        }

        ModelState.AddModelError(string.Empty, "Lietotājs un/vai parole nav pareizi");
        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}