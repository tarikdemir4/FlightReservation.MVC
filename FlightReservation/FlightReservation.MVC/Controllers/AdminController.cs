using FlightReservation.MVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlightReservation.MVC.Controllers;
[Authorize]
public class AdminController(UserRepository userRepository) : Controller
{
    
    public IActionResult Index()
    {
        var userId = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)!.Value;
        List<string> userRoles = userRepository.GetUserRoleByUserId(Guid.Parse(userId));
        if (!userRoles.Contains("Admin"))
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
}
