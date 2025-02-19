using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Slider slider;
    private float targetExp;
    private float smoothSpeed = 5f;

    void Update() {
        slider.value = Mathf.Lerp(slider.value, targetExp, Time.deltaTime * smoothSpeed);
    }

    private void Awake() {
        slider = GetComponent<Slider>();
    }

    public void SetMaxExp(float exp) {
        slider.maxValue = exp;
    }

    public void SetExp(float exp) {
        targetExp = exp;
    }
}
