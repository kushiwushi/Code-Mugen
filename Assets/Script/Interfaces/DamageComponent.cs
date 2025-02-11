using UnityEngine;

public interface DamageComponent : HealthComponent
{
    void ApplyKnockback(Vector2 force);
}
