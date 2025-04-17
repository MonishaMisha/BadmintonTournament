using System;
using com.badmintonApp.BadmintonApp.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace com.badmintonApp.BadmintonApp.Scripts.UI
{
    public class AddNameAndLevelContainer : MonoBehaviour
    {
        public event Action<(string name, int level)> OnSubmitClicked;
        public event Action OnCloseButtonClicked;
        
        [SerializeField]
        private TMP_InputField _nameInputField;
        [SerializeField]
        private Button _closeButton;
        [SerializeField]
        private Button _submitButton;
        [SerializeField]
        private TMP_Dropdown _levelDropdown;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _closeButton.onClick.AddListener(CloseClicked);
            _submitButton.onClick.AddListener(SubmitClicked);
        }

        private void OnEnable()
        {
            Reset();
        }

        private void Reset()
        {
            _nameInputField.text = "";
            _levelDropdown.value = 0;
        }

        private void SubmitClicked()
        {
            OnSubmitClicked?.Invoke((_nameInputField.text, _levelDropdown.value));
        }

        [ContextMenu("Add Some Players")]
        public void AddTestPlayers()
        {
            var names = new[]
            {
                "Sathwik",
                "Amir",
                "Misha",
                "Abi",
                "Nikhil",
                "Nacho",
                "Nihad",
                "Shibili",
                "Chandu",
                "Vysakh",
                "Vinay",
                "Justin"
            };
            foreach (var t in names)
            {
                OnSubmitClicked?.Invoke(($"{t}", Random.Range(0,3)));
            }
        }
        private void CloseClicked()
        {
            OnCloseButtonClicked?.Invoke();
        }

        // Update is called once per frame
        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
            _submitButton.onClick.RemoveAllListeners();
        }
    }
}
