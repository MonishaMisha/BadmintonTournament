using System.Collections.Generic;

namespace com.badmintonApp.BadmintonApp.Scripts.Data
{
    public interface ITeam
    {
        int Rank { get; }
        int TotalWins { get; } 
        int TotalLoses { get; }
        int TotalGamesPlayed { get; }
        int GamePoints { get; }
        float WinPercentage { get; }
        int TotalPointsScored { get; }
        int TotalPointsConceded { get; }
        int PointDifference { get; }
        Dictionary<string, int> HeadToHeadWins { get; }
        string Name { get; }
        IPlayer[] Players { get; }

        bool IsWinner { get; }
        
        void SetRank(int rank);
        
        void UpdateGamePoints(int points);
        
        void UpdatePointsScored(int score);

        void UpdatePointsConceded(int score);
        
        void GameCompleted();

        void DeclareGameWon();
        
        void DeclareGameLost();
        
        void DeclareTournamentWon(bool isWinner);
        
        
    }
}