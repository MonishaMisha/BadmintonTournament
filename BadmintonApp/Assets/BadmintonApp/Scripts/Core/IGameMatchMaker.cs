using com.badmintonApp.BadmintonApp.Scripts.Data;

namespace com.badmintonApp.BadmintonApp.Scripts
{
    public interface IGameMatchMaker
    {
        IGame[] SetUpGames(ITeam[] teams, int legs, int teamsInvolvedPerGame = 2);
    }
}