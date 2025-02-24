using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    public int healthAmount = 20;

    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.AddHealth(healthAmount);
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.linearVelocity = new Vector2(targetDirection.x, targetDirection.y) * 5f;
        }
    }

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        hasTarget = true;
    }
}
