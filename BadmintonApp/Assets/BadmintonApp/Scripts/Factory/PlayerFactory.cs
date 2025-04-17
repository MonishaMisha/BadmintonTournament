using com.badmintonApp.BadmintonApp.Scripts.Data;
using com.badmintonApp.BadmintonApp.Scripts.Types;

namespace com.badmintonApp.BadmintonApp.Scripts.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string name, Level level)
        {
            return new Player(level, name);
        }
    }
}