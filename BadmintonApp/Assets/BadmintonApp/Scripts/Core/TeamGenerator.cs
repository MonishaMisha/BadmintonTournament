using System;
using System.Collections.Generic;
using System.Linq;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using com.badmintonApp.BadmintonApp.Scripts.Factory;

namespace com.badmintonApp.BadmintonApp.Scripts.Core
{
    public class TeamGenerator : ITeamGenerator
    {
        private static readonly Random Random = new Random();

        private readonly ITeamFactory _teamFactory;

        public TeamGenerator(ITeamFactory teamFactory)
        {
            _teamFactory = teamFactory;
        }

        //number of players per team
        //split players in to teams


        public ITeam[] GenerateTeams(IPlayer[] players, int playersPerTeam)
        {
            return BalanceTeamsRandomized(players, playersPerTeam).ToArray();
        }
        
        private List<ITeam> BalanceTeamsRandomized(IPlayer[] players, int playersPerTeam)
        {
            int teamCount = (int)Math.Ceiling(players.Length / (double)playersPerTeam);

            // Temporary storage
            var tempTeams = new List<List<IPlayer>>();
            var teamScores = new List<int>();

            for (int i = 0; i < teamCount; i++)
            {
                tempTeams.Add(new List<IPlayer>());
                teamScores.Add(0);
            }

            // Group players by level and shuffle each group
            var grouped = players
                .GroupBy(p => p.Level)
                .OrderByDescending(g => g.Key) // Advanced to Beginner
                .ToList();

            foreach (var levelGroup in grouped)
            {
                var shuffled = levelGroup.OrderBy(p => Random.Next()).ToList();

                foreach (var player in shuffled)
                {
                    // Find eligible teams (not full), ordered by current score
                    var eligibleTeams = tempTeams
                        .Select((t, idx) => new { Index = idx, Score = teamScores[idx], Count = t.Count })
                        .Where(t => t.Count < playersPerTeam)
                        .OrderBy(t => t.Score)
                        .ToList();

                    if (eligibleTeams.Any())
                    {
                        var target = eligibleTeams.First();
                        tempTeams[target.Index].Add(player);
                        teamScores[target.Index] += (int)player.Level;
                    }
                }
            }

            // Convert to List<Team>
            var finalTeams = new List<ITeam>();
            for (int i = 0; i < tempTeams.Count; i++)
            {
                var tempPlayes = tempTeams[i].ToArray();
                var teamName = $"Team {GetTeamNames(tempPlayes)}";
                finalTeams.Add(_teamFactory.CreateTeam(teamName, tempPlayes));
            }

            return finalTeams;
        }
        
        private string GetTeamNames(IPlayer[] players)
        {
            var name = "";
            foreach (var player in players)
            {
                var partName = player.Name.Substring(0, 3).ToUpper();
                name += $"{partName} - ";
            }
            name = name.Substring(0,name.Length - 3);
            return name;
        }
    }
}