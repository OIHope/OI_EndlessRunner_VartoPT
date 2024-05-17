using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace FUI
{
    public class UIGameOverManager : MonoBehaviour
    {
        [SerializeField] private Button restartButton;

        private void RestartScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        private void OnEnable()
        {
            restartButton.onClick.AddListener(RestartScene);
        }
        private void OnDisable()
        {
            restartButton.onClick.RemoveAllListeners();
        }
    }
}