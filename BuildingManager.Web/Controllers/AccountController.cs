using BuildingManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Web.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (model.UserName.ToLower() == "admin" && model.Password == "admin")
        {
            // Session["UserName"] = model.UserName;
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Lietotājs un/vai parole nav pareizi");
            return View(model);
        }
    }
}