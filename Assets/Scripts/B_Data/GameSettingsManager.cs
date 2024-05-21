using UnityEngine;

namespace BData
{
    public class GameSettingsManager : MonoBehaviour
    {
        [SerializeField] private float easyModeSpeed = 15f;
        [SerializeField] private float hardModeSpeed = 25f;

        private bool easyModeOn = true;
        private bool performanceModeOn = false;
        private bool godModeOn = false;
        public float CurrentGameSpeed => easyModeOn ? easyModeSpeed : hardModeSpeed;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
        private void ChangeDifficultyMode(bool isEasyMode) => easyModeOn = isEasyMode;
        private void ChangePerformanceMode(bool isPerformanceMode) => performanceModeOn = isPerformanceMode;
        private void ChangeGodMode(bool isGodMode) => godModeOn = isGodMode;
        private void SendCurrentSpeed() => ActionManager.DifficultyChanger?.Invoke(CurrentGameSpeed);
        private void SendCurrentPerformanceMode() => ActionManager.PerformanceModeChanger?.Invoke(performanceModeOn);
        private void SendCurrentGodMode() => ActionManager.GodModeChanger?.Invoke(godModeOn);
        private void OnEnable()
        {
            ActionManager.OnSwitchDifficulty += ChangeDifficultyMode;
            ActionManager.OnTogglePerformanceMode += ChangePerformanceMode;
            ActionManager.OnToggleGodMode += ChangeGodMode;
            ActionManager.AskDifficultyChanged += SendCurrentSpeed;
            ActionManager.AskPerformanceModeChanged += SendCurrentPerformanceMode;
            ActionManager.AskGodModeChanged += SendCurrentGodMode;
        }
        private void OnDisable()
        {
            ActionManager.OnSwitchDifficulty -= ChangeDifficultyMode;
            ActionManager.OnTogglePerformanceMode -= ChangePerformanceMode;
            ActionManager.OnToggleGodMode -= ChangeGodMode;
            ActionManager.AskDifficultyChanged -= SendCurrentSpeed;
            ActionManager.AskPerformanceModeChanged -= SendCurrentPerformanceMode;
            ActionManager.AskGodModeChanged -= SendCurrentGodMode;
        }
    }
}