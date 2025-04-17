using com.badmintonApp.BadmintonApp.Scripts.Data;

namespace com.badmintonApp.BadmintonApp.Scripts.Factory
{
    public interface ITeamFactory
    {
        ITeam CreateTeam(string teamName, params IPlayer[] players);
    }
}