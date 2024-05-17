using AComponents;
using UnityEngine;

public class OnHitObstacle : MonoBehaviour
{
    [SerializeField] private ActionBase[] actions;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ActionManager.OnHitObstacle?.Invoke();
            foreach (var action in actions) 
            {
                action.Execute();
            }
        }
    }
}
