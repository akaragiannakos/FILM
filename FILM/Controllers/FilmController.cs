using FILM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class FilmController : Controller
{
    private static IList<Film> films = new List<Film>
    {
        new Film { Id = 1, Name = "Film1", Description = "opis filmu1", Price = 3 },
        new Film { Id = 2, Name = "Film2", Description = "opis filmu2", Price = 5 },
        new Film { Id = 3, Name = "Film3", Description = "opis filmu3", Price = 3 },
    };

    // Akcja Index
    public IActionResult Index()
    {
      
        return View(films);
    }


    // Akcja Create (GET)
    public IActionResult Create()
    {
        return View(new Film());
    }

    // Akcja Create (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Film film)
    {
        film.Id = films.Count + 1; // Ustawienie nowego Id
        films.Add(film);
        return RedirectToAction(nameof(Index));
    }

    // Akcja Details
    public IActionResult Details(int id)
    {
        var film = films.FirstOrDefault(x => x.Id == id);
        return View(film);
    }

    // Akcja Edit (GET)
    public IActionResult Edit(int id)
    {
        var film = films.FirstOrDefault(x => x.Id == id);
        return View(film);
    }

    // Akcja Edit (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Film film)
    {
        var existingFilm = films.FirstOrDefault(x => x.Id == film.Id);
        if (existingFilm != null)
        {
            existingFilm.Name = film.Name;
            existingFilm.Description = film.Description;
            existingFilm.Price = film.Price;
        }
        return RedirectToAction(nameof(Index));
    }

    // Akcja Delete (GET)
    public IActionResult Delete(int id)
    {
        var film = films.FirstOrDefault(x => x.Id == id);
        return View(film);
    }

    // Akcja Delete (POST)
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var film = films.FirstOrDefault(x => x.Id == id);
        if (film != null)
        {
            films.Remove(film);
        }
        return RedirectToAction(nameof(Index));
    }
}
