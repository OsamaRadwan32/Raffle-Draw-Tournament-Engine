using System.Text.Json;
using PadelTournamentApp.Models;

namespace PadelTournamentApp.Data;

public sealed class SeedService
{
    private readonly IWebHostEnvironment _env;
    private readonly object _fileLock = new();

    public List<Player> Players { get; set; } = new();
    public List<Team> Teams { get; set; } = new();
    public List<Group> Groups { get; set; } = new();
    public List<KnockoutMatch> Knockout { get; set; } = new();

    private string FilePath =>
        Path.Combine(_env.ContentRootPath, "Data", "TournamentSeed.json");

    public SeedService(IWebHostEnvironment env)
    {
        _env = env;
        Load();
    }

    public void Load()
    {
        lock (_fileLock)
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine($"Seed file not found: {FilePath}");
                ResetState();
                return;
            }

            try
            {
                var json = File.ReadAllText(FilePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    ResetState();
                    return;
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var seed = JsonSerializer.Deserialize<SeedFile>(json, options);

                Players = seed?.Players ?? new();
                Teams = seed?.Teams ?? new();
                Groups = seed?.Groups ?? new();
                Knockout = seed?.Knockout ?? new();

                Console.WriteLine(
                    $"Seed loaded | Players: {Players.Count}, Teams: {Teams.Count}, Groups: {Groups.Count}"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load seed file: {ex.Message}");
                ResetState();
            }
        }
    }

    public void Save()
    {
        lock (_fileLock)
        {
            try
            {
                var seed = new SeedFile
                {
                    Players = Players,
                    Teams = Teams,
                    Groups = Groups,
                    Knockout = Knockout
                };

                var json = JsonSerializer.Serialize(seed, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(FilePath, json);

                Console.WriteLine(
                    $"Seed saved | Players: {Players.Count}, Teams: {Teams.Count}, Groups: {Groups.Count}"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save seed file: {ex.Message}");
                throw;
            }
        }
    }

    public async Task SaveAsync()
    {
        var seed = new SeedFile
        {
            Players = Players,
            Teams = Teams,
            Groups = Groups,
            Knockout = Knockout
        };

        var json = JsonSerializer.Serialize(seed, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        await File.WriteAllTextAsync(FilePath, json);
    }


    private void ResetState()
    {
        Players = new();
        Teams = new();
        Groups = new();
        Knockout = new();
    }
}

public class SeedFile
{
    public List<Player> Players { get; set; } = new();
    public List<Team> Teams { get; set; } = new();
    public List<Group> Groups { get; set; } = new();
    public List<KnockoutMatch> Knockout { get; set; } = new();
}

