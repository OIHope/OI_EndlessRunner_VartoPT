using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CPlayer
{
    public class HeartManager : MonoBehaviour
    {
        [SerializeField] private int heartStartCount = 3;
        private int heartCount;
        private bool deathIsTriggered;

        private void Update()
        {
            ManageHeart();
        }
        private void AddHeart()
        {
            heartCount++;
            ActionManager.UIHeartValueChanged?.Invoke(heartCount);
        }
        private void RemoveHeart(float i, bool j)
        {
            heartCount--;
            ActionManager.UIHeartValueChanged?.Invoke(heartCount);
            ActionManager.OnLoseHeart?.Invoke();
        }
        private void ManageHeart()
        {
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
            ResetHeartManagerClass();
            ActionManager.OnFillFoodBar += AddHeart;
            ActionManager.OnStarving += RemoveHeart;
            ActionManager.OnHitObstacle += RemoveHeart;
            ActionManager.StartNewGame += ResetHeartManagerClass;
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