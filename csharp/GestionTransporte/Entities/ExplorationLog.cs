namespace GestionTranspoorte.Entities;

public class ExplorationLog
{
    public int Id { get; set; }
    public string PlanetDestiny { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int MissionId { get; set; }

    public Mission Mission { get; set; } = null!;
}