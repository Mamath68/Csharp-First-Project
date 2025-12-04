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
    public async Task<IActionResult> ShowAttribute(string attribute, int page = 0)
    {
        var cards = await cardService.GetCardsByAttributeAsync(attribute, page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;

        return View(cards);
    }
    public async Task<IActionResult> ShowLevel(int level, int page = 0)
    {
        var cards = await cardService.GetCardsByLevelAsync(level, page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;

        return View(cards);
    }
    public async Task<IActionResult> ShowScale(int scale, int page = 0)
    {
        var cards = await cardService.GetCardsByScaleAsync(scale, page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;

        return View(cards);
    }
    public async Task<IActionResult> ShowLink(int link, int page = 0)
    {
        var cards = await cardService.GetCardsByLinkAsync(link, page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;

        return View(cards);
    }
    public async Task<IActionResult> ShowAtk(int atk, int page = 0)
    {
        var cards = await cardService.GetCardsByAtkAsync(atk, page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;

        return View(cards);
    }
    public async Task<IActionResult> ShowDef(int def, int page = 0)
    {
        var cards = await cardService.GetCardsByDefAsync(def, page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;

        return View(cards);
    }
    public async Task<IActionResult> ShowType(string type, int page = 0)
    {
        var cards = await cardService.GetCardsByTypeAsync(type, page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;

        return View(cards);
    }
    public async Task<IActionResult> ShowRace(string race, int page = 0)
    {
        var cards = await cardService.GetCardsByRaceAsync(race, page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;

        return View(cards);
    }
    public async Task<IActionResult> ShowRaceType(string race, string type, int page = 0)
    {
        var cards = await cardService.GetCardsByRaceTypeAsync(race, type, page);
        if (!cards.Any())
        {
            ViewData["Error"] = "Impossible de récupérer les cartes depuis l'API.";
            return View("Error");
        }

        ViewData["Page"] = page;

        return View(cards);
    }
}