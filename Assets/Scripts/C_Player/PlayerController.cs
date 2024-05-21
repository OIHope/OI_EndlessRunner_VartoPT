using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CPlayer
{
    public class PlayerController : MonoBehaviour
    {
        private InputSystem inputSystem;

        [SerializeField] private GameObject playerRender;
        [SerializeField] private Animator playerAnimator;

        [SerializeField] private bool isHit;

        [SerializeField] private float moveSpeed;
        [SerializeField] private bool godMode = false;

        [SerializeField][Range(0f, 5f)] private float jumpDuration;
        [SerializeField][Range(0f, 5f)] private float slideDuration;
        [SerializeField] private bool isMoving = false;
        private int posID = 1;
        private bool inJump = false, inSlide = false;
        private Vector3 playerPos;
        private Vector3 playerRenderPos;

        private Coroutine jumpCoroutine;
        private Coroutine slideCoroutine;
        private Coroutine tempRemoveControl;

        [SerializeField] private bool isDead = false;

        private void SetMoveSpeed(float currentSpeed) => moveSpeed = currentSpeed;
        private void SetGodMode(bool isGodModeOn) => godMode = isGodModeOn;
        private void Update()
        {
            playerAnimator.SetBool("isIdle", !isMoving);
            playerAnimator.SetBool("isRunning", isMoving);
            playerAnimator.SetBool("inJump", inJump);
            playerAnimator.SetBool("inSlide", inSlide);
            playerAnimator.SetBool("isHit", isHit);
            playerAnimator.SetBool("isDead", isDead);
        }
        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, playerPos, 7f * Time.deltaTime);
            playerRender.transform.position = Vector3.Lerp(playerRender.transform.position, playerRenderPos, 7f * Time.deltaTime);
        }
        private void MoveLeft(InputAction.CallbackContext context)
        {
            if (!isMoving)
            {
                StartMoving();
                return;
            }

            if (posID != 0)
            {
                playerPos.x -= 3f;
                playerRenderPos.x -= 3f;
                posID -= 1;
            }
        }
        private void MoveRight(InputAction.CallbackContext context)
        {
            if (!isMoving)
            {
                StartMoving();
                return;
            }

            if (posID != 2)
            {
                playerPos.x += 3f;
                playerRenderPos.x += 3f;
                posID += 1;
            }
        }
        private void Slide(InputAction.CallbackContext context)
        {
            if (!isMoving)
            {
                StartMoving();
                return;
            }

            if (!inSlide)
            {
                slideCoroutine = StartCoroutine(SlideProcess());
            }
            if (inJump)
            {
                StopCoroutine(jumpCoroutine);
                inJump = false;
            }
        }
        private void JumpAction(InputAction.CallbackContext context)
        {
            if (!isMoving)
            {
                StartMoving();
                return;
            }

            if (!inJump)
            {
                jumpCoroutine = StartCoroutine(JumpProcess());
            }
            if (inSlide)
            {
                StopCoroutine(slideCoroutine);
                inSlide = false;
            }
        }
        private void StartMoving()
        {
            ActionManager.ToggleMoving?.Invoke(moveSpeed, true);

            ActionManager.OnStarving += StopMoving;
            ActionManager.OnHitObstacle += StopMoving;
            ActionManager.OnHitObstacle += TempRemoveControl;
            isMoving = true;
        }
        private void StopMoving()
        {
            ActionManager.ToggleMoving?.Invoke(0f, false);

            ActionManager.OnStarving -= StopMoving;
            ActionManager.OnHitObstacle -= StopMoving;
            ActionManager.OnHitObstacle -= TempRemoveControl;
            isMoving = false;
        }
        private void TempRemoveControl()
        {
            tempRemoveControl = StartCoroutine(OnHitRemoveControl());
        }
        private IEnumerator JumpProcess()
        {
            playerPos.y = 3f;
            playerRenderPos.y = 3f;
            inJump = true;
            yield return new WaitForSeconds(jumpDuration);
            playerPos.y = 0f;
            playerRenderPos.y = 0f;
            inJump = false;
        }
        private IEnumerator SlideProcess()
        {
            playerPos.y = -1f;
            playerRenderPos.y = 0f;
            inSlide = true;
            yield return new WaitForSeconds(jumpDuration);
            playerPos.y = 0f;
            playerRenderPos.y = 0f;
            inSlide = false;
        }
        private IEnumerator OnHitRemoveControl()
        {
            PlayerContolDisable();
            isHit = true;
            yield return new WaitForSeconds(1f);
            isHit = false;
            if (!isDead)
            {
                PlayerContolEnable();
            }
        }
        private void PlayerContolDisable()
        {
            inputSystem.PlayerMovement.Jump.performed -= JumpAction;
            inputSystem.PlayerMovement.Left.performed -= MoveLeft;
            inputSystem.PlayerMovement.Right.performed -= MoveRight;
            inputSystem.PlayerMovement.Slide.performed -= Slide;
        }
        private void PlayerContolEnable()
        {
            inputSystem.PlayerMovement.Jump.performed += JumpAction;
            inputSystem.PlayerMovement.Left.performed += MoveLeft;
            inputSystem.PlayerMovement.Right.performed += MoveRight;
            inputSystem.PlayerMovement.Slide.performed += Slide;
        }
        private void PlayerDie()
        {
            isDead = true;
            StopMoving();
            PlayerContolDisable();
        }
        private void ResetPlayerMovementClass()
        {
            ActionManager.AskDifficultyChanged?.Invoke();
            ActionManager.AskGodModeChanged?.Invoke();
            inputSystem ??= new InputSystem();
            playerPos = Vector3.zero;
            playerRenderPos = Vector3.zero;
            posID = 1;
            isDead = false;
            StopMoving();
            PlayerContolEnable();
        }
        
        private void OnEnable()
        {
            ActionManager.DifficultyChanger += SetMoveSpeed;
            ActionManager.GodModeChanger += SetGodMode;
            ActionManager.OnDeath += PlayerDie;
            ActionManager.StartNewGame += ResetPlayerMovementClass;
            ResetPlayerMovementClass();
            inputSystem.Enable();
            PlayerContolEnable();
        }
        private void OnDisable()
        {
            inputSystem.Disable();
            PlayerContolDisable();
            ActionManager.DifficultyChanger -= SetMoveSpeed;
            ActionManager.GodModeChanger -= SetGodMode;
            ActionManager.OnDeath -= PlayerDie;
            ActionManager.StartNewGame -= ResetPlayerMovementClass;
        }
        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}