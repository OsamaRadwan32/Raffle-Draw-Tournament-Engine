namespace PadelTournamentApp.Models;

public class KnockoutMatchView
{
    public string MatchName { get; set; } = "";
    public string SideA { get; set; } = ""; // e.g. "Winner Group A"
    public string SideB { get; set; } = ""; // e.g. "Runner-up Group C"
}
