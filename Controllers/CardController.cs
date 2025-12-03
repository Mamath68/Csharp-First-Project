using Microsoft.AspNetCore.Mvc;
using MVC_App.Services;

namespace MVC_App.Controllers;

public class CardController(CardService cardService) : Controller
{
    public async Task<IActionResult> Index(int page = 0)
    {
        var cards = await cardService.GetCardsAsync(page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;
        return View(cards);
    }

    public async Task<IActionResult> Show(int id)
    {
        var card = await cardService.GetCardByIdAsync(id);
        if (card == null)
            return Content("Carte introuvable");

        return View(card);
    }
    public async Task<IActionResult> ShowArchetype(string archetype, int page = 0)
    {
        var cards = await cardService.GetCardsByArchetypeAsync(archetype, page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;

        return View(cards);
    }
}