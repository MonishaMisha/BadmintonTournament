using System;
using com.badmintonApp.BadmintonApp.Scripts.Data;

namespace com.badmintonApp.BadmintonApp.Scripts.Core
{
    public static class EventCommunication
    {
        public static event Action<IPlayer> PlayerAdded;
        
        public static event Action<IPlayer> PlayerRemoved;


        public static void FirePlayerAdded(IPlayer player)
        {
            PlayerAdded?.Invoke(player);
        }

        public static void FirePlayerRemoved(IPlayer player)
        {
            PlayerRemoved?.Invoke(player);
        }
        
    }
}