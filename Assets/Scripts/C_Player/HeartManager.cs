using UnityEngine;

namespace CPlayer
{
    public class HeartManager : MonoBehaviour
    {
        [SerializeField] private int heartStartCount = 3;
        private int heartCount;
        private bool deathIsTriggered;
        [SerializeField] private PlayerController player;

        private void Update() => ManageHeart();
        private void AddHeart()
        {
            if (player.godMode) return;
            heartCount++;
            ActionManager.UIHeartValueChanged?.Invoke(heartCount);
        }
        private void RemoveHeart(float i, bool j)
        {
            if (player.godMode) return;
            heartCount--;
            ActionManager.UIHeartValueChanged?.Invoke(heartCount);
            ActionManager.OnLoseHeart?.Invoke();
        }
        private void ManageHeart()
        {
            if (player.godMode) return;
            if (heartCount <= 0 && !deathIsTriggered)
            {
                ActionManager.OnDeath?.Invoke();
                deathIsTriggered = true;
            }
        }
        private void ResetHeartManagerClass()
        {
            deathIsTriggered = false;
            heartCount = heartStartCount;
            ActionManager.UIHeartValueChanged?.Invoke(heartCount);
        }
        private void OnEnable()
        {
            ActionManager.OnFillFoodBar += AddHeart;
            ActionManager.OnStarving += RemoveHeart;
            ActionManager.OnHitObstacle += RemoveHeart;
            ActionManager.StartNewGame += ResetHeartManagerClass;
            ResetHeartManagerClass();
        }
        private void OnDisable()
        {
            ActionManager.OnFillFoodBar -= AddHeart;
            ActionManager.OnStarving -= RemoveHeart;
            ActionManager.OnHitObstacle -= RemoveHeart;
            ActionManager.StartNewGame -= ResetHeartManagerClass;
        }
    }
}