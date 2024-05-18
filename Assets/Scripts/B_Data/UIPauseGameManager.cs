using UnityEngine;
using UnityEngine.UI;

namespace FUI
{
    public class UIPauseGameManager : MonoBehaviour
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;

        private void ContinueGame()
        {
            ActionManager.PauseGame?.Invoke(false);
            gameObject.SetActive(false);
        }
        private void RestartScene()
        {
            ActionManager.PauseGame?.Invoke(false);
            ActionManager.StartNewGame?.Invoke();
        }
        private void ExitToMenu()
        {
            Application.Quit();
        }
        private void OnEnable()
        {
            continueButton.onClick.AddListener(ContinueGame);
            restartButton.onClick.AddListener(RestartScene);
            menuButton.onClick.AddListener(ExitToMenu);
        }
        private void OnDisable()
        {
            continueButton?.onClick.RemoveAllListeners();
            restartButton.onClick.RemoveAllListeners();
            menuButton.onClick.RemoveAllListeners();
        }
    }
}