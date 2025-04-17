using com.badmintonApp.BadmintonApp.Scripts.Types;

namespace com.badmintonApp.BadmintonApp.Scripts.Data
{
    public interface IPlayer
    {
        Level Level { get; }
        string Name { get; }
    }
}