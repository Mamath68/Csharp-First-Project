namespace MVC_App.Models.CardModels;

public class MiscInfos
{
    public string? beta_name { get; set; }
    public int? views { get; set; }
    public int? viewsweek { get; set; }
    public int? upvotes { get; set; }
    public int? downvotes { get; set; }
    public List<string>? formats { get; set; }
    public string? tcg_date { get; set; }
    public string? ocg_date { get; set; }
    public int? konemi_id { get; set; }
    public int? has_effect { get; set; }
    public string? md_rarity { get; set; }
    public string? genesys_point { get; init; }

}