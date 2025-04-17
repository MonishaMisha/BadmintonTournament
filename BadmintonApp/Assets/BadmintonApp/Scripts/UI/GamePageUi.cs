using System;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class GamePageUi : MonoBehaviour
    {
        public event Action ScoreUpdated
        {
            add => _matchListingPanel.ScoreUpdated += value;
            remove => _matchListingPanel.ScoreUpdated -= value;
        }
        [SerializeField]
        private Button _showStandingsButton;
        [SerializeField]
        private Button _showMatchListingButton;
        
        [SerializeField]
        private MatchListingContainer _matchListingPanel;
        [SerializeField]
        private StandingsContainer _standingsPanel;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _showMatchListingButton.onClick.AddListener(ShowMatchListingButtonClicked);
            _showStandingsButton.onClick.AddListener(ShowStandingsButtonClicked);
        }

        public void ShowMatchListing(IGame[] games)
        {
            _matchListingPanel.ShowGames(games);
        }

        private void ShowMatchListingButtonClicked()
        {
            _matchListingPanel.gameObject.SetActive(true);
            _standingsPanel.gameObject.SetActive(false);
        }

        private void ShowStandingsButtonClicked()
        {
            _matchListingPanel.gameObject.SetActive(false);
            _standingsPanel.gameObject.SetActive(true);
        }

        // Update is called once per frame
        private void OnDestroy()
        {
            _showStandingsButton.onClick.RemoveAllListeners();
            _showMatchListingButton.onClick.RemoveAllListeners();
        }

        public void UpdateStanding(ITeam[] teams)
        {
            _standingsPanel.CreateOrUpdateStandingsList(teams);
        }
    }
}
