namespace GestionTranspoorte.Entities;

public class Mission
{
    public int Id { get; set; }
    public string MisionName { get; set; } = string.Empty;
    public DateTime MissionDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public int AstronautId { get; set; }
    public int ShipId { get; set; }

    public Ship Ship { get; set; } = null!;
    public Astronaut Astronaut { get; set; } = null!;
    
    public ICollection<ExplorationLog> ExplorationLog { get; set; } = new List<ExplorationLog>();
}