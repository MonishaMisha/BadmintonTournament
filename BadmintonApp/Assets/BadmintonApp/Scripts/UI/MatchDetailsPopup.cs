using System;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class MatchDetailsPopup : MonoBehaviour
    {
        public event Action UpdateScoreClicked;
        
        [Header("Team 1")]
        [SerializeField]
        private TextMeshProUGUI _team1NameText;
        [SerializeField]
        private TMP_InputField _team1ScoreText;
        [SerializeField] private Transform _team1PlayersNameListContainer;

        [Header("Team 2")]
        [SerializeField]
        private TextMeshProUGUI _team2NameText;
        [SerializeField]
        private TMP_InputField _team2ScoreText;
        [SerializeField] private Transform _team2PlayersNameListContainer;

        [SerializeField]
        private Button _updateScoreButton;
        
        [SerializeField] private TextMeshProUGUI _namesPrefab;
        
        IGame _game;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
         _updateScoreButton.onClick.AddListener(UpdateScoreButtonClicked);
        }

        public void ShowGameDetails(IGame game)
        {
            _game = game;

            RemoveAllPlayerNames();
            var team1Detail = game.TeamsDetails[0];
            var team2Detail = game.TeamsDetails[1];
            _team1NameText.text =  team1Detail.Team.Name;
            _team2NameText.text =  team2Detail.Team.Name;
            _team1ScoreText.text = team1Detail.Score.ToString();
            _team2ScoreText.text = team2Detail.Score.ToString();

            foreach (var player in team1Detail.Team.Players)
            {
               var playerNameText = Instantiate(_namesPrefab, _team1PlayersNameListContainer);
               playerNameText.text =  $"* Player 1 : {player.Name}";
            }
            foreach (var player in team2Detail.Team.Players)
            {
                var playerNameText = Instantiate(_namesPrefab, _team2PlayersNameListContainer);
                playerNameText.text = $"* Player 2 : {player.Name}";
            }
            
            _updateScoreButton.interactable = !game.IsGameEnded;
            _team1ScoreText.interactable = !game.IsGameEnded;
            _team2ScoreText.interactable = !game.IsGameEnded;
        }

        private void RemoveAllPlayerNames()
        {
            foreach (Transform name1 in _team1PlayersNameListContainer)
            {
                Destroy(name1.gameObject);
            }
            foreach (Transform name2 in _team2PlayersNameListContainer)
            {
                Destroy(name2.gameObject);
            }
        }

        private void UpdateScoreButtonClicked()
        {
            _game.UpdateScore(_game.TeamsDetails[0].Team, int.Parse(_team1ScoreText.text));
            _game.UpdateScore(_game.TeamsDetails[1].Team, int.Parse(_team2ScoreText.text));
            _game.EndGame();
            UpdateScoreClicked?.Invoke();
        }

        // Update is called once per frame
        private void OnDestroy()
        {
            _updateScoreButton.onClick.RemoveAllListeners();
        }
    }
}
