using System;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class GameListingItem : MonoBehaviour
    {
        public event Action<IGame> ShowDetailsClicked;
        [SerializeField] private TextMeshProUGUI _team1NameText;
        [SerializeField] private TextMeshProUGUI _team2NameText;
        [SerializeField] private Button _showDetailsButton;
        [SerializeField] private GameObject _tick;
        
        IGame _game;
        
        void Start()
        {
            _showDetailsButton.onClick.AddListener(ShowDetailsButtonClicked);
            _tick.SetActive(false);
        }

        public void SetMatchData(IGame game)
        {
            _game = game;
            _game.GameEnded += OnGameEnded;
            _team1NameText.text = game.TeamsDetails[0].Team.Name;
            _team2NameText.text = game.TeamsDetails[1].Team.Name;
        }

        private void OnGameEnded()
        {
            _tick.SetActive(true);
        }

        private void ShowDetailsButtonClicked()
        {
            ShowDetailsClicked?.Invoke(_game);
        }

        private void OnDestroy()
        {
            _showDetailsButton.onClick.RemoveAllListeners();
            _game.GameEnded -= OnGameEnded;
        }
    }
}
