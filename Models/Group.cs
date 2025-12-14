namespace PadelTournamentApp.Models;

public class Group
{
    public string GroupName { get; set; } = string.Empty;
    public List<int> TeamIds { get; set; } = new();
}
