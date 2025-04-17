using com.badmintonApp.BadmintonApp.Scripts.Data;
using com.badmintonApp.BadmintonApp.Scripts.Types;

namespace com.badmintonApp.BadmintonApp.Scripts.Factory
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string name, Level level);
    }
}