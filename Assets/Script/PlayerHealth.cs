using UnityEngine;

public class PlayerHealth : MonoBehaviour, HealthComponent
{
    public Healthbar healthUI;

    public float currentHealth; //Actual health value
    public float maxHealth = 100f; //Max health value

    //The Health property from the interface
    public float Health
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0f, maxHealth);}
    }

    void Start() {
        Health = maxHealth;
        healthUI.SetMaxHealth(Health);
    }

    //still buggy, this gets triggered by the sword collider when it hits an enemy
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            takeDamage(20);
        }
    }

    public void takeDamage(float amount) {
        Health -= amount;
        healthUI.SetHealth(Health);
    }
}
