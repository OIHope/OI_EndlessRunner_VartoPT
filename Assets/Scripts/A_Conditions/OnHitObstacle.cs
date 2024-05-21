using UnityEngine;

namespace AComponents
{
    public class OnHitObstacle : MonoBehaviour
    {
        [SerializeField] private ActionBase[] actions;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ActionManager.OnHitObstacle?.Invoke(0f, false);
                foreach (var action in actions)
                {
                    action.Execute();
                }
            }
        }
    }
}