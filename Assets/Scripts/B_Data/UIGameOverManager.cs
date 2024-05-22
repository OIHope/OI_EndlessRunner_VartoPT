using BData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace FUI
{
    public class UIGameOverManager : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        [Space]
        [Header("Score text")]
        [SerializeField] private TextMeshProUGUI totalFoodText;
        [SerializeField] private TextMeshProUGUI totalTimeText;
        [SerializeField] private TextMeshProUGUI totalScoreText;
        [Space]
        [SerializeField] private TextMeshProUGUI bestScoreText;
        [Space]
        [SerializeField] private GameSettingsManager gameSettingsManager;
        private bool godMode => gameSettingsManager.godModeOn;
        private void SetScoreText(int tFood, int tSec, int tMin, int tScore, int bScore)
        {
            if (godMode)
            {
                totalFoodText.text = ("GodMode");
                totalTimeText.text = ("GodMode");
                totalScoreText.text = ("GodMode");
                bestScoreText.text = ("GodMode");
            }
            else
            {
                totalFoodText.text = ($"{tFood}");
                totalTimeText.text = ShowTime(tMin, tSec);
                totalScoreText.text = ($"{tScore}");
                bestScoreText.text = ($"{bScore}");
            }
        }
        private string ShowTime(int min, int sec)
        {
            string minutes, seconds;
            if (min < 10) minutes = ($"0{min}");
            else minutes = min.ToString();
            if (sec < 10) seconds = ($"0{sec}");
            else seconds = sec.ToString();
            return ($"{minutes}:{seconds}");
        }
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
            ActionManager.FinalScoreUdpate += SetScoreText;
            ActionManager.tempGameOverEnable?.Invoke();
            restartButton.onClick.AddListener(RestartScene);
            menuButton.onClick.AddListener(ExitToMenu);
        }
        private void OnDisable()
        {
            ActionManager.FinalScoreUdpate -= SetScoreText;
            restartButton.onClick.RemoveAllListeners();
            menuButton.onClick.RemoveAllListeners();
        }
    }
}