using Team;

namespace TeamManagerTest;

public class Tests
{
    private TeamManager TeamManager { get; }

    public Tests()
    {
        TeamManager = new TeamManager();
    }

    [SetUp]
    public void Setup()
    {
        TeamManager.CreateTeam(1, "Katze");
    }

    [Test]
    public void CheckIfCreateTeamReturnsNewTeam()
    {
        int id = 2;

        var newTeam = TeamManager.CreateTeam(id, "Hund");
        Assert.That(id, Is.EqualTo(newTeam?.Id));
    }

    [Test]
    public void CheckIfTeamMembersListIsEmpty()
    {
        int id = 3;

        //neues Team erstellen
        var newTeam = TeamManager.CreateTeam(id, "Maus");
        //überprüfen, ob das Team erstellt wurde
        Assert.That(id, Is.EqualTo(newTeam?.Id));

        //überprüfen, ob die Liste leer ist
        var team = TeamManager.GetTeam(3);
        //überprüfen ob team gefunden wurde 
        Assert.That(team, Is.Not.Null);
        Assert.That(team.Members, Is.Empty);
    }

    [Test]
    public void AddNameShouldAppendMemberToMemberList()
    {
        var success = TeamManager.AddName(1, "Tim");
        Assert.That(success);
    }

    [Test]
    public void CheckIfAddedNameIsInMembersList()
    {
        //Füge Tim zu Team 1 hinzu
        var success = TeamManager.AddName(1, "Tim");
        //Überprüfen, ob die Operation erfolgreich war
        Assert.That(success);

        //Rufe Team 1 auf und speichern in Variable team
        var team = TeamManager.GetTeam(1);
        Assert.That(team, Is.Not.Null);
        //Überprüfen ob team.Members den Namen Tim enthält
        Assert.That(team.Members, Contains.Item("Tim"));
    }

    [Test]
    public void CheckIfGetTeamReturnsList()
    {
        var team = TeamManager.GetTeam(1);
        Assert.That(team, Is.Not.Null);
    }

    [Test]
    public void CheckIfUpdateTeamChangesName()
    {
        var success = TeamManager.UpdateTeam(1, "Vogel");
        Assert.That(success, Is.Not.False);

        var team = TeamManager.GetTeam(1);
        Assert.That(team, Is.Not.Null);
        Assert.That(team.Name, Is.EqualTo("Vogel"));
    }

    [Test]
    public void CheckIfAbleToUpdateTeamWithInvalidID()
    {
    }

    [Test]
    public void CheckIfTeamListIsEmpty()
    {
    }

    [Test]
    public void CheckIfTeamReturnsNullIfGivenRandomId()
    {
        var team = TeamManager.GetTeam(4000);
        Assert.That(team, Is.Null);
    }

    [TestCase("Zu")]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("            ")]
    public void CheckIfCreateTeamDoesNotAddTeamWithInvalidName(string name)
    {
        var team = TeamManager.CreateTeam(3, name);
        Assert.That(team, Is.Null);
    }
}