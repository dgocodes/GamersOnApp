namespace GamersOn.Domain.Entities;

public class Game : Entity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public virtual IList<GameEvaluation> Evaluations { get; set; } = new List<GameEvaluation>();

    public void Deactivate()
    {
        Active = false;
    }

    public void Update(string name, string description)
    {
        Name = name; 
        Description = description;
    }
}
