using com.badmintonApp.BadmintonApp.Scripts.Data;

namespace com.badmintonApp.BadmintonApp.Scripts.Factory
{
    public class TeamFactory : ITeamFactory
    {
        public ITeam CreateTeam(string teamName, params IPlayer[] players)
        {
            return new Team(teamName, players);
        }
    }
}