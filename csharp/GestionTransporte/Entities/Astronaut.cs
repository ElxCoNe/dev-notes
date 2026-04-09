namespace GestionTranspoorte.Entities;

public class Astronaut
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Rank { get; set; }
    public int ExperienceHour { get; set; }
    
    public ICollection<Mission> Missions { get; set; } =  new List<Mission>();
}   