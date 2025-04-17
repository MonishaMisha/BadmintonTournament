using System.Collections.Generic;

namespace com.badmintonApp.BadmintonApp.Scripts.Data
{
    public interface IGame
    { 
        bool IsGameEnded { get; }
        IReadOnlyList<ITeamData> TeamsDetails { get; }
        void UpdateScore(ITeam team, int score);
        void EndGame();
    }
}