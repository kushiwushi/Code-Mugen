using System.Collections;
using UnityEngine;

public class LaunchAttack : MonoBehaviour
{
    private Animator attackAnimator;
    private Attack attackScript;

    public float attackSpd = 2f;

    private void Awake() {
        //instantiate components
        attackAnimator = GetComponent<Animator>();
        attackScript = GetComponentInChildren<Attack>();
    }

    void Start() {
        StartCoroutine(Attack()); //start auto attack
    }

    void Update(){

    }

    IEnumerator Attack() {
        while(true) {
            yield return new WaitForSeconds(attackSpd);

            attackScript.AimMousePoint();
            attackAnimator.SetTrigger("Attack");
        }
    }
}
