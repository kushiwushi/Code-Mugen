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

    void Start() 
    {
        Health = maxHealth;
        healthUI.SetMaxHealth(Health);
    }

    public void takeDamage(float amount) {
        Health -= amount;
        healthUI.SetHealth(Health);
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthUI.SetHealth(Health);
        // Optionally update UI here if needed
        Debug.Log("Player Health: " + currentHealth); // Example
    }

}
