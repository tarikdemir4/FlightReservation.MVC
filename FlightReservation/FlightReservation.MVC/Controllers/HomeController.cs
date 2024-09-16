using FlightReservation.MVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FlightReservation.MVC.Controllers;


[Authorize]
public class HomeController(UserRepository userRepository) : Controller
{


    public IActionResult Index()
    {
        var userId = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)!.Value;
        List<string> userRoles = userRepository.GetUserRoleByUserId(Guid.Parse(userId));
        if (userRoles.Contains("Admin"))
        {
            return RedirectToAction("Index", "Admin");
        }
        return View();
    }


}
