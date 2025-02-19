using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    private float targetHealth;
    private float smoothSpeed = 5f;

    void Update() {
        slider.value = Mathf.Lerp(slider.value, targetHealth, Time.deltaTime * smoothSpeed);
    }

    private void Awake() {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(float health) {
        slider.maxValue = health;
        targetHealth = health;
    }

    public void SetHealth(float health) {
        targetHealth = health;
    }
}
