using System;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

namespace CPlayer
{
    public class FoodManager : MonoBehaviour
    {
        [SerializeField] private int foodValue = 5;
        [SerializeField] private int foodAmount = 50;
        [SerializeField] private int maxFood = 100;
        [SerializeField] private float foodDecreaseSpeed = 5f;

        private Coroutine foodDecreaseCoroutine;

        private void Update()
        {
            ManageFoodValues();
        }
        private void AddFoodValue()
        {
            foodAmount += foodValue;
            ActionManager.UIFoodValueChanged?.Invoke(foodAmount);
        }
        private void ManageFoodValues()
        {
            if (foodAmount > maxFood)
            {
                foodAmount = (int)(maxFood * 0.3f);
                ActionManager.OnFillFoodBar?.Invoke();
            }
            if (foodAmount <= 0)
            {
                foodAmount = 0;
                ActionManager.OnStarving?.Invoke();
            }
        }
        private void ResetFood()
        {
            foodAmount = (int)(maxFood * 0.3f);
            ActionManager.UIFoodValueChanged?.Invoke(foodAmount);
        }
        private void TurnOnFoodDecrease(float i, bool isMoving)
        {
            if (isMoving)
            {
                foodDecreaseCoroutine = StartCoroutine(FoodDecrease());
            }
            else
            {
                StopCoroutine(foodDecreaseCoroutine);
            }
        }
        private IEnumerator FoodDecrease()
        {
            while (true)
            {
                yield return new WaitForSeconds(foodDecreaseSpeed);
                foodAmount--;
                ActionManager.UIFoodValueChanged?.Invoke(foodAmount);
            }
        }
        private void OnEnable()
        {
            ActionManager.OnLoseHeart += ResetFood;
            ActionManager.OnHitFood += AddFoodValue;
            ActionManager.OnToggleMoving += TurnOnFoodDecrease;
        }
        private void OnDisable()
        {
            ActionManager.OnLoseHeart -= ResetFood;
            ActionManager.OnHitFood -= AddFoodValue;
            ActionManager.OnToggleMoving -= TurnOnFoodDecrease;
        }
    }
}