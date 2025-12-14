namespace PadelTournamentApp.Models;

public class Team
{
    public int Id { get; set; }

    public int Player1Id { get; set; }

    public int Player2Id { get; set; }

    // Display name (e.g. "Player A & Player B")
    public string Name { get; set; } = string.Empty;

    // Used internally for draw logic only (not shown in UI)
    public int Rank { get; set; }
}
