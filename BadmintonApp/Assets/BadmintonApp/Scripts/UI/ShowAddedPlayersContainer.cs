using System;
using System.Collections;
using System.Collections.Generic;
using com.badmintonApp.BadmintonApp.Scripts.Core;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class ShowAddedPlayersContainer : MonoBehaviour
    {
        public event Action AddPlayerClicked;
        public event Action GenerateTeamsClicked;
        
        [SerializeField]
        private Button _addPlayersButton;
        [SerializeField]
        private Button _generateTeamsButton;
        [SerializeField]
        private PlayersListItem _playersListItemPrefab;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private ScrollRect _scrollRect;
        private List<PlayersListItem> _playersListItems = new ();
        private int playersCount = 0;

        private void OnEnable()
        {
            if (playersCount != _playersListItems.Count)
            {
                _scrollRect.verticalNormalizedPosition = 0f;
            } 
        }

        private void OnDisable()
        {
            playersCount = _playersListItems.Count;
        }

        void Start()
        {
          _addPlayersButton.onClick.AddListener(OnAddPlayerClicked);
          _generateTeamsButton.onClick.AddListener(OnGenerateTeamsClicked);
          EventCommunication.PlayerAdded += OnPlayerAdded;
        }
        
        private void OnPlayerAdded(IPlayer addedPlayer)
        {
            var item = Instantiate(_playersListItemPrefab, _parentTransform);
            item.OnRemovePlayerClicked += OnRemovePlayerClicked;
            item.SetPlayerData(addedPlayer);
            _playersListItems.Add(item);

        }
        
        private void OnRemovePlayerClicked(IPlayer removedPlayer)
        {
           _playersListItems.RemoveAll(x =>
           {
               if (x.Player.Equals(removedPlayer))
               {
                   x.OnRemovePlayerClicked -= OnRemovePlayerClicked;
                   Destroy(x.gameObject);
                   return true;
               }

               return false;
           });
        }

        private void OnGenerateTeamsClicked()
        {
            GenerateTeamsClicked?.Invoke();
        }

        private void OnAddPlayerClicked()
        {
            AddPlayerClicked?.Invoke();  
        }

        private void OnDestroy()
        {
            _addPlayersButton.onClick.RemoveAllListeners();
            _generateTeamsButton.onClick.RemoveAllListeners();
            EventCommunication.PlayerAdded -= OnPlayerAdded;
        }
    }
}
