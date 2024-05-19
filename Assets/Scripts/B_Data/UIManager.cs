using UnityEngine;

namespace FUI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject uiMainMenu;
        [SerializeField] private GameObject uiGameplay;
        [SerializeField] private GameObject gmMainMenu;
        [SerializeField] private GameObject gmGameplay;

        private void Start()
        {
            ActionManager.StopGame?.Invoke();
        }
        private void Update()
        {
            //if (Input.GetButtonDown("I"))
            //{
            //    var invocationList = ActionManager.StartNewGame.GetInvocationList();
            //    foreach (var subscriber in invocationList)
            //    {
            //        Debug.Log($"Subscriber: {subscriber.Method.Name}, Target: {subscriber.Target}");
            //    }
            //}
        }
        private void BackToMenu()
        {
            uiMainMenu.SetActive(true);
            uiGameplay.SetActive(false);
            gmMainMenu.SetActive(true);
            gmGameplay.SetActive(false);
        }
        private void BackToGameplay()
        {
            uiMainMenu.SetActive(false);
            uiGameplay.SetActive(true);
            gmMainMenu.SetActive(false);
            gmGameplay.SetActive(true);
        }
        private void OnEnable()
        {
            ActionManager.StartNewGame += BackToGameplay;
            ActionManager.StopGame += BackToMenu;
        }
        private void OnDisable()
        {
            ActionManager.StartNewGame -= BackToGameplay;
            ActionManager.StopGame -= BackToMenu;
        }
    }
}