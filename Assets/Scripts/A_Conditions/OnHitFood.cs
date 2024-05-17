using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AComponents
{
    public class OnHitFood : MonoBehaviour
    {
        [SerializeField] private ActionBase[] actions;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ActionManager.OnHitFood?.Invoke();
                foreach (var action in actions)
                {
                    action.Execute();
                }
            }
        }
    }
}