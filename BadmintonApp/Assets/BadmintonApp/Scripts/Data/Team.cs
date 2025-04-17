using System.Collections.Generic;

namespace com.badmintonApp.BadmintonApp.Scripts.Data
{
    public class Team : ITeam
    {
        public int Rank { get; private set; }
        public int TotalPointsConceded { get; private set; }
        public string Name { get; }
        public int TotalGamesPlayed { get; private set; }
        public int GamePoints { get; private set; }
        public int TotalPointsScored { get; private set; }
        public int TotalWins { get; private set; } = 0;
        public int TotalLoses { get; private set; } = 0;
        public float WinPercentage => (TotalGamesPlayed > 0) ? (TotalWins / (float)TotalGamesPlayed) * 100f : 0f;
        public int PointDifference => TotalPointsScored - TotalPointsConceded;
        public Dictionary<string, int> HeadToHeadWins { get; } = new Dictionary<string, int>();

        public bool IsWinner { get; private set; }
        
        
        public IPlayer[] Players { get;}

        
        public Team(string name, IPlayer[] players)
        {
            Name = name;
            Players = players;
        }

        public void SetRank(int rank)
        {
            Rank = rank;
        }

        public void UpdateGamePoints(int points)
        {
            GamePoints += points;
        }

        public void UpdatePointsScored(int score)
        {
           TotalPointsScored += score;
        }

        public void UpdatePointsConceded(int score)
        {
            TotalPointsConceded += score;
        }

        public void GameCompleted()
        {
            TotalGamesPlayed++;
        }
        
        public void DeclareGameWon()
        {
            TotalWins++;
        }

        public void DeclareGameLost()
        {
            TotalLoses++;
        }

        public void DeclareTournamentWon(bool isWinner)
        {
            IsWinner = isWinner;
        }
       
    }
    
}