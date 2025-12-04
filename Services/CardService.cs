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

    public async Task<List<CardModel>> GetCardsByTypeAsync(string type, int page = 0, int num = 28)
    {
        var offset = page * num;
        var url = $"{_baseUrl}?type={Uri.EscapeDataString(type)}&num={num}&offset={offset}&sort=id";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }

    public async Task<List<CardModel>> GetCardsByRaceAsync(string race, int page = 0, int num = 28)
    {
        var offset = page * num;
        var url = $"{_baseUrl}?race={Uri.EscapeDataString(race)}&num={num}&offset={offset}&sort=id";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }

    public async Task<List<CardModel>> GetCardsByRaceTypeAsync(string race, string type, int page = 0, int num = 28)
    {
        var offset = page * num;
        var url =
            $"{_baseUrl}?race={Uri.EscapeDataString(race)}&type={Uri.EscapeDataString(type)}&num={num}&offset={offset}&sort=id";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }

    public async Task<List<CardModel>> GetCardsByAtkAsync(int atk, int page = 0, int num = 28)
    {
        var offset = page * num;
        var url = $"{_baseUrl}?atk={atk}&num={num}&offset={offset}&sort=id";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }

    public async Task<List<CardModel>> GetCardsByDefAsync(int def, int page = 0, int num = 28)
    {
        var offset = page * num;
        var url = $"{_baseUrl}?def={def}&num={num}&offset={offset}&sort=id";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }

    public async Task<List<CardModel>> GetCardsByAttributeAsync(string attribute, int page = 0, int num = 28)
    {
        var offset = page * num;
        var url = $"{_baseUrl}?attribute={Uri.EscapeDataString(attribute)}&num={num}&offset={offset}&sort=id";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }

    public async Task<List<CardModel>> GetCardsByScaleAsync(int scale, int page = 0, int num = 28)
    {
        var offset = page * num;
        var url = $"{_baseUrl}?scale={scale}&num={num}&offset={offset}&sort=id";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }

    public async Task<List<CardModel>> GetCardsByLevelAsync(int level, int page = 0, int num = 28)
    {
        var offset = page * num;
        var url = $"{_baseUrl}?level={level}&num={num}&offset={offset}&sort=id";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }

    public async Task<List<CardModel>> GetCardsByLinkAsync(int link, int page = 0, int num = 28)
    {
        var offset = page * num;
        var url = $"{_baseUrl}?link={link}&num={num}&offset={offset}&sort=id";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<CardModel>();

        var json = await response.Content.ReadAsStringAsync();
        var cardResponse = JsonSerializer.Deserialize<CardResponse>(json, JsonOptions);

        return cardResponse?.data ?? new List<CardModel>();
    }
}