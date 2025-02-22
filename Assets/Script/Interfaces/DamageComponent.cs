using UnityEngine;

public interface DamageComponent : HealthComponent
{
    void ApplyKnockback(float force, float duration);
}
