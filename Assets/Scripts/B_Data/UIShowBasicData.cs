using TMPro;
using UnityEngine;

namespace FUI
{
    public class UIShowBasicData : MonoBehaviour
    {
        private TextMeshProUGUI statText;
        private int foodValue;
        private int heartValue;
        private string status;

        private void Update()
        {
            statText.text = 
                ("Game status: " + status + 
                "\n\n" + "Heart: " + heartValue + 
                "\n" + "Food: " + foodValue);
        }
        private void SetFoodValue(int value)
        {
            foodValue = value;
        }
        private void SetHeartValue(int value)
        {
            heartValue = value;
        }
        private void SetGameStatus(string value)
        {
            status = value;
        }
        private void ResetUIBasicDataClass()
        {
            statText = GetComponent<TextMeshProUGUI>();
        }
        private void OnEnable()
        {
            ResetUIBasicDataClass();
            ActionManager.UIFoodValueChanged += SetFoodValue;
            ActionManager.UIHeartValueChanged += SetHeartValue;
            ActionManager.UIGameStatusChanged += SetGameStatus;
            ActionManager.StartNewGame += ResetUIBasicDataClass;
        }
        private void OnDisable()
        {
            ActionManager.UIFoodValueChanged -= SetFoodValue;
            ActionManager.UIHeartValueChanged -= SetHeartValue;
            ActionManager.UIGameStatusChanged -= SetGameStatus;
            ActionManager.StartNewGame -= ResetUIBasicDataClass;
        }
    }
}