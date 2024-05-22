using UnityEngine;

namespace BData
{
    public class GameSettingsManager : MonoBehaviour
    {
        public float easyModeSpeed = 15f;
        public float hardModeSpeed = 25f;
        [Space]
        public bool easyModeOn = true;
        public bool performanceModeOn = false;
        public bool godModeOn = false;
        public float CurrentGameSpeed => easyModeOn ? easyModeSpeed : hardModeSpeed;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
        private void SendCurrentSpeed() => ActionManager.DifficultyChanger?.Invoke(CurrentGameSpeed);
        private void SendCurrentPerformanceMode() => ActionManager.PerformanceModeChanger?.Invoke(performanceModeOn);
        private void SendCurrentGodMode() => ActionManager.GodModeChanger?.Invoke(godModeOn);
        private void OnEnable()
        {
            ActionManager.AskDifficultyChanged += SendCurrentSpeed;
            ActionManager.AskPerformanceModeChanged += SendCurrentPerformanceMode;
            ActionManager.AskGodModeChanged += SendCurrentGodMode;
        }
        private void OnDisable()
        {
            ActionManager.AskDifficultyChanged -= SendCurrentSpeed;
            ActionManager.AskPerformanceModeChanged -= SendCurrentPerformanceMode;
            ActionManager.AskGodModeChanged -= SendCurrentGodMode;
        }
    }
}