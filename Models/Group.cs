namespace PadelTournamentApp.Models;

public class Group
{
    public string GroupName { get; set; } = string.Empty;

    // Stores Team.Id values
    public List<int> TeamIds { get; set; } = new();
}
