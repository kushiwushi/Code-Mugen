using UnityEngine;

public class PickupRange : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    CircleCollider2D pickupRangeCollider;

    private void Awake() {
        pickupRangeCollider = GetComponent<CircleCollider2D>();
    }

    private void Start() {
        pickupRangeCollider.radius = playerStats.PickupRange;
    }

    public void UpdateRange() {
        pickupRangeCollider.radius = playerStats.PickupRange;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Exp_Drop exp))
        {
            exp.SetTarget(transform.parent.position);
        }

        if (other.TryGetComponent(out HealthDrop health))
        {
            health.SetTarget(transform.parent.position);
        }
    }
}
