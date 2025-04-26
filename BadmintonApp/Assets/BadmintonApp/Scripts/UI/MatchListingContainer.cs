using System;
using System.Collections.Generic;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using TMPro;
using UnityEngine;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class MatchListingContainer : MonoBehaviour
    {
        public event Action ScoreUpdated;
        [SerializeField] private GameListingItem _gameListingItemPrefab;
        [SerializeField] private TextMeshProUGUI _SetNameText;
        [SerializeField] private Transform _parentTransform;
        List<GameListingItem> gameListingItems = new List<GameListingItem>();
        [SerializeField] private MatchDetailsPopup _matchDetailsPopup;

        private void Start()
        {
            _matchDetailsPopup.UpdateScoreClicked += OnScoreUpdated;
        }

        public void ShowGames(IGame[] games)
        {
            DestroyAllChildren();
            var gameCounter = 0;
            var setCount = 1;
            var gamesPerSet = games.Length / LocalConfig.MatchLegs;

            foreach (var game in games)
            {
                if (gameCounter % gamesPerSet == 0)
                {
                   var setText = Instantiate(_SetNameText, _parentTransform);
                   setText.text = $"Set {setCount}";
                   setCount++;
                }
                var matchListingItem = Instantiate(_gameListingItemPrefab, _parentTransform);
                matchListingItem.SetMatchData(game);
                matchListingItem.ShowDetailsClicked += OnDetailsClicked;
                gameListingItems.Add(matchListingItem);
                gameCounter++;
            }
        }

        private void OnScoreUpdated()
        {
            _matchDetailsPopup.gameObject.SetActive(false);
            ScoreUpdated?.Invoke();
        }

        private void DestroyAllChildren()
        {
            gameListingItems.RemoveAll(item =>
            {
                item.ShowDetailsClicked -= OnDetailsClicked;
                Destroy(item);
                return true;
            });
        }

        private void OnDetailsClicked(IGame game)
        {
            _matchDetailsPopup.gameObject.SetActive(true);
            _matchDetailsPopup.ShowGameDetails(game);
        }

        private void OnDestroy()
        {
            _matchDetailsPopup.UpdateScoreClicked -= OnScoreUpdated;
            
        }
    }
}
