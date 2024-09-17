using FlightReservation.MVC.DTOs;
using FlightReservation.MVC.Models;
using FlightReservation.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.MVC.Controllers;
public class PlanesController(PlaneRepository planeRepository) : Controller
{
    public IActionResult Index()
    {
        var response = planeRepository.GetAll();
        return View(response);
    }

    [HttpPost]
    public IActionResult Add(AddPlaneDto request)
    {
        bool isTailNumberExists = planeRepository.CheckTailNumberExist(request.TailNumber);
        if (isTailNumberExists)
        {
            TempData["Error"] = "Bu kuyruk Numarası daha önce kullanılmıştır.";
            return RedirectToAction("Index");
        }
        Plane plane = new()
        {
            Name = request.Name,
            SeatConfiguration = request.SeatConfiguration,
            TailNumber = request.TailNumber,
            TotalSeats = request.TotalSeats
        };

        planeRepository.Add(plane);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult RemoveById(Guid id)
    {
        planeRepository.RemoveById(id);
        return RedirectToAction("Index");
    }
}
