using UnityEngine;
using UnityEngine.UI;

namespace FUI
{
    public class UIMainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        private void StartNewGame()
        {
            ActionManager.StartNewGame?.Invoke();
        }
        private void ExitToMenu()
        {
            Application.Quit();
        }
        private void OnEnable()
        {
            startButton.onClick.AddListener(StartNewGame);
            exitButton.onClick.AddListener(ExitToMenu);
        }
        private void OnDisable()
        {
            startButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
        }
    }
}