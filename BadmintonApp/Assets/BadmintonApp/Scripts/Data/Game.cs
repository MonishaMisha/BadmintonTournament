using System.Collections.Generic;
using System.Linq;

namespace com.badmintonApp.BadmintonApp.Scripts.Data
{
    public class Game : IGame
    {
        public  bool IsGameEnded { get; private set; }
        public IReadOnlyList<ITeamData> TeamsDetails => _teamsDetails;

        private readonly List<TeamData> _teamsDetails = new ();

        public Game(ITeam[] teams)
        {
            foreach (var team in teams)
            {
                _teamsDetails.Add(new TeamData(team, 0));
            }
        }
        
        public void UpdateScore(ITeam team, int score)
        {
          var data =  _teamsDetails.Find(detail => detail.Team.Equals(team));
          data.UpdateScore(score);
        }

        public void EndGame()
        {
            IsGameEnded = true;
            foreach (var teamData in _teamsDetails)
            { 
                var scoreWon = teamData.Score;
                var scoreConceded = _teamsDetails.Where(td => td.Team != teamData.Team).Sum(td => td.Score);
                teamData.Team.UpdatePointsScored(scoreWon);
                teamData.Team.UpdatePointsConceded(scoreConceded);
                teamData.Team.GameCompleted();
            }
            
            var winner = _teamsDetails.OrderByDescending(x => x.Score).First().Team;
            var loser = _teamsDetails.OrderBy(x => x.Score).First().Team;
            winner.DeclareGameWon();
            loser.DeclareGameLost();
            winner.UpdateGamePoints(LocalConfig.MatchLegs);
        }
    }

    public class TeamData : ITeamData, ITeamWriteData
    {
        public int Score { get; private set; }
        public ITeam Team { get; }

        public TeamData(ITeam team, int score)
        {
            Score = score;
            Team = team;
        }

        public void UpdateScore(int score)
        {
            Score = score;
        }
    }

    public interface ITeamData
    {
        int Score { get; }
        ITeam Team { get; }
    }

    public interface ITeamWriteData
    {
        void UpdateScore(int score);
    }
}