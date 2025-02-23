using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.takeDamage(playerStats.Damage);
            enemy.ApplyKnockback(2f, 0.3f);
        }

        if (other.TryGetComponent(out BigEnemy bigEnemy))
        {
            bigEnemy.takeDamage(playerStats.Damage);
        }
    }
}
