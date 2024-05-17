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

        private void Awake()
        {
            ActionManager.OnHitFood += AddFoodValue;
            ActionManager.OnToggleMoving += TurnOnFoodDecrease;
        }
        private void Update()
        {
            ManageFoodValues();
        }
        private void AddFoodValue()
        {
            foodAmount += foodValue;
        }
        private void ManageFoodValues()
        {
            if (foodAmount > maxFood)
            {
                foodAmount = maxFood;
            }
            if (foodAmount <= 0)
            {
                foodAmount = 0;
                ActionManager.OnStarving?.Invoke();
                ActionManager.OnToggleMoving += ResetFood;
            }
        }
        private void ResetFood(float i, bool j)
        {
            foodAmount = maxFood/2;
            ActionManager.OnToggleMoving -= ResetFood;
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
            }
        }
        private void OnEnable()
        {
            
        }
        private void OnDisable()
        {
            
        }
    }
}