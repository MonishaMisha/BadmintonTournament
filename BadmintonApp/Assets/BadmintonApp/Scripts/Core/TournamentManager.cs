using System.Collections.Generic;
using com.badmintonApp.BadmintonApp.Scripts.App;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using com.badmintonApp.BadmintonApp.Scripts.Factory;
using com.badmintonApp.BadmintonApp.Scripts.Types;
using com.badmintonApp.BadmintonApp.Scripts.UI;
using UnityEngine;

namespace com.badmintonApp.BadmintonApp.Scripts.Core
{
    public class TournamentManager : MonoBehaviour
    {
        [SerializeField]
        private IntroPageUI _introPageUI;
        [SerializeField]
        private AddPlayersPageUI _addPlayersPageUI;
        [SerializeField]
        private TeamListingUI _teamListingUI;
        [SerializeField]
        private GamePageUi _gamePageUi;

        List<IPlayer> _players = new();
        ITeam[] _teams;
        IGame[] _games;
        IPlayerFactory _playerFactory;
        ITeamGenerator _teamGenerator;
        IGameMatchMaker _gameMatchMaker;

        private GameObject activeView;
        
        private void Start()
        {
            _playerFactory = new PlayerFactory();
            _teamGenerator = new TeamGenerator(new TeamFactory());
            _gameMatchMaker = new GameMatchMaker(new GameFactory());
            _addPlayersPageUI.OnPlayerDataSubmitted += OnPlayerDataSubmitted;
            _addPlayersPageUI.OnGenerateTeams += OnGenerateTeams;
            EventCommunication.PlayerRemoved += OnPlayerRemoved;
            _introPageUI.OnStartClicked += OnStartClicked;
            _teamListingUI.ShuffleTeams += OnShuffleTeams;
            _teamListingUI.StartGameClicked += OnStartGameClicked;
            _gamePageUi.ScoreUpdated += OnScoreUpdated;
            activeView = _introPageUI.gameObject;
        }

        private void OnScoreUpdated()
        {
            _gamePageUi.UpdateStanding(_teams);
        }

        private void OnStartGameClicked()
        {
             SetActiveView(_gamePageUi.gameObject);
             _games = _gameMatchMaker.SetUpGames(_teams, LocalConfig.MatchLegs);
             _gamePageUi.ShowMatchListing(_games);
        }

        private void OnShuffleTeams()
        {
            SetUpTeams();
        }

        private void OnGenerateTeams()
        {
            if (_players.Count % 2 != 0)
            {
                Debug.Log("Players count is not even, Please add one more player");
                return;
            }
            SetActiveView(_teamListingUI.gameObject);
            SetUpTeams();
        }

        private void SetUpTeams()
        {
            _teams = _teamGenerator.GenerateTeams(_players.ToArray(), 2);
            _teamListingUI.ShowTeamListing(_teams);
            _gamePageUi.UpdateStanding(_teams);
        }

        private void OnStartClicked()
        {
            SetActiveView(_addPlayersPageUI.gameObject);
        }

        private void SetActiveView(GameObject view)
        {
            activeView.SetActive(false);
            activeView = view;
            activeView.SetActive(true);
        }

        private void OnPlayerRemoved(IPlayer removedPlayer)
        {
            _players.RemoveAll(player => player.Equals(removedPlayer));
        }

        private void OnPlayerDataSubmitted((string name, int level) data)
        {
            var player = _playerFactory.CreatePlayer(data.name, (Level)data.level);
            _players.Add(player);
            EventCommunication.FirePlayerAdded(player);
        }

        private void OnDestroy()
        {
            _addPlayersPageUI.OnPlayerDataSubmitted -= OnPlayerDataSubmitted;
            EventCommunication.PlayerRemoved -= OnPlayerRemoved;
            _introPageUI.OnStartClicked -= OnStartClicked;
            _addPlayersPageUI.OnGenerateTeams -= OnGenerateTeams;
            _teamListingUI.ShuffleTeams -= OnShuffleTeams;
            _teamListingUI.StartGameClicked -= OnStartGameClicked;
            _gamePageUi.ScoreUpdated -= OnScoreUpdated;
        }
    }
}