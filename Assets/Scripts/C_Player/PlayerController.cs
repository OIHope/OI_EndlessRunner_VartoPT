using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputSystem inputSystem;
    private Rigidbody playerRb;
    [SerializeField][Range(0f, 50f)] private float moveSpeed;
    [SerializeField][Range(0f, 50f)] private float jumpPower;
    [SerializeField] private bool isMoving = true;
    [SerializeField] private bool  onLeft = false, onCenter = true, onRight = false;
    private bool onJump = false, onSlide = false;
    private Vector3 playerPos = Vector3.zero;

    private void Awake()
    {
        inputSystem = new InputSystem();
        inputSystem.PlayerMovement.Jump.performed += JumpAction;
        inputSystem.PlayerMovement.Left.performed += MoveLeft;
        inputSystem.PlayerMovement.Right.performed += MoveRight;
        inputSystem.PlayerMovement.Slide.performed += Slide;

        playerRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerPos, 7f * Time.deltaTime);
    }
    private void MoveLeft(InputAction.CallbackContext context)
    {
        if (onCenter)
        {
            playerPos.x -= 3f;
            onRight = false;
            onCenter = false;
            onLeft = true;
        }
        else if (onRight)
        {
            playerPos.x -= 3f;
            onRight = false;
            onCenter = true;
            onLeft = false;
        }
        else
        {
            onRight = false;
            onCenter = false;
            onLeft = true;
        }
    }
    private void MoveRight(InputAction.CallbackContext context)
    {
        if (onCenter)
        {
            playerPos.x += 3f;
            onRight = true;
            onCenter = false;
            onLeft = false;
        }
        else if (onLeft)
        {
            playerPos.x += 3f;
            onRight = false;
            onCenter = true;
            onLeft = false;
        }
        else
        {
            onRight = true;
            onCenter = false;
            onLeft = false;
        }
    }
    private void Slide(InputAction.CallbackContext context)
    {
        if (!onSlide)
        {
            Debug.Log("SLIDE!");
        }
    }
    private void JumpAction(InputAction.CallbackContext context)
    {
        if (!onJump)
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        if (!isMoving)
        {
            ActionManager.OnStartMoving?.Invoke(moveSpeed);
            isMoving = true;
        }
    }
    private void OnEnable()
    {
        inputSystem.Enable();
    }
    private void OnDisable()
    {
        inputSystem.Disable();
    }
}
