using UnityEngine;
using UnityEngine.UI;

public class BigEnemy : Enemy
{
    [SerializeField] private Slider HealthBar;

    protected override void Start() {
        base.Start();
        Health = 1000f;
        HealthBar.maxValue = Health;
        HealthBar.value = Health;
    }

    public override void ResetEnemy() {
        base.ResetEnemy();
        Health = 1000f;
        HealthBar.value = Health;
    }

    public override void ApplyKnockback(float force, float duration) {
        knockbackVelocity = -moveDirection * (force - 0.2f); //lesser knockback force for bosses
        knockbackTimer = duration - 1.5f; //lesser duration for bosses
    }

    public override void takeDamage(float amount) {
        base.takeDamage(amount);
        HealthBar.value = Health;
    }
}
