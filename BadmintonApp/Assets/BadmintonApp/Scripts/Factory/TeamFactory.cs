using com.badmintonApp.BadmintonApp.Scripts.Data;

namespace com.badmintonApp.BadmintonApp.Scripts.Factory
{
    public class TeamFactory : ITeamFactory
    {
        public ITeam CreateTeam(int teamId, string teamName, params IPlayer[] players)
        {
            return new Team(teamId, teamName, players);
        }
    }
}