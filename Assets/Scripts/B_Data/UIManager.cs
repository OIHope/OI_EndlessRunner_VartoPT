using System.Collections;
using System.Collections.Generic;
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

        private void Awake()
        {
            inputSystem ??= new InputSystem();

            newGamePanel.SetActive(true);
            sidePanel.SetActive(true);
            pausePanel.SetActive(false);
            gameOverPanel.SetActive(false);

            ActionManager.OnToggleMoving += OffNewGamePanel;
        }
        private void OffNewGamePanel(float n, bool m)
        {
            newGamePanel.SetActive(false);
            ActionManager.OnToggleMoving -= OffNewGamePanel;
        }
        private void ToggleSidePanel(InputAction.CallbackContext callback)
        {
            sidePanel.SetActive(!sidePanel.activeSelf);
        }
        private void TogglePausePanel(InputAction.CallbackContext callback)
        {
            pausePanel.SetActive(!pausePanel.activeSelf);
        }
        private void OpenGameOverPanel()
        {
            gameOverPanel.SetActive(true);
            sidePanel.SetActive(true);
            pausePanel.SetActive(false);
            inputSystem.UIControl.SidePanel.performed -= ToggleSidePanel;
            inputSystem.UIControl.PausePanel.performed -= TogglePausePanel;
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
        private void OnEnable()
        {
            inputSystem.Enable();
            UIControlEnable();
        }
        private void OnDisable()
        {
            inputSystem.Disable();
            UIControlDisable();
        }
    }
}