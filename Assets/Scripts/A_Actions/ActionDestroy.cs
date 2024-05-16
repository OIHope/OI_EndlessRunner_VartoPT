using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AComponents
{
    public class ActionDestroy : ActionBase
    {
        [SerializeField] private GameObject target;
        [SerializeField] private float delay = 0f;
        protected override void ExecuteInternal()
        {
            Destroy(target, delay);
        }
    }
}