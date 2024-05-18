using UnityEngine;
using UnityEngine.InputSystem;

namespace FUI
{
    public class UIManager : MonoBehaviour
    {
        private InputSystem inputSystem;

        [SerializeField] private GameObject sidePanel;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject newGamePanel;
        [SerializeField] private GameObject gameOverPanel;

        private void OffNewGamePanel(float n, bool m)
        {
            if (!m) return;
            newGamePanel.SetActive(false);
            inputSystem.UIControl.PausePanel.performed += TogglePausePanel;
            ActionManager.OnToggleMoving -= OffNewGamePanel;
        }
        private void ToggleSidePanel(InputAction.CallbackContext callback)
        {
            sidePanel.SetActive(!sidePanel.activeSelf);
        }
        private void TogglePausePanel(InputAction.CallbackContext callback)
        {
            pausePanel.SetActive(!pausePanel.activeSelf);
            if (pausePanel.activeSelf)
            {
                ActionManager.PauseGame?.Invoke(true);
            }
            else
            {
                ActionManager.PauseGame?.Invoke(false);
            }
        }
        private void OpenGameOverPanel()
        {
            gameOverPanel.SetActive(true);
            sidePanel.SetActive(true);
            pausePanel.SetActive(false);
            UIControlDisable();
        }

        private void UIControlEnable()
        {
            inputSystem.UIControl.SidePanel.performed += ToggleSidePanel;
            inputSystem.UIControl.PausePanel.performed += TogglePausePanel;
            ActionManager.OnDeath += OpenGameOverPanel;
        }
        private void UIControlDisable()
        {
            inputSystem.UIControl.SidePanel.performed -= ToggleSidePanel;
            inputSystem.UIControl.PausePanel.performed -= TogglePausePanel;
            ActionManager.OnDeath -= OpenGameOverPanel;
        }
        private void ResetClass()
        {
            inputSystem ??= new InputSystem();

            newGamePanel.SetActive(true);
            sidePanel.SetActive(true);
            pausePanel.SetActive(false);
            gameOverPanel.SetActive(false);

            UIControlEnable();
            inputSystem.UIControl.PausePanel.performed -= TogglePausePanel;
            ActionManager.OnToggleMoving += OffNewGamePanel;
        }
        private void OnEnable()
        {
            ResetClass();
            inputSystem.Enable();
            ActionManager.StartNewGame += ResetClass;
        }
        private void OnDisable()
        {
            inputSystem.Disable();
            UIControlDisable();
            ActionManager.StartNewGame -= ResetClass;
        }
    }
}