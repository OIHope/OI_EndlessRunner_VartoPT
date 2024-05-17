using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CPlayer
{
    public class PlayerMovement : MonoBehaviour
    {
        private InputSystem inputSystem;

        [SerializeField][Range(0f, 50f)] private float moveSpeed;
        [SerializeField][Range(0f, 5f)] private float jumpDuration;
        [SerializeField][Range(0f, 5f)] private float slideDuration;
        [SerializeField] private bool isMoving = false;
        private int posID = 1;
        private bool onJump = false, onSlide = false;
        private Vector3 playerPos;

        private Coroutine jumpCoroutine;
        private Coroutine slideCoroutine;
        private Coroutine tempRemoveControl;


        private void Awake()
        {
            inputSystem = new InputSystem();
        }
        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, playerPos, 7f * Time.deltaTime);
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

            if (!onSlide)
            {
                slideCoroutine = StartCoroutine(SlideProcess());
            }
            if (onJump)
            {
                StopCoroutine(jumpCoroutine);
                onJump = false;
            }
        }
        private void JumpAction(InputAction.CallbackContext context)
        {
            if (!isMoving)
            {
                StartMoving();
                return;
            }

            if (!onJump)
            {
                jumpCoroutine = StartCoroutine(JumpProcess());
            }
            if (onSlide)
            {
                StopCoroutine(slideCoroutine);
                onSlide = false;
            }
        }
        private void StartMoving()
        {
            ActionManager.OnToggleMoving?.Invoke(moveSpeed, true);

            ActionManager.OnStarving += StopMoving;
            ActionManager.OnHitObstacle += StopMoving;
            ActionManager.OnHitObstacle += TempRemoveControl;
            isMoving = true;
        }
        private void StopMoving()
        {
            ActionManager.OnToggleMoving?.Invoke(0f, false);

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
            onJump = true;
            yield return new WaitForSeconds(jumpDuration);
            playerPos.y = 0f;
            onJump = false;
        }
        private IEnumerator SlideProcess()
        {
            playerPos.y = -1f;
            onSlide = true;
            yield return new WaitForSeconds(jumpDuration);
            playerPos.y = 0f;
            onSlide = false;
        }
        private IEnumerator OnHitRemoveControl()
        {
            inputSystem.Disable();
            yield return new WaitForSeconds(1f);
            inputSystem.Enable();
        }
        private void OnEnable()
        {
            inputSystem.Enable();
            inputSystem.PlayerMovement.Jump.performed += JumpAction;
            inputSystem.PlayerMovement.Left.performed += MoveLeft;
            inputSystem.PlayerMovement.Right.performed += MoveRight;
            inputSystem.PlayerMovement.Slide.performed += Slide;
        }
        private void OnDisable()
        {
            inputSystem.Disable();
            inputSystem.PlayerMovement.Jump.performed -= JumpAction;
            inputSystem.PlayerMovement.Left.performed -= MoveLeft;
            inputSystem.PlayerMovement.Right.performed -= MoveRight;
            inputSystem.PlayerMovement.Slide.performed -= Slide;
        }
    }
}