using UnityEngine;

namespace AComponents
{
    public class ActionInstantiate : ActionBase
    {
        [SerializeField] private GameObject[] target;
        [SerializeField] private Transform parent;
        [SerializeField] private Transform spawnPos;
        protected override void ExecuteInternal()
        {
            foreach (var instance in target)
            {
                Instantiate(instance, spawnPos.position, Quaternion.identity, parent);
            }
        }
    }
}