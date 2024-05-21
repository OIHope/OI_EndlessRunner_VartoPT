using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FUI
{
    public class UIMainMenuManager : MonoBehaviour
    {
        [Header("Menu")]
        [SerializeField] private GameObject uiMenu;
        [SerializeField] private Button startButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;
        [Space]
        [Header("Settings")]
        [SerializeField] private GameObject uiSettings;
        [SerializeField] private TextMeshProUGUI currentdifficultyText;
        [SerializeField] private Button easyModeButton;
        [SerializeField] private Button hardModeButton;
        [SerializeField] private Toggle preformanceModeToggle;
        [SerializeField] private Toggle godModeToggle;
        [SerializeField] private Button backButton;

        private void StartNewGame()
        {
            ActionManager.StartNewGame?.Invoke();
        }
        private void ExitToMenu()
        {
            Application.Quit();
        }
        private void SetEasyMode()
        {
            ActionManager.OnSwitchDifficulty?.Invoke(true);
            currentdifficultyText.text = ("(easy)");
        }
        private void SetHardMode()
        {
            ActionManager.OnSwitchDifficulty?.Invoke(false);
            currentdifficultyText.text = ("(hard)");
        }
        private void ToggleSettingPanel()
        {
            uiSettings.SetActive(!uiSettings.activeSelf);
        }
        private void SetPerformanceMode(bool on)
        {
            ActionManager.OnTogglePerformanceMode?.Invoke(on);
        }
        private void SetGodMode(bool on)
        {
            ActionManager.OnToggleGodMode?.Invoke(on);
        }
        private void OnEnable()
        {
            preformanceModeToggle.onValueChanged?.AddListener(SetPerformanceMode);
            godModeToggle.onValueChanged?.AddListener(SetGodMode);
            uiSettings.SetActive(false);
            startButton.onClick.AddListener(StartNewGame);
            exitButton.onClick.AddListener(ExitToMenu);
            settingsButton.onClick.AddListener(ToggleSettingPanel);
            backButton.onClick.AddListener(ToggleSettingPanel);
            easyModeButton.onClick.AddListener(SetEasyMode);
            hardModeButton.onClick.AddListener(SetHardMode);
        }
        private void OnDisable()
        {
            startButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
            settingsButton.onClick.RemoveAllListeners();
            backButton.onClick.RemoveAllListeners();
            easyModeButton.onClick.RemoveAllListeners();
            hardModeButton.onClick.RemoveAllListeners();
        }
    }
}