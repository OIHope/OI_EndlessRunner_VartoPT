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

        private void SetFoodValue(int value)
        {
            foodValue = value;
            foodText.text = ($"Food: {foodValue}/100");
        }
        private void SetHeartValue(int value)
        {
            heartValue = value;
            heartText.text = ($"Heart: {heartValue}");
        }
        private void SetTimeValue(int seconds, int minutes)
        {
            secondsValue = seconds;
            minutesValue = minutes;
            timeText.text = ($"Time: {minutesValue}:{secondsValue}");
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