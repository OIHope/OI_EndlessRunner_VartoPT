using UnityEngine;

namespace BData
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private int priceFood;
        [SerializeField] private int priceSecond;
        [SerializeField] private int priceMinute;
        [Space]
        [SerializeField] private int tFood;
        [SerializeField] private int tMinutes;
        [SerializeField] private int tSeconds;
        [Space]
        [SerializeField] private int bFood;
        [SerializeField] private int bMinutes;
        [SerializeField] private int bSeconds;
        [Space]
        [SerializeField] private int tScore;
        [SerializeField] private int bScore;

        private void AddFoodScore()
        {
            tFood++;
        }
        private void AddSecondsScore()
        {
            tSeconds++;
            ManageTimeScore();
        }
        private void AddMinutesScore()
        {
            tMinutes++;
        }
        private void ManageTimeScore()
        {
            if (tSeconds >= 60)
            {
                tSeconds = 0;
                AddMinutesScore();
            }
            ActionManager.UITimeValueChanged?.Invoke(tSeconds, tMinutes);
        }
        private void ManageTotalScore()
        {
            tScore = CalculateTotalScore(tFood, tSeconds, tMinutes);
            bScore = CalculateTotalScore(bFood, bSeconds, bMinutes);
            SetBestScore();
            ActionManager.FinalScoreUdpate?.Invoke(tFood, tSeconds, tMinutes, tScore, bScore);
        }
        private void SetBestScore()
        {
            if (bScore < tScore)
            {
                bScore = tScore;
                bFood = tFood;
                bSeconds = tSeconds;
                bMinutes = tMinutes;
            }
        }
        private void ResetPlayerScore()
        {
            tFood = 0;
            tMinutes = 0;
            tSeconds = 0;
            tScore = 0;
            ActionManager.UITimeValueChanged?.Invoke(tSeconds, tMinutes);
        }
        private int CalculateTotalScore(int foodValue, int secondsValue, int minutesValue)
        {
            int foodScore = foodValue * priceFood;
            int secondsScore = secondsValue * priceSecond;
            int minuteScore = minutesValue * priceMinute;
            return (foodScore + secondsScore + minuteScore);
        }

        private void OnEnable()
        {
            ActionManager.OnHitFood += AddFoodScore;
            ActionManager.OnSecondPass += AddSecondsScore;
            ActionManager.tempGameOverEnable += ManageTotalScore;
            ActionManager.StartNewGame += ResetPlayerScore;
            ActionManager.StopGame += ResetPlayerScore;
        }
        private void OnDisable()
        {
            ActionManager.OnHitFood -= AddFoodScore;
            ActionManager.OnSecondPass -= AddSecondsScore;
            ActionManager.tempGameOverEnable -= ManageTotalScore;
            ActionManager.StartNewGame -= ResetPlayerScore;
            ActionManager.StopGame -= ResetPlayerScore;
        }
    }
}