using UnityEngine;
using UnityEngine.UI;


namespace FUI
{
    public class UIGameOverManager : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;

        private void RestartScene()
        {
            ActionManager.StartNewGame?.Invoke();
        }
        private void ExitToMenu()
        {
            ActionManager.StopGame?.Invoke();
        }
        private void OnEnable()
        {
            restartButton.onClick.AddListener(RestartScene);
            menuButton.onClick.AddListener(ExitToMenu);
        }
        private void OnDisable()
        {
            restartButton.onClick.RemoveAllListeners();
            menuButton.onClick.RemoveAllListeners();
        }
    }
}