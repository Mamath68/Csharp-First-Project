namespace MVC_App.Models.CardModels;

public class CardModel
{
    public int? id { get; init; }
    public required string name { get; init; }
    public int? atk { get; init; }
    public int? def { get; init; }
    public string DisplayAtk => atk == -1 ? "?" : atk?.ToString() ?? "";
    public string DisplayDef => def == -1 ? "?" : def?.ToString() ?? "";
    public int? level { get; init; }
    public int? scale { get; init; }
    public int? linkval { get; init; }
    public string? attribute { get; init; }
    public string? archetype { get; init; }
    public required string type { get; init; }
    public required string race { get; init; }
    public string? desc { get; init; }
    public string? pend_desc { get; init; }
    public string? monster_desc { get; init; }
    public required List<CardImageModel> card_images { get; init; }
    public List<CardSets>? card_sets { get; init; }
    public List<CardPrices>? card_prices { get; init; }
    public List<MiscInfos>? misc_info { get; init; }
}