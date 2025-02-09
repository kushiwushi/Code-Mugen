using UnityEngine;

public class LaunchAttack : MonoBehaviour
{
    private Animator attackAnimator;

    void Start()
    {
        //found in grandchildren of Player Object
        attackAnimator = GameObject.FindGameObjectWithTag("AttackAnimator").GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //plays the attack animation (the sword shouldn't appear all the time, it should only come out when the attack is triggered but idk..
            //                             tried GameObject.setActive = true (base value 'false') but doesn't work cus object is not active qwq)
            attackAnimator.SetTrigger("Attack");
        }
    }
}
