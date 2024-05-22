using BData;
using TMPro;
using UnityEngine;

namespace FUI
{
    public class UIShowBasicData : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI heartText;
        [SerializeField] private TextMeshProUGUI foodText;
        [SerializeField] private TextMeshProUGUI timeText;
        private int foodValue;
        private int heartValue;
        private int secondsValue;
        private int minutesValue;

        [SerializeField] private GameSettingsManager gameSettingsManager;
        private bool godMode => gameSettingsManager.godModeOn;

        private void SetFoodValue(int value)
        {
            if (godMode)
            {
                foodText.text = ("GodMode");
                return;
            }
            foodValue = value;
            foodText.text = ($"{foodValue}/100");
        }
        private void SetHeartValue(int value)
        {
            if (godMode)
            {
                heartText.text = ("GodMode");
                return;
            }
            heartValue = value;
            heartText.text = ($"{heartValue}");
        }
        private void SetTimeValue(int seconds, int minutes)
        {
            if (godMode)
            {
                timeText.text = ("GodMode");
                return;
            }
            secondsValue = seconds;
            minutesValue = minutes;
            timeText.text = ShowTime(minutes, seconds);
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
        private void OnEnable()
        {
            ActionManager.UIFoodValueChanged += SetFoodValue;
            ActionManager.UIHeartValueChanged += SetHeartValue;
            ActionManager.UITimeValueChanged += SetTimeValue;
        }
        private void OnDisable()
        {
            ActionManager.UIFoodValueChanged -= SetFoodValue;
            ActionManager.UIHeartValueChanged -= SetHeartValue;
            ActionManager.UITimeValueChanged -= SetTimeValue;
        }
    }
}