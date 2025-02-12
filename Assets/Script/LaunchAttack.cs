using UnityEngine;

public class LaunchAttack : MonoBehaviour
{
    private Animator attackAnimator;
    private Attack attackScript;

    void Start()
    {
        //instantiate component
        attackAnimator = GetComponent<Animator>();
        attackScript = GetComponentInChildren<Attack>();

    }

    void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                attackScript.AimMousePoint();
                attackAnimator.SetTrigger("Attack");
            }
        }
}
