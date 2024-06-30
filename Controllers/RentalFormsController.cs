using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zaliczenia.Data;
using zaliczenia.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class RentalFormsController : Controller
{
    private UserManager<IdentityUser> _userManager;

    private readonly ApplicationDbContext _context;

    public RentalFormsController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult Index()
    {
        var rentalForms = _context.RentalForms.OrderByDescending(r => r.Id).ToList();
        return View(rentalForms);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Details(int id)
    {
        var car = Car.GetCars().FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            return NotFound();
        }

        var rentalForm = new RentalForm { CarId = car.Id };

        ViewBag.Car = car;

        return View(rentalForm);
    }

    [HttpPost]
    [Authorize]
    public IActionResult SubmitForm(RentalForm form)
    {
        var allCars = Car.GetCars();
        var car = allCars.FirstOrDefault(c => c.Id == form.CarId);
        var userId = _userManager.GetUserId(User);
        form.UserId = userId;

        if (car == null)
        {
            return NotFound();
        }

    
        _context.RentalForms.Add(form);
        _context.SaveChanges();
        TempData["SuccessMessage"] = "Twój formularz wynajmu został pomyślnie przesłany.";
        return RedirectToAction("Index", "Cars");
    }

    [HttpPost]
    [Authorize]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult Delete(int id)
    {
        var user = _userManager.GetUserId(User);

        Console.WriteLine(user);

        var rentalForm = _context.RentalForms.Find(id);

        if (rentalForm == null)
        {
            return NotFound();
        }

        _context.RentalForms.Remove(rentalForm);
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Wynajem został pomyślnie usunięty.";
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult Edit(int id)
    {
        var rentalForm = _context.RentalForms.Find(id);

        if (rentalForm == null)
        {
            return NotFound();
        }

        // Optionally, you can retrieve related data like Car details if needed
        ViewBag.Car = Car.GetCars().FirstOrDefault(c => c.Id == rentalForm.CarId);

        return View(rentalForm);
    }

    [HttpPost]
    [Authorize(Policy = "AdminPolicy")]
    public IActionResult Edit(RentalForm form)
    {
 
        var existingForm = _context.RentalForms.Find(form.Id);

        if (existingForm == null)
        {
            return NotFound();
        }

        // Update existing form properties
        existingForm.Name = form.Name;
        existingForm.Email = form.Email;
        existingForm.Phone = form.Phone;
        existingForm.PickupDate = form.PickupDate;
        existingForm.LeavingDate = form.LeavingDate;

        _context.SaveChanges();

        TempData["SuccessMessage"] = "Formularz wynajmu został pomyślnie zaktualizowany.";
        return RedirectToAction("Index");
    }
}
