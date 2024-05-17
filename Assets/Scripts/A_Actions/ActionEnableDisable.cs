using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AComponents
{
    public class ActionEnableDisable : ActionBase
    {
        [SerializeField] private bool _EnableDisable;
        [SerializeField] private GameObject[] target;
        [SerializeField] private bool onThisInstance;
        protected override void ExecuteInternal()
        {
            if (onThisInstance)
            {
                gameObject.SetActive(_EnableDisable);
                return;
            }
            foreach (var item in target)
            {
                item.SetActive(_EnableDisable);
            }
        }
    }
}