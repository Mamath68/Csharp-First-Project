using System.Text.Json;
using MVC_App.Models.CardModels;

namespace MVC_App.Services;

public class CardService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly string _baseUrl = "https://db.ygoprodeck.com/api/v7/cardinfo.php";

    public async Task<List<CardModel>> GetCardsAsync(int page = 0, int num = 28)
    {
        var offset = page * num;
        var url = $"{_baseUrl}?num={num}&offset={offset}&sort=id";

        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode) return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }

    public async Task<CardModel?> GetCardByIdAsync(int id)
    {
        var url = $"{_baseUrl}?id={id}&misc=yes";
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode) return null;

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data.FirstOrDefault();
    }

    public async Task<List<CardModel>> GetCardsByArchetypeAsync(string archetype, int page = 0, int num = 28)
    {
        var offset = page * num;
        var url = $"{_baseUrl}?archetype={Uri.EscapeDataString(archetype)}&num={num}&offset={offset}&sort=id";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }
}