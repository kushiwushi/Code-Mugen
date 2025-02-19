using UnityEngine;

public class TransitionPlayer : MonoBehaviour
{
    private CameraFollow cam;

    private void Start() {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            PlayerMovement playerController = other.GetComponent<PlayerMovement>();

            if (playerController != null) {
                if (!playerController.isOnHub) {
                other.transform.position = new Vector3(0f, 26f, other.transform.position.z);
                playerController.isOnHub = true;
                cam.shouldFollow = false;
                cam.SetPositionHub();
            } else {
                other.transform.position = new Vector3(0f, 9f, other.transform.position.z);
                playerController.isOnHub = false;
                cam.shouldFollow = true;
            }
            }


        }
    }
}
