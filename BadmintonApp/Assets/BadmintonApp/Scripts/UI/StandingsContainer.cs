using System;
using System.Collections.Generic;
using System.Linq;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class StandingsContainer : MonoBehaviour
    {
        [SerializeField] private StandingsListItem _standingsListItemPrefab;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private Transform _titleBarTransform;
        private List<StandingsListItem> _standingsListItems = new List<StandingsListItem>();

        private float titleBaroffsetX;
        private void Start()
        { 
            titleBaroffsetX = _titleBarTransform.position.x - _parentTransform.position.x;
            _scrollRect.onValueChanged.AddListener(OnScrollRectValueChanged);
        }

        private void OnScrollRectValueChanged(Vector2 arg0)
        {
            var xPos = _parentTransform.position.x + titleBaroffsetX;
            _titleBarTransform.position = new Vector3(xPos, _titleBarTransform.position.y, _titleBarTransform.position.z);
        }

        public void CreateOrUpdateStandingsList(ITeam[] teams)
        {
            var sorted = RankTeams(teams);
            for (var i = 0 ; i < sorted.Length ; i++)
            {
                sorted[i].SetRank(i+1);
            }
            if (_standingsListItems.Count == 0)
            {
                foreach (var team in sorted)
                {
                    var item = Instantiate(_standingsListItemPrefab, _parentTransform);
                    item.SetData(team);
                    _standingsListItems.Add(item);
                }
            }
            else
            {
                for (int i = 0; i < _standingsListItems.Count; i++)
                {
                    _standingsListItems[i].SetData(sorted[i]);
                }
            }
        }

        private static ITeam[] RankTeams(ITeam[] teams)
        {
            return teams.OrderByDescending(t => t.GamePoints)
                .ThenByDescending(t => t.PointDifference)
                .ThenBy(t => t.Name)
                .ToArray();
        }

        private void OnDestroy()
        {
            _scrollRect.onValueChanged.RemoveAllListeners();
        }
    }
}
