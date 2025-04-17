using System;
using com.badmintonApp.BadmintonApp.Scripts.Types;

namespace com.badmintonApp.BadmintonApp.Scripts.Data
{
    public class Player : IPlayer, IEquatable<Player>
    {
        public Level Level { get; }
        public string Name { get; }
        
        public Player(Level level, string name)
        {
            Level = level;
            Name = name;
        }

        public bool Equals(Player other)
        {
            return Level == other.Level && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Player)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)Level, Name);
        }
    }
}
