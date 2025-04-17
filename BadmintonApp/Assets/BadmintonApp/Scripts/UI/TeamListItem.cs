using com.badmintonApp.BadmintonApp.Scripts.Data;
using TMPro;
using UnityEngine;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class TeamListItem : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI teamName;
        [SerializeField]
        private TextMeshProUGUI player1Name;
        [SerializeField]
        private TextMeshProUGUI player2Name;
        
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void SetTeamData(ITeam team)
        {
            teamName.text = team.Name;
            player1Name.text = $"Player 1 : {team.Players[0].Name}";
            player2Name.text = $"Player 2 : {team.Players[1].Name}";
        }
    }
}
