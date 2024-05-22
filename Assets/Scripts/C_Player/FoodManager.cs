using System;
using System.Collections;
using UnityEngine;

namespace CPlayer
{
    public class FoodManager : MonoBehaviour
    {
        [SerializeField] private int foodValue = 5;
        [SerializeField] private int foodAmount = 50;
        [SerializeField] private int maxFood = 100;
        [SerializeField] private float foodDecreaseSpeed = 1f;
        [SerializeField] private PlayerController player;

        private Coroutine foodDecreaseCoroutine;
        private void Update() => ManageFoodValues();
        private void AddFoodValue()
        {
            if (player.godMode) return;
            foodAmount += foodValue;
            ActionManager.UIFoodValueChanged?.Invoke(foodAmount);
        }
        private void ManageFoodValues()
        {
            if (player.godMode) return;
            if (foodAmount > maxFood)
            {
                foodAmount = (int)(maxFood * 0.3f);
                ActionManager.OnFillFoodBar?.Invoke();
            }
            if (foodAmount <= 0)
            {
                foodAmount = 0;
                ActionManager.OnStarving?.Invoke(0f, false);
            }
        }
        private void ResetFood()
        {
            if (player.godMode) return;
            foodAmount = (int)(maxFood * 0.3f);
            ActionManager.UIFoodValueChanged?.Invoke(foodAmount);
        }
        private void TurnOnFoodDecrease(float i, bool isMoving)
        {
            if (player.godMode) return;
            if (isMoving) foodDecreaseCoroutine = StartCoroutine(FoodDecrease());
            else if (foodDecreaseCoroutine != null) StopCoroutine(foodDecreaseCoroutine);
        }
        private IEnumerator FoodDecrease()
        {
            while (true)
            {
                yield return new WaitForSeconds(foodDecreaseSpeed);
                foodAmount--;
                ActionManager.UIFoodValueChanged?.Invoke(foodAmount);
                ActionManager.OnSecondPass?.Invoke();
            }
        }
        private void ResetFoodManagerClass()
        {
            ResetFood();
        }
        private void OnEnable()
        {
            ActionManager.OnLoseHeart += ResetFood;
            ActionManager.OnHitFood += AddFoodValue;
            ActionManager.ToggleMoving += TurnOnFoodDecrease;
            ActionManager.StartNewGame += ResetFoodManagerClass;
            ResetFoodManagerClass();
        }
        private void OnDisable()
        {
            ActionManager.OnLoseHeart -= ResetFood;
            ActionManager.OnHitFood -= AddFoodValue;
            ActionManager.ToggleMoving -= TurnOnFoodDecrease;
            ActionManager.StartNewGame -= ResetFoodManagerClass;
        }
    }
}