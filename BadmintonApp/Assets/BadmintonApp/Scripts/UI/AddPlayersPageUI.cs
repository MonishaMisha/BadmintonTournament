using System;
using UnityEngine;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class AddPlayersPageUI : MonoBehaviour
    {
        public event Action<(string name, int level)> OnPlayerDataSubmitted
        {
            add => _addNameAndLevelContainer.OnSubmitClicked += value;
            remove => _addNameAndLevelContainer.OnSubmitClicked -= value;
        }
        
        public event Action OnGenerateTeams
        {
            add => _showAddedPlayersContainer.GenerateTeamsClicked += value;
            remove => _showAddedPlayersContainer.GenerateTeamsClicked -= value;
        }
        
        [SerializeField]
        ShowAddedPlayersContainer _showAddedPlayersContainer;
        [SerializeField]
        AddNameAndLevelContainer _addNameAndLevelContainer;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _showAddedPlayersContainer.AddPlayerClicked += OnShowAddPlayerPanel;
            _addNameAndLevelContainer.OnSubmitClicked += OnPlayerAdded;
            _addNameAndLevelContainer.OnCloseButtonClicked += OnAddPlayerPanelCloseClicked;
        }

        private void OnAddPlayerPanelCloseClicked()
        {
            EnableAddPlayerPanel(false);
        }

        private void OnPlayerAdded((string, int) playerDetails)
        {
            EnableAddPlayerPanel(false);
        }

        private void OnShowAddPlayerPanel()
        {
            EnableAddPlayerPanel(true);
        }

        private void EnableAddPlayerPanel(bool isEnabled)
        {
            _addNameAndLevelContainer.gameObject.SetActive(isEnabled);
            _showAddedPlayersContainer.gameObject.SetActive(!isEnabled);
        }

        private void OnDestroy()
        {
            _showAddedPlayersContainer.AddPlayerClicked -= OnShowAddPlayerPanel;
            _addNameAndLevelContainer.OnSubmitClicked -= OnPlayerAdded;
            _addNameAndLevelContainer.OnCloseButtonClicked -= OnAddPlayerPanelCloseClicked;
        }
    }
}
