using UnityEngine;

namespace AComponents
{
    public class ComponentTimeController : MonoBehaviour
    {
        [SerializeField][Range(0f,1f)] private float timeScale = 1f;
        private float originalTimeDelta;

        private void Start()
        {
            originalTimeDelta = Time.timeScale;
        }
        private void Update()
        {
            Time.timeScale = originalTimeDelta * timeScale;
        }
        private void PauseGame(bool isPause)
        {
            if (isPause) 
            {
                timeScale = 0f;
            }
            else
            {
                timeScale = 1f;
            }
        }
        private void OnEnable()
        {
            ActionManager.PauseGame += PauseGame;
        }
        private void OnDisable()
        {
            ActionManager.PauseGame -= PauseGame;
        }
    }

}