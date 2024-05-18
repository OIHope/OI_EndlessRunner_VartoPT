using UnityEngine;
using UnityEngine.UI;


namespace FUI
{
    public class UIGameOverManager : MonoBehaviour
    {
        [SerializeField] private Button restartButton;

        private void RestartScene()
        {
            ActionManager.StartNewGame?.Invoke();
        }
        private void OnEnable()
        {
            restartButton.onClick.AddListener(RestartScene);
        }
        private void OnDisable()
        {
            restartButton.onClick.RemoveAllListeners();
        }
    }
}