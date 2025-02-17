using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;

    private void Awake() {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(float health) {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health) {
        slider.value = health;
    }
}
