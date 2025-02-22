using UnityEngine;

public class OrbTrigger : MonoBehaviour
{
    public float orbDamage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.takeDamage(orbDamage);
        }
    }
}
