using FlightReservation.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Resources;

namespace FlightReservation.MVC.Controllers;
public class AccountController : Controller
{
    private LanguageService _localization;

    public AccountController(LanguageService localization)
    {
        _localization = localization;
    }

    public IActionResult Login()
    {
        ViewBag.Message = _localization.Getkey("Welcome").Value;
        var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
}
