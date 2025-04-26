using com.badmintonApp.BadmintonApp.Scripts.Data;

namespace com.badmintonApp.BadmintonApp.Scripts.Factory
{
    public interface ITeamFactory
    {
        ITeam CreateTeam(int teamId, string teamName, params IPlayer[] players);
    }
}