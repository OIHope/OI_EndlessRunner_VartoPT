using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CPlayer
{
    public class PlayerController : MonoBehaviour
    {
        private InputSystem inputSystem;

        [SerializeField] private GameObject playerRender;
        [SerializeField] private Animator playerAnimator;

        public bool godMode = false;

        private float moveSpeed;
        private float maxHorizontalValue = 3f;
        private float maxVerticalHight = 3f;
        private float minVerticalHight = -1f;
        private float verticalMovementDuration = 0.5f;

        private bool isHit = false, isDead = false;
        private bool isMoving = false, movementInitialized = false;
        private bool inJump = false, inSlide = false;

        private int posID = 1;
        private Vector3 playerPos;
        private Vector3 playerRenderPos;
        private Quaternion playerRenderRot;

        private Coroutine jumpCoroutine, slideCoroutine, tempRemoveControl;

        private void SetMoveSpeed(float currentSpeed) => moveSpeed = currentSpeed;
        private void SetGodMode(bool isGodModeOn) => godMode = isGodModeOn;
        private void Update() => HandleAnimationChange();
        private void HandleAnimationChange()
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
            playerRender.transform.rotation = Quaternion.Lerp(playerRender.transform.rotation, playerRenderRot, 10f * Time.deltaTime);
            playerRenderRot = Quaternion.Lerp(playerRenderRot, Quaternion.identity, 3f * Time.deltaTime);
        }
        private void MoveLeft(InputAction.CallbackContext context)
        {
            if (!movementInitialized) return;
            if (!isMoving) TogglePlayerMove(moveSpeed, true);
            MovePlayerHorizontaly(-maxHorizontalValue, -1);
        }
        private void MoveRight(InputAction.CallbackContext context)
        {
            if (!movementInitialized) return;
            if (!isMoving) TogglePlayerMove(moveSpeed, true);
            MovePlayerHorizontaly(maxHorizontalValue, 1);
        }
        private void Slide(InputAction.CallbackContext context)
        {
            if (!movementInitialized) return;
            if (!isMoving) TogglePlayerMove(moveSpeed, true);

            if (!inSlide) slideCoroutine = StartCoroutine(SlideProcess());
            if (inJump)
            {
                StopCoroutine(jumpCoroutine);
                inJump = false;
            }
        }
        private void JumpAction(InputAction.CallbackContext context)
        {
            if (!movementInitialized)
            {
                TogglePlayerMove(moveSpeed, true);
                return;
            }
            if (!isMoving) TogglePlayerMove(moveSpeed, true);
            if (!inJump) jumpCoroutine = StartCoroutine(JumpProcess());
            if (inSlide)
            {
                StopCoroutine(slideCoroutine);
                inSlide = false;
            }
        }
        private void MovePlayerHorizontaly(float commonXValue, int posIDValue)
        {
            if ((posIDValue == -1 && posID == 0) || (posIDValue == 1 && posID == 2)) return;
            playerPos.x += commonXValue;
            playerRenderPos.x += commonXValue;
            playerRenderRot.y = posIDValue > 0 ? 0.5f : -0.5f;
            posID += posIDValue;
        }
        private void MovePlayerVerticaly(float playerYValue, float playerRenderYValue)
        {
            playerPos.y = playerYValue;
            playerRenderPos.y = playerRenderYValue;
        }
        private void TogglePlayerMove(float moveSpeedValue, bool moveValue)
        {
            if (moveValue)
            {
                isMoving = moveValue;
                ActionManager.ToggleMoving?.Invoke(moveSpeed, isMoving);
                ActionManager.OnStarving += TogglePlayerMove;
                ActionManager.OnHitObstacle += TogglePlayerMove;
                ActionManager.OnHitObstacle += TempRemoveControl;
            }
            else
            {
                isMoving = false;
                ActionManager.ToggleMoving?.Invoke(0f, isMoving);
                ActionManager.OnStarving -= TogglePlayerMove;
                ActionManager.OnHitObstacle -= TogglePlayerMove;
                ActionManager.OnHitObstacle -= TempRemoveControl;
            }
            movementInitialized = !movementInitialized || true;
        }
        private void TempRemoveControl(float i, bool j) => tempRemoveControl = StartCoroutine(OnHitRemoveControl());
        private void TogglePlayerControl(bool toggle)
        {
            if (toggle)
            {
                inputSystem.PlayerMovement.Jump.performed += JumpAction;
                inputSystem.PlayerMovement.Left.performed += MoveLeft;
                inputSystem.PlayerMovement.Right.performed += MoveRight;
                inputSystem.PlayerMovement.Slide.performed += Slide;
            }
            else
            {
                inputSystem.PlayerMovement.Jump.performed -= JumpAction;
                inputSystem.PlayerMovement.Left.performed -= MoveLeft;
                inputSystem.PlayerMovement.Right.performed -= MoveRight;
                inputSystem.PlayerMovement.Slide.performed -= Slide;
            }
        }
        private void PlayerDie()
        {
            isDead = true;
            TogglePlayerMove(0f, false);
            TogglePlayerControl(false);
        }
        private IEnumerator JumpProcess()
        {
            MovePlayerVerticaly(maxVerticalHight, maxVerticalHight);
            inJump = true;
            yield return new WaitForSeconds(verticalMovementDuration);
            MovePlayerVerticaly(0f, 0f);
            inJump = false;
        }
        private IEnumerator SlideProcess()
        {
            MovePlayerVerticaly(minVerticalHight, 0f);
            inSlide = true;
            yield return new WaitForSeconds(verticalMovementDuration);
            MovePlayerVerticaly(0f, 0f);
            inSlide = false;
        }
        private IEnumerator OnHitRemoveControl()
        {
            TogglePlayerControl(false);
            isHit = true;
            yield return new WaitForSeconds(1f);
            isHit = false;
            if (!isDead) TogglePlayerControl(true);
        }
        private void ResetPlayerMovementClass()
        {
            ActionManager.AskDifficultyChanged?.Invoke();
            ActionManager.AskGodModeChanged?.Invoke();
            inputSystem ??= new InputSystem();
            posID = 1;
            playerPos = Vector3.zero;
            playerRenderPos = Vector3.zero;
            TogglePlayerMove(0f, false);
            TogglePlayerControl(true);
            isDead = false;
            movementInitialized = false;
        }
        private void OnEnable()
        {
            ActionManager.DifficultyChanger += SetMoveSpeed;
            ActionManager.GodModeChanger += SetGodMode;
            ActionManager.OnDeath += PlayerDie;
            ActionManager.StartNewGame += ResetPlayerMovementClass;
            ResetPlayerMovementClass();
            inputSystem.Enable();
            TogglePlayerControl(true);
        }
        private void OnDisable()
        {
            inputSystem.Disable();
            TogglePlayerControl(false);
            ActionManager.DifficultyChanger -= SetMoveSpeed;
            ActionManager.GodModeChanger -= SetGodMode;
            ActionManager.OnDeath -= PlayerDie;
            ActionManager.StartNewGame -= ResetPlayerMovementClass;
        }
        private void OnDestroy() => StopAllCoroutines();
    }
}