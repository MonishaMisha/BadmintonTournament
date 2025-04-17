using com.badmintonApp.BadmintonApp.Scripts.Data;
using TMPro;
using UnityEngine;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class StandingsListItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _rankText;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _gamesPlayedText;
        [SerializeField] private TextMeshProUGUI _winText;
        [SerializeField] private TextMeshProUGUI _loseText;
        [SerializeField] private TextMeshProUGUI _pointsText;
        [SerializeField] private TextMeshProUGUI _winPercentageText;
        [SerializeField] private TextMeshProUGUI _scoreGainedText;
        [SerializeField] private TextMeshProUGUI _scoreConcededText;
        [SerializeField] private TextMeshProUGUI _scoreDifferenceText;

        public void SetData(ITeam team)
        {
            _rankText.text = team.Rank.ToString();
            _nameText.text = team.Name;
            _gamesPlayedText.text = team.TotalGamesPlayed.ToString();
            _winText.text = team.TotalWins.ToString();
            _loseText.text = team.TotalLoses.ToString();
            _pointsText.text = team.GamePoints.ToString();
            _winPercentageText.text = team.WinPercentage.ToString("F0" + "%");
            _scoreGainedText.text = team.TotalPointsScored.ToString();
            _scoreConcededText.text = team.TotalPointsConceded.ToString();
            _scoreDifferenceText.text = GetPointDifference(team.PointDifference);
        }

        private string GetPointDifference(int teamPointDifference)
        {
            var pointDiffText = teamPointDifference > 0 ? "<color=green>+" : teamPointDifference < 0 ? "<color=red>" : string.Empty;
            return $"{pointDiffText}{teamPointDifference}</color>";
        }
    }
}
