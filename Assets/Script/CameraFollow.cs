using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public float FollowSpeed = 3f;
    [SerializeField] public Transform target;

    private Vector3 playerPosition;

    //could use cinemachine, but i kinda prefer it simple :3

    void Update()
    {
        playerPosition.Set(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, playerPosition, FollowSpeed * Time.deltaTime);
    }
}
