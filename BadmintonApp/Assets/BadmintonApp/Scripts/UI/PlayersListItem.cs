using System;
using com.badmintonApp.BadmintonApp.Scripts.Core;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class PlayersListItem : MonoBehaviour
    {
        public IPlayer Player => _playerData; 
        public event Action<IPlayer> OnRemovePlayerClicked;

        [SerializeField] private TextMeshProUGUI _playerName;
        [SerializeField] private TextMeshProUGUI _levelText;
        
        [SerializeField] private Button _removePlayerButton;

        private IPlayer _playerData;
        
        void Start()
        {
            _removePlayerButton.onClick.AddListener(RemovePlayerClicked);
        }

        public void SetPlayerData(IPlayer playerData)
        {
            _playerData = playerData;
            _playerName.text = playerData.Name;
            _levelText.text = playerData.Level.ToString();
        }

        private void RemovePlayerClicked()
        {
            EventCommunication.FirePlayerRemoved(_playerData);
            OnRemovePlayerClicked?.Invoke(_playerData);
        }

        private void OnDestroy()
        {
            _removePlayerButton.onClick.RemoveAllListeners();
        }
    }
}
