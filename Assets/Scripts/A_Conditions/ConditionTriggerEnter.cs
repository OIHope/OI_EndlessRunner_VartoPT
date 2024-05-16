using UnityEngine;

namespace AComponents
{
    public class ConditionTriggerEnter : MonoBehaviour
    {
        [SerializeField] private string targetTag;
        [SerializeField] private ActionBase[] actions;
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == targetTag)
            {
                foreach (var action in actions)
                {
                    action.Execute();
                }
            }
        }
    }
}