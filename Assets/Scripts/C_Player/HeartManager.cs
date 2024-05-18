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

        private void Awake()
        {
            ResetClass();
        }
        private void Update()
        {
            ManageHeart();
        }
        private void AddHeart()
        {
            heartCount++;
            ActionManager.UIHeartValueChanged?.Invoke(heartCount);
        }
        private void RemoveHeart()
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
                ActionManager.UIGameStatusChanged?.Invoke("Game Over!");
                deathIsTriggered = true;
            }
        }
        private void ResetClass()
        {
            deathIsTriggered = false;
            heartCount = heartStartCount;
            ActionManager.UIHeartValueChanged?.Invoke(heartCount);
            ActionManager.UIGameStatusChanged?.Invoke("Fresh Start");
        }
        private void OnEnable()
        {
            ActionManager.OnFillFoodBar += AddHeart;
            ActionManager.OnStarving += RemoveHeart;
            ActionManager.OnHitObstacle += RemoveHeart;
            ActionManager.StartNewGame += ResetClass;
        }
        private void OnDisable()
        {
            ActionManager.OnFillFoodBar -= AddHeart;
            ActionManager.OnStarving -= RemoveHeart;
            ActionManager.OnHitObstacle -= RemoveHeart;
            ActionManager.StartNewGame -= ResetClass;

        }
    }
}