using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public float FollowSpeed = 3f;
    [SerializeField] public Transform target;

    public BoxCollider2D confinerCollider;

    private Vector3 playerPosition;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    //could use cinemachine, but i kinda prefer it simple :3
    public bool shouldFollow = true;

    //Camera Confiner
    private void Start() {
        if (confinerCollider != null)
        {
            Bounds bounds = confinerCollider.bounds;
            float camHeight = Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;

            minBounds = new Vector2(bounds.min.x + camWidth, bounds.min.y + camHeight);
            maxBounds = new Vector2(bounds.max.x - camWidth, bounds.max.y - camHeight);
        }

        Debug.Log(minBounds);
        Debug.Log(maxBounds);
    }

    void Update()
    {
        if (shouldFollow) {

            playerPosition.Set(target.position.x, target.position.y, -10f);

            //Smoothly move the camera
            Vector3 smoothedPosition = Vector3.Slerp(transform.position, playerPosition, FollowSpeed * Time.deltaTime);

            //Clamp the position within bounds - similar behavior to Cinemachine Confiner2d
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);

            transform.position = smoothedPosition;
        }
    }

    public void SetPositionHub() {
        //Lock camera when in hub
        transform.position = new Vector3(0.5f, 28.75f, transform.position.z);
    }
}
