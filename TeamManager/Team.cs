namespace Team {

public class Team
{
    public int Id { get; private set; }

    public string Name { get; set; }

    public List<string> Members { get; set; }

    public Team(int id, string name)
    {
        Id = id;
        Name = name;
        Members = new List<string>();
    }
}
}