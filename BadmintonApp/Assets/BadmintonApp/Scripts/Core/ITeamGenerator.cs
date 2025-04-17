using com.badmintonApp.BadmintonApp.Scripts.Data;

namespace com.badmintonApp.BadmintonApp.Scripts.Core
{
    public interface ITeamGenerator
    {
        ITeam[] GenerateTeams(IPlayer[] players, int playersPerTeam);
    }
}