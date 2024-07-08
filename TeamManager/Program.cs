/*Team erstellen
Merkmale: Teamnamen, ID, Liste von Namen die im Team sind
Taste 1: Team erstellen - Nach Eingabe möchte ich nach dem Teamnamen gefragt werden
Taste 2: Namen hinzufügen - Nach Eingabe möchte ich gefragt werden, zu welchem Team + Namen eingeben der hinzugefügt werden soll
Taste 3: alle Namen des Teams ausgeben anhand der ID
Taste 4: Updaten eines Teams anhand der ID
Taste 5: Löschen eines Teams anhand der ID - nach Unit Tests
Taste 6: Beenden
*/

using System.Text.Json;
using Team;

var teamManager = new TeamManager();
int nextId = 1;

while (true)
{
    Console.WriteLine("Wähle eine Option:");
    Console.WriteLine("1: Team erstellen");
    Console.WriteLine("2: Namen hinzufügen");
    Console.WriteLine("3. Alle Namen eines Teams anzeigen");
    Console.WriteLine("4. Verändere den Namen des Teams");
    Console.WriteLine("5. Löschen eines Teams");
    Console.WriteLine("6. Beenden");
    string? option = Console.ReadLine();

    switch (option)
    {
        case "1":
        {
            Console.Write("Gib den Namen des Teams ein: ");
            string? teamName = Console.ReadLine();

            if (teamName == null)
            {
                Console.WriteLine("Das Team wurde nicht erstellt.");
                return;
            }

            var team = teamManager.CreateTeam(nextId, teamName);

            if (team == null)
            {
                Console.WriteLine("Das Team wurde nicht erstellt.");
                return;
            }

            nextId++;

            break;
        }
        case "2":
        {
            Console.Write("Gib die ID des Teams ein, dem du einen Namen hinzufügen möchtest: ");
            int teamId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Gib den Namen ein, den du hinzufügen möchtest: ");
            string? memberName = Console.ReadLine();

            if (memberName == null)
            {
                Console.WriteLine("Der Name wurde nicht hinzugefügt.");
                return;
            }

            teamManager.AddName(teamId, memberName);
            break;
        }
        case "3":
        {
            Console.Write("Gib die ID des Teams ein, welches du suchen willst: ");
            int teamId = Convert.ToInt32(Console.ReadLine());

            var team = teamManager.GetTeam(teamId);
            Console.WriteLine(JsonSerializer.Serialize(team?.Members));
            
            break;
        }
        case "4":
        {
            Console.Write("Gib die ID des Teams ein, welches verändert werden soll: ");
            int teamId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Wie soll das Team heißen?: ");
            string? newName = Console.ReadLine();

            if (newName == null)
            {
                Console.WriteLine("Der Name muss mindestens 3 Buchstaben haben.");
                return;
            }
            
            teamManager.UpdateTeam(teamId, newName);
            break;
        }
        case "5":
        {
            Console.Write("Gib die ID des Teams ein, welches gelöscht werden soll: ");
            int teamId = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Möchtest du das Team wirklich löschen? J/N");
            var result = Console.ReadKey();

            switch (result.Key)
            {
                case ConsoleKey.J:
                {
                    break;
                }

                case ConsoleKey.N:
                {
                    return;
                }
                default:
                {
                    Console.WriteLine("Ungültige Eingabe.");
                    return;
                }
            }

            teamManager.DeleteTeam(teamId);

                    break;
            
        }
        
        case "6":
            return;
        
        default:
            Console.WriteLine("Ungültige Auswahl");

            break;
    }
}