using UnityEngine;

public class Exp_Drop : MonoBehaviour
{
    public int exp_amount = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLevel playerLevel = other.GetComponent<PlayerLevel>(); // Get PlayerLevel component

            if (playerLevel != null)
            {
                playerLevel.GainExperience(exp_amount);
                Destroy(gameObject); // Destroy the pickup
            }
        }
    }
}
