/*Team erstellen
Merkmale: Teamnamen, ID, Liste von Namen die im Team sind
Taste 1: Team erstellen - Nach Eingabe möchte ich nach dem Teamnamen gefragt werden
Taste 2: Namen hinzufügen - Nach Eingabe möchte ich gefragt werden, zu welchem Team + Namen eingeben der hinzugefügt werden soll
Taste 3: alle Namen des Teams ausgeben anhand der ID
Taste 4: Updaten eines Teams anhand der ID
Taste 5: Löschen eines Teams - nach Unit Tests
Taste 6: Beenden
*/
using System.Text.Json;

var teamManager = new TeamManager();
int nextId = 1;

while (true)
{


    System.Console.WriteLine("Wähle eine Option: ");
    System.Console.WriteLine("1: Team erstellen");
    System.Console.WriteLine("2: Namen hinzufügen");
    System.Console.WriteLine("3. Alle Namen eines Teams anzeigen");
    System.Console.WriteLine("4. Update den Namen des Teams");
    System.Console.WriteLine("5. Beendet das Programm");

    //Erstellung Variable für die Auswahl
    string option = Console.ReadLine();

    //switch für Auswahl
    switch (option)
    {
        case "1":
            teamManager.CreateTeam(nextId);
            nextId++;
            break;
        case "2":
            teamManager.AddName();
            break;
        case "3":
            teamManager.DisplayTeam();
            break;
        case "4":
            teamManager.UpdateTeam();
            break;
        case "5":
            return;
        default:
            System.Console.WriteLine("Ungültige Auswahl");
            break;
    }

}
//Klasse für Team erstellen


public class Team
{
    //Hier können Eigenschaften abgerufen und verändert werden mittels get, set
    public int Id { get; private set; }
    public string Name { get; private set; }

    public List<string> Members { get; set; }

    public Team(int id, string name)
    {
        Id = id;
        Name = name;
        Members = new List<string>();
    }

}

public class TeamManager
{
    List<Team> teams = new List<Team>();

    //while Loop zur Erstellung der Usereingabe, endlos Schleife bis break oder Eingabe 

    //Erstellung der jeweiligen Methoden
    //Fall 1 Erstellung eines Teams 
    public void CreateTeam(int nextId)
    {
        System.Console.Write("Gib den Namen des Teams ein: ");
        string teamName = Console.ReadLine();
        teams.Add(new Team(nextId, teamName));
        System.Console.WriteLine($"Der hinzugefügte Name lautet {teamName}. Die Team-ID lautet {nextId}");


    }

    //Fall 2 Hinzufügen eines Namens
    public void AddName()
    {
        //Wenn die Liste leer ist, darum bitten Liste zu füllen
        if (teams.Count == 0)
        {
            System.Console.WriteLine("Keine Teams vorhanden, bitte zuerst ein Team erstellen");
            return;
        }

        System.Console.Write("Gib die ID des Teams ein, dem du einen Namen hinzufügen möchtest");
        int TeamId = Convert.ToInt32(Console.ReadLine());

        //hier müsste etwas hin, was bei einer falschen Eingabe ausgegeben wird, bzw. wenn die ID nicht vorhanden ist

        //.Find sucht innerhalb der Liste team nach der Usereingabe und speichert es unter team
        Team team = teams.Find(t => t.Id == TeamId);

        if (team == null)
        {
            System.Console.WriteLine("Team nicht gefunden");
            return;
        }

        System.Console.Write("Gib den Namen ein, den du hinzufügen möchtest: ");
        string MemberName = Console.ReadLine();

        team.Members.Add(MemberName);

        System.Console.WriteLine($"Der Name {MemberName} wurde dem Team {team.Name} hinzugefügt");

    }

    //Fall 3 Suche nach Namen anhand der Team ID
    public void DisplayTeam()
    {
        if (teams.Count == 0)
        {
            System.Console.WriteLine("Keine Teams vorhanden, bitte zuerst ein Team erstellen");
            return;
        }

        System.Console.WriteLine("Gib die ID des Teams ein, welches du suchen willst");
        int teamId = Convert.ToInt32(Console.ReadLine());

        if (teamId == 0)
        {
            System.Console.Write("Die ID 0 ist nicht vergeben. Bitte um erneute Eingabe: ");
        }

        //für jedes Team in der Liste teams
        foreach (Team team in teams)
        {   
            if(teamId.Equals(team.Id)) 
            {
                System.Console.WriteLine(JsonSerializer.Serialize(team.Members));
                return;
            }  
        }

    }

    public void UpdateTeam()
    {
        if (teams.Count == 0)
        {
            System.Console.WriteLine("Keine Teams vorhanden, bitte zuerst ein Team erstellen");
            return;
        }

        System.Console.Write("Gib die ID des Teams ein, welches geupdated werden soll: ");
        int updatedTeam = Convert.ToInt32(Console.ReadLine());

        foreach (Team team in teams)
        {
            if(updatedTeam.Equals(team.Id)) 
            {
                System.Console.Write("Wie soll das Team heißen?: ");
                
                
                System.Console.WriteLine($"Der neue Name lautet {newName}.");
                return;
            }
        }
    }
}