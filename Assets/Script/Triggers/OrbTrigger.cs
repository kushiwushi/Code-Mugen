using UnityEngine;

public class OrbTrigger : MonoBehaviour
{
    public float orbDamage = 20;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.name);

        if (other.CompareTag("Enemy")) {
            Enemy enemy = other.GetComponent<Enemy>();

            enemy.takeDamage(orbDamage);
        }
    }
}
