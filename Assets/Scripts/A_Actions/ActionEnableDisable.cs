using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AComponents
{
    public class ActionEnableDisable : ActionBase
    {
        [SerializeField] private bool _EnableDisable;
        [SerializeField] private GameObject[] target;
        protected override void ExecuteInternal()
        {
            foreach (var item in target)
            {
                item.SetActive(_EnableDisable);
            }
        }
    }
}