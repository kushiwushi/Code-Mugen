using UnityEngine;

public class TransitionPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            PlayerMovement playerController = other.GetComponent<PlayerMovement>();

            if (playerController != null) {
                if (!playerController.isOnHub) {
                other.transform.position = new Vector3(0f, 26f, other.transform.position.z);
                playerController.isOnHub = true;
            } else {
                other.transform.position = new Vector3(0f, 9f, other.transform.position.z);
                playerController.isOnHub = false;
            }
            }


        }
    }
}
