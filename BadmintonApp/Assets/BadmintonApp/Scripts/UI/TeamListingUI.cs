using System;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class TeamListingUI : MonoBehaviour
    {
        public event Action ShuffleTeams;
        public event Action StartGameClicked;
        [SerializeField]
        TeamListItem teamListItemPrefab;
        [SerializeField]
        Transform teamListContainer;
        [SerializeField]
        Button startButton;
        [SerializeField]
        Button shuffleTeamsButton;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        { 
            startButton.onClick.AddListener(OnStartGameClicked);
            shuffleTeamsButton.onClick.AddListener(OnShuffleTeamsClicked);
        }

        private void OnShuffleTeamsClicked()
        {
            ShuffleTeams?.Invoke();
        }

        public void ShowTeamListing(ITeam[] teams)
        {
            DestroyAllChildren();
            foreach (var team in teams)
            {
              var teamListItem =  Instantiate(teamListItemPrefab, teamListContainer);
              teamListItem.SetTeamData(team);
            }
        }

        private void DestroyAllChildren()
        {
            foreach (Transform children in teamListContainer)
            {
                Destroy(children.gameObject);
            }
        }

        private void OnStartGameClicked()
        {
           StartGameClicked?.Invoke();
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveAllListeners();
            shuffleTeamsButton.onClick.RemoveAllListeners();
        }
    }
}
