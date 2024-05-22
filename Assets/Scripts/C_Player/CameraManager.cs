using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimator;
    [SerializeField] private GameObject target;
    [SerializeField] private float smoothness;
    private Vector3 defPosition;

    private void Awake() => defPosition = transform.position;
    private void FixedUpdate()
    {
        var targetPos = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothness * Time.deltaTime);
    }
    private void PlayHitAnimation(float i, bool j) => cameraAnimator.SetTrigger("playerIsHit");
    private void OnEnable()
    {
        ActionManager.OnHitObstacle += PlayHitAnimation;
        transform.position = defPosition;
    }
    private void OnDisable() => ActionManager.OnHitObstacle -= PlayHitAnimation;
}
