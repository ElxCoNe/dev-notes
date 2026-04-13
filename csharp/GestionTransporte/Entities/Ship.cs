namespace GestionTranspoorte.Entities;

public class Ship
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public int TripulationCapacity { get; set; }
    public string Status { get; set; }
    
    
    public ICollection<Mission> Missions { get; set; } = new List<Mission>();
    
}