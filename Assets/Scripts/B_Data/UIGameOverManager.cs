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

        private void SetScoreText(int tFood, int tSec, int tMin, int tScore, int bScore)
        {
            totalFoodText.text = ($"totalFood: {tFood}");
            totalTimeText.text = ($"totalTime: {tMin}:{tSec}");
            totalScoreText.text = ($"totalScore: {tScore}");

            bestScoreText.text = ($"bestScore: {bScore}");
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