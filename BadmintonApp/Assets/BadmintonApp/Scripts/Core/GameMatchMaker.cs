using System.Collections.Generic;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using com.badmintonApp.BadmintonApp.Scripts.Factory;

namespace com.badmintonApp.BadmintonApp.Scripts
{
    public class GameMatchMaker : IGameMatchMaker
    {
        //Choose number of teams in a game default = 2
        
        //t1, t2, t3, t4, t5, t6, t7, t8
        //t1, t2, t3, t4, t5, t6, t7, t8
        //t1, t2, t3, t4, t5, t6, t7, t8
        
        private readonly IGameFactory _gameFactory;

        public GameMatchMaker(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }


        public IGame[] SetUpGames(ITeam[] teams, int legs, int teamsInvolvedPerGame = 2)
        {
            var teamCombinations = teams.GetCombinations(teamsInvolvedPerGame);
            teamCombinations.Shuffle();
            var game = new List<IGame>();
            for (int i = 0; i < legs; i++)
            {
                foreach (var match in teamCombinations)
                {
                    
                    var teamsMatched = new List<ITeam>();
                    teamsMatched.AddRange(match);
                    if (i > 0)
                    {
                        teamsMatched.Reverse();
                    }
                    game.Add(_gameFactory.CreateGame(teamsMatched.ToArray()));
                }
            }
            return game.ToArray();
        }
    }
}