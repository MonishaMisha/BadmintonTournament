using com.badmintonApp.BadmintonApp.Scripts.Data;

namespace com.badmintonApp.BadmintonApp.Scripts.Factory
{
    public class GameFactory : IGameFactory
    {
        public IGame CreateGame(ITeam[] teams)
        {
            return new Game(teams);
        }
    }

    public interface IGameFactory
    {
        IGame CreateGame(ITeam[] teams);
    }
}