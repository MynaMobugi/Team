using System.Text.Json;

namespace Team
{
    public class TeamManager
    {
        List<Team> teams = new List<Team>();

        public Team? CreateTeam(int nextId, string teamName)
        {
            Team team = new Team(nextId, teamName);

            if (string.IsNullOrWhiteSpace(teamName) || teamName.Length <= 3)
            {
                Console.WriteLine("Der Team Name muss mindestens 3 Buchstaben haben.");
                return null;
            }

            teams.Add(team);
            Console.WriteLine($"Der hinzugefügte Name lautet {teamName}. Die Team-ID lautet {nextId}.");

            return team;
        }

        public bool AddName(int teamId, string memberName)
        {
            if (teams.Count == 0)
            {
                Console.WriteLine("Keine Teams vorhanden, bitte zuerst ein Team erstellen.");
                return false;
            }

            var team = FindTeam(teamId);

            if (team == null)
            {
                Console.WriteLine("Team nicht gefunden");
                return false;
            }

            if (string.IsNullOrWhiteSpace(memberName))
            {
                Console.WriteLine("Gib bitte einen Namen ein.");
                return false;
            }

            team.Members.Add(memberName);
            Console.WriteLine($"Der Name {memberName} wurde dem Team {team.Name} hinzugefügt.");

            return true;
        }

        public Team? GetTeam(int teamId)
        {
            if (teams.Count == 0)
            {
                Console.WriteLine("Keine Teams vorhanden, bitte zuerst ein Team erstellen.");
                return null;
            }

            if (teamId == 0)
            {
                Console.Write("Die ID 0 ist nicht vergeben. Bitte um erneute Eingabe: ");
                return null;
            }

            var team = FindTeam(teamId);

            return team;
        }

        public bool UpdateTeam(int updatedTeamId, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName) || newName.Length <= 3)
            {
                Console.WriteLine("Der Team Name muss mindestens 3 Buchstaben haben.");
                return false;
            }

            if (teams.Count == 0)
            {
                Console.WriteLine("Keine Teams vorhanden, bitte zuerst ein Team erstellen.");
                return false;
            }

            var team = FindTeam(updatedTeamId);

            if (team == null)
            {
                return false;
            }

            team.Name = newName;
            Console.WriteLine($"Der neue Name lautet {team.Name}.");
            return true;
        }

        public bool DeleteTeam(int teamId)
        {
            if (teams.Count == 0)
            {
                Console.WriteLine("Keine Teams vorhanden, bitte zuerst ein Team erstellen.");
                return false;
            }

            var team = FindTeam(teamId);

            if (team == null)
            {
                Console.WriteLine("Team mit dieser ID nicht gefunden.");
                return false;
            }

            teams.Remove(team);
            Console.WriteLine($"Team mit der ID {teamId} wurde erfolgreich gelöscht.");
            return true;
        }

        private Team? FindTeam(int teamId)
        {
            Team? team = teams.Find(t => t.Id == teamId);
            return team;
        }

    }
}


