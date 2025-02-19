using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    public int healthAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>(); // Get PlayerHealth component

            if (playerHealth != null)
            {
                playerHealth.AddHealth(healthAmount); // Call the AddHealth function
                Destroy(gameObject); // Destroy the pickup
            }
        }
    }
}