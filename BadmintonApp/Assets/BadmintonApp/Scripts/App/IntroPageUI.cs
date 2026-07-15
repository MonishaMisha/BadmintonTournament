using System;
using UnityEngine;
using UnityEngine.UI;

namespace com.badmintonApp.BadmintonApp.Scripts.App
{
    public class IntroPageUI : MonoBehaviour
    {
        public event Action OnStartClicked;
        
       [SerializeField]
       private Button _startGameButton;
       [SerializeField]
       private Toggle _useRandomTeamsToggle;
       private void Start()
       {
           _startGameButton.onClick.AddListener(OnStart);
       }

       private void OnStart()
       {
           LocalConfig.UseRandomTeams = _useRandomTeamsToggle.isOn;
           OnStartClicked?.Invoke();
       }

       private void OnDestroy()
       {
           _startGameButton.onClick.RemoveAllListeners();
       }
    }
}
