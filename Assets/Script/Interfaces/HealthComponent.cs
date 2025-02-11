public interface HealthComponent
{
    float Health { get; set; }
    void takeDamage(float amount);
}
